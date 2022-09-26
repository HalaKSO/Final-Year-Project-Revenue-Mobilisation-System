using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RevenueApp.Models.Data.RevenueDBContext;
using RevenueApp.Models.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RevenueApp.Models.Data.Services
{
    public class CustomerService
    {
        private RevenueDBContext.RevenueDBContext _Context;
        public CustomerService(RevenueDBContext.RevenueDBContext context)
        {
            _Context = context;
        }

        //create Customer dropdowns
        public CustomerViewModel CreateCustomer()
        {
            CustomerViewModel model = new()
            {
                TitleList = new SelectList(_Context.Titles, "TitleId", "TitleName"),
                GenderList = new SelectList(_Context.Genders, "GenderId", "GenderType"),
                RelationList = new SelectList(_Context.Relations, "RelationId", "RelationType")
                
            };

            return model;
        }
        //list of Customer
        public List<CustomerViewModel> GetCustomers()
        {
            List<Customer> customers = _Context.Customers.Include(x => x.Title)
                                                   .Include(x => x.Gender)
                                                   .Include(x => x.Relation)
                                                   .Include(x => x.Image)
                                                   .ToList();
            List<CustomerViewModel> model = customers.Select(x => new CustomerViewModel
            {
                CustomerId = x.CustomerId,
                CustomerLname = x.CustomerLname,
                CustomerFname = x.CustomerFname,
                FullName = $"{x.CustomerFname} {x.CustomerLname}",
                CustomerDoB = x.CustomerDoB,
                TitleId = x.TitleId,
                TitleName = x.Title.TitleName,
                CustomerDigitalAddress = x.CustomerDigitalAddress,
                CustomerResidentialAddress = x.CustomerResidentialAddress,
                CustomerContact = x.CustomerContact,
                CustomerNationality = x.CustomerNationality,
                CustomerEmail = x.CustomerEmail,
                CustomerNextOfKin = x.CustomerNextOfKin,
                CustomerSsn = x.CustomerSsn,
                CustomerNextOfKinContact = x.CustomerNextOfKinContact,
                CustomerTinNumber = x.CustomerTinNumber,
                GhanaCardNumber = x.GhanaCardNumber,
                GenderId = x.GenderId,
                GenderType = x.Gender.GenderType,
                ImageId = x.ImageId,
                Photos = x.Image.Photo,
                base64stringpic = Convert.ToBase64String(x.Image.Photo)
                
            }).ToList();

            return model;
        }

        //Customer details
        public CustomerViewModel GetCutomersDetails(int id)
        {
            Customer customer = _Context.Customers.Where(x => x.CustomerId == id)
                                            .Include(x => x.Title)
                                            .Include(x => x.Gender)
                                            .Include(x => x.Relation)
                                            .Include(x => x.Image)
                                            .FirstOrDefault();
                      
            CustomerViewModel model = new()
            {
                CustomerId = customer.CustomerId,
                CustomerLname = customer.CustomerLname,
                CustomerFname = customer.CustomerFname,
                FullName = $"{customer.CustomerFname} {customer.CustomerLname}",
                CustomerDoB = customer.CustomerDoB,
                TitleId = customer.TitleId,
                TitleName = customer.Title.TitleName,
                CustomerDigitalAddress = customer.CustomerDigitalAddress,
                CustomerResidentialAddress = customer.CustomerResidentialAddress,
                CustomerContact = customer.CustomerContact,
                CustomerNationality = customer.CustomerNationality,
                CustomerEmail = customer.CustomerEmail,
                CustomerNextOfKin = customer.CustomerNextOfKin,
                CustomerSsn = customer.CustomerSsn,
                CustomerNextOfKinContact = customer.CustomerNextOfKinContact,             
                CustomerTinNumber = customer.CustomerTinNumber,
                GhanaCardNumber = customer.GhanaCardNumber,             
                GenderId = customer.GenderId,
                GenderType = customer.Gender.GenderType,
                RelationId = customer.RelationId,
                RelationType = customer.Relation.RelationType,
                ImageId = customer.ImageId,
                Photos = customer.Image.Photo,
                TitleList = new SelectList(_Context.Titles, "TitleId", "TitleName"),
                GenderList = new SelectList(_Context.Genders, "GenderId", "GenderType"),
                RelationList = new SelectList(_Context.Relations, "RelationId", "RelationType"),
            };

            return model;
        }
        public bool AddCustomer(CustomerViewModel model)
        {           
            Image image = new Image();
            int imageId = 0;

            if (model.ImageId == 0 && model.Image != null)
            {
                byte[] imageByte;
                using (var stream = new MemoryStream())
                {
                    //model.Image.CopyTo(stream);
                    model.Image.CopyTo(stream);
                    imageByte = stream.ToArray();
                }

                image = new Image()
                {
                    Photo = imageByte
                };
                _Context.Images.Add(image);
                _Context.SaveChanges();
                imageId = image.ImageId;
            }
            Customer customer = new()
            {
                CustomerId = model.CustomerId,
                CustomerLname = model.CustomerLname,
                CustomerFname = model.CustomerFname,
                CustomerDoB = model.CustomerDoB,
                TitleId = model.TitleId,
                CustomerDigitalAddress = model.CustomerDigitalAddress,
                CustomerResidentialAddress = model.CustomerResidentialAddress,
                CustomerContact = model.CustomerContact,
                CustomerNationality = model.CustomerNationality,
                CustomerEmail = model.CustomerEmail,
                CustomerNextOfKin = model.CustomerNextOfKin,
                CustomerSsn = model.CustomerSsn,
                CustomerNextOfKinContact = model.CustomerNextOfKinContact,               
                CustomerTinNumber = model.CustomerTinNumber,
                GhanaCardNumber = model.GhanaCardNumber, 
                GenderId = model.GenderId,
                RelationId = model.RelationId,
                ImageId = imageId,
            };
            _Context.Customers.Add(customer);
            _Context.SaveChanges();

            return true;

        }
        public bool UpdateCustomer(CustomerViewModel model)
        {
            int ImageId = 0;
            Customer customer = _Context.Customers.Where(x => x.CustomerId == model.CustomerId)
                                            .Include(x => x.Title)
                                            .Include(x => x.Gender)
                                            .Include(x => x.Relation)
                                            .Include(x => x.Image)
                                            .FirstOrDefault();

            if (customer.ImageId != 0 && model.Image != null) //want to update pic
            {
                byte[] imageByte = new byte[model.Image.Length];
                using (var stream = new MemoryStream())
                {
                    model.Image.CopyTo(stream);
                    imageByte = stream.ToArray();
                }
                Image images = _Context.Images.Where(x => x.ImageId == model.ImageId).FirstOrDefault();
                images.Photo = imageByte;
                _Context.Images.Update(images);
                _Context.SaveChanges();

                ImageId = images.ImageId;

            }
            if (customer.ImageId != 0 && model.Image == null)
            {
                ImageId = customer.ImageId;
            }
            
            customer.CustomerLname = model.CustomerLname;
            customer.CustomerFname = model.CustomerFname;
            customer.CustomerDoB = model.CustomerDoB;
            customer.TitleId = model.TitleId;
            customer.CustomerDigitalAddress = model.CustomerDigitalAddress;
            customer.CustomerResidentialAddress = model.CustomerResidentialAddress;
            customer.CustomerContact = model.CustomerContact;
            customer.CustomerNationality = model.CustomerNationality;
            customer.CustomerEmail = model.CustomerEmail;
            customer.CustomerNextOfKin = model.CustomerNextOfKin;
            customer.CustomerSsn = model.CustomerSsn;
            customer.CustomerNextOfKinContact = model.CustomerNextOfKinContact;
            
            customer.CustomerTinNumber = model.CustomerTinNumber;
            customer.GhanaCardNumber = model.GhanaCardNumber;
            customer.RelationId = model.RelationId;
            customer.GenderId = model.GenderId;
            customer.ImageId = ImageId;

            _Context.Customers.Update(customer);
            _Context.SaveChanges();

            return true;
        }
        //Delete Customer
        public bool DeleteCustomer(int id)
        {
            Customer customer = _Context.Customers.Where(x => x.CustomerId == id)
                                           .Include(x => x.Title)
                                           .Include(x => x.Gender)
                                           .Include(x => x.Relation)
                                           .Include(x => x.Image)
                                           .FirstOrDefault();
           

            //Delete driver
            Image image1 = _Context.Images.Where(x => x.ImageId == customer.ImageId).FirstOrDefault();
            _Context.Images.Remove(image1);
            _Context.SaveChanges();

            _Context.Customers.Remove(customer);
            _Context.SaveChanges();



            return true;

        }
    }
}
