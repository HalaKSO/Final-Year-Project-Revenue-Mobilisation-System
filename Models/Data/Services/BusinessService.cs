using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RevenueApp.Models.Data.RevenueDBContext;
using RevenueApp.Models.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RevenueApp.Models.Data.Services
{
    public class BusinessService
    {
        private RevenueDBContext.RevenueDBContext _Context;
        public BusinessService(RevenueDBContext.RevenueDBContext context)
        {
            _Context = context;
        }
      
        //create Businesses dropdowns
        public BusinessViewModel CreateBusiness()
        {
            BusinessViewModel model = new()
            {
                CustomerList = new SelectList(_Context.Customers, "CustomerId", "FullName"),
                BusCatList = new SelectList(_Context.BusinessCategories, "BusCatId", "BusCatName")

            };

            return model;
        }
        //list of Businesses
        public List<BusinessViewModel> GetBusinesses()
        {
            List<Business> businesses = _Context.Businesses.Include(x => x.Customer)
                                                           .Include(x => x.BusCat)
                                                           .ToList();
            

            List<BusinessViewModel> model = businesses.Select(x => new BusinessViewModel
            {
                BusId = x.BusId,
                BusName = x.BusName,
                BusBlockNumber = x.BusBlockNumber,
                CustomerId = x.CustomerId,
                CustomerName = $"{x.Customer.CustomerFname} {x.Customer.CustomerLname}",
                BusDigitalAddress = x.BusDigitalAddress,
                BusLocation = x.BusLocation,
                BusTelNumber = x.BusTelNumber,
                BusRegDate = x.BusRegDate,
                BusCatId = x.BusCatId,
                BusinessCategoryName = x.BusCat.BusCatName
                


            }).ToList();

            return model;
        }

        //Business details
        public BusinessViewModel GetBusinessDetails(int id)
        {
            Business business = _Context.Businesses.Where(x => x.BusId == id)
                                            .Include(x => x.Customer)
                                            .Include(x => x.BusCat)
                                            .FirstOrDefault();

            BusinessViewModel model = new()
            { 

                BusName = business.BusName,
                BusCatId = business.BusCatId,
                BusBlockNumber = business.BusBlockNumber,
                CustomerId = business.CustomerId,
                CustomerName = $"{business.Customer.CustomerFname} {business.Customer.CustomerLname}",
                BusDigitalAddress = business.BusDigitalAddress,
                BusLocation = business.BusLocation,
                BusRegDate = business.BusRegDate,
                BusTelNumber = business.BusTelNumber,
                BusId = business.BusId,
                BusinessCategoryName = business.BusCat.BusCatName

            };

            return model;
        }
        public bool AddBusiness(BusinessViewModel model,int customerId)
        {
            int businnessId,businessCategoryId;

           
           
            businessCategoryId = model.BusCatId;

            Business business = new()
            {
                BusName = model.BusName,
                CustomerId = customerId,
                BusBlockNumber = model.BusBlockNumber,
                BusCatId = model.BusCatId,
                BusDigitalAddress = model.BusDigitalAddress,
                BusTelNumber = model.BusTelNumber,
                BusLocation = model.BusLocation,
                BusRegDate = Convert.ToDateTime(DateTime.Now.ToShortDateString())
            };
            _Context.Businesses.Add(business);
            _Context.SaveChanges();

            businnessId = business.BusId;


            //Calculate the new business bill for the year

            bool currentbillresult = CalculateCurrentBillForTheYear(businnessId, businessCategoryId, customerId);
            if (currentbillresult)
                return true;

            return false;

        }
       
       
        
        public bool UpdateBuisness(BusinessViewModel model)
        {
            Business business = _Context.Businesses.Where(x => x.BusId == model.BusId).Include(x => x.Customer)
                                                                                       .Include(x => x.BusCat)
                                                                                      .FirstOrDefault();



            business.BusId = model.BusId;
            business.BusName = model.BusName;
            business.BusRegDate = model.BusRegDate;
            business.CustomerId = model.CustomerId;
            business.BusLocation = model.BusLocation;
            business.BusCatId = model.BusCatId;
            business.BusDigitalAddress = model.BusDigitalAddress;
            business.BusTelNumber = model.BusTelNumber;
            business.BusBlockNumber = model.BusBlockNumber;
            _Context.Businesses.Update(business);
            _Context.SaveChanges();
            return true;
        }
        //Delete Business
        public bool DeleteBusiness(int id)
        {
            Business business = _Context.Businesses.Where(x => x.BusId == id)
                                           .Include(x => x.Customer)
                                           .Include(x => x.BusCat)
                                           .FirstOrDefault();
            _Context.Businesses.Remove(business);
            _Context.SaveChanges();
            return true;
        }


        private bool CalculateCurrentBillForTheYear(int businessId, int businessCategoryId,int customerId)
        {

            //get buscatid
            BusinessRate rate = _Context.BusinessRates.Where(x => x.BusCatId == businessCategoryId)
                                                      .Include(x => x.BusCat)
                                                      .FirstOrDefault();



            BusinessBill businessBill = new()
            {
                BusBillDate = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
                BusId = businessId,
                BusCurrentBill = rate.BusRate,
                YearBill = rate.BusRate,
                BusPrevPayment = "0",
                BusArrears = "0",
                BusTotalAmtDue = rate.BusRate,
                CustomerId = customerId,
                BusRateId = rate.BusRateId
            };

            _Context.BusinessBills.Add(businessBill);
            _Context.SaveChanges();

            return true;
        }


        //customers list
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



    }
}
