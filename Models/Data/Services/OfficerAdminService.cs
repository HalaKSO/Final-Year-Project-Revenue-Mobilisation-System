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
    public class OfficerAdminService
    {
        private RevenueDBContext.RevenueDBContext _Context;
        public OfficerAdminService(RevenueDBContext.RevenueDBContext context)
        {
            _Context = context;

        }
        //create OfficerAdmin dropdowns
        public OfficerAdminViewModel CreateOfficeAdmin()
        {
            OfficerAdminViewModel model = new()
            {
                TitleList = new SelectList(_Context.Titles, "TitleId", "TitleName"),
                GenderList = new SelectList(_Context.Genders, "GenderId", "GenderType"),
                RelationList = new SelectList(_Context.Relations, "RelationId", "RelationType"),
                RankList = new SelectList(_Context.OfficeRanks, "RankId", "RankName"),
                AssemblyList = new SelectList(_Context.Assemblies, "AssemblyId", "AssemblyName")


            };

            return model;
        }
        //list of OfficerAdmin
        public List<OfficerAdminViewModel> GetOfficerAdmin()
        {
            List<OfficerAdmin> customers = _Context.OfficerAdmins.Include(x => x.Title)
                                                   .Include(x => x.Gender)
                                                   .Include(x => x.Relation)
                                                   .Include(x => x.Rank)
                                                   .Include(x => x.Assembly)
                                                   .Include(x => x.Image)
                                                   .ToList();
            List<OfficerAdminViewModel> model = customers.Select(x => new OfficerAdminViewModel
            {
                StaffId = x.StaffId,
                OfficerLname = x.OfficerLname,
                OfficerFname = x.OfficerFname,
                SFullName = $"{x.OfficerFname} {x.OfficerLname}",
                OfficerDoB = x.OfficerDoB,
                TitleId = x.TitleId,
                TitleName = x.Title.TitleName,
                OfficerDigitalAddress = x.OfficerDigitalAddress,
                OfficerResidentialAddress = x.OfficerResidentialAddress,
                OfficerContact = x.OfficerContact,
                AssemblyId = x.AssemblyId,
                AssemblyName = x.Assembly.AssemblyName,
                OfficerEmail = x.OfficerEmail,
                OfficerNextOfKin = x.OfficerNextOfKin,
                OfficerNextOfKinContact = x.OfficerNextOfKinContact,
                RankId = x.RankId,
                RankName=x.Rank.RankName,
                GenderId = x.GenderId,
                RelationId = x.RelationId,
                RelationType = x.Relation.RelationType,
                GenderType = x.Gender.GenderType,
                ImageId = x.ImageId,
                Photos = x.Image.Photo,
                base64stringpic = Convert.ToBase64String(x.Image.Photo)

            }).ToList();

            return model;
        }
        public List<OfficerAdminViewModel> GetOfficerAdminById(int staffId)
        {
            List<OfficerAdmin> customers = _Context.OfficerAdmins.Where(x => x.StaffId == staffId)
                                                    .Include(x => x.Title)
                                                   .Include(x => x.Gender)
                                                   .Include(x => x.Relation)
                                                   .Include(x => x.Rank)
                                                   .Include(x => x.Assembly)
                                                   .Include(x => x.Image)
                                                   .ToList();
            List<OfficerAdminViewModel> model = customers.Select(x => new OfficerAdminViewModel
            {
                StaffId = x.StaffId,
                OfficerLname = x.OfficerLname,
                OfficerFname = x.OfficerFname,
                SFullName = $"{x.OfficerFname} {x.OfficerLname}",
                OfficerDoB = x.OfficerDoB,
                TitleId = x.TitleId,
                TitleName = x.Title.TitleName,
                OfficerDigitalAddress = x.OfficerDigitalAddress,
                OfficerResidentialAddress = x.OfficerResidentialAddress,
                OfficerContact = x.OfficerContact,
                AssemblyId = x.AssemblyId,
                AssemblyName = x.Assembly.AssemblyName,
                OfficerEmail = x.OfficerEmail,
                OfficerNextOfKin = x.OfficerNextOfKin,
                OfficerNextOfKinContact = x.OfficerNextOfKinContact,
                RankId = x.RankId,
                RankName=x.Rank.RankName,
                GenderId = x.GenderId,
                RelationId = x.RelationId,
                RelationType = x.Relation.RelationType,
                GenderType = x.Gender.GenderType,
                ImageId = x.ImageId,
                Photos = x.Image.Photo,
                base64stringpic = Convert.ToBase64String(x.Image.Photo)

            }).ToList();

            return model;
        }

        //OfficerAdmin details
        public OfficerAdminViewModel GetOfficerAdminDetails(int id)
        {
            OfficerAdmin officerAdmin = _Context.OfficerAdmins.Where(x => x.StaffId == id)
                                            .Include(x => x.Title)
                                            .Include(x => x.Gender)
                                            .Include(x => x.Relation)
                                            .Include(x => x.Rank)
                                            .Include(x => x.Assembly)
                                            .Include(x => x.Image)
                                            .FirstOrDefault();
            //Relation relation = _Context.Relations.Where(x => x.CustomerId == customer.CustomerId)
            // .FirstOrDefault();

            OfficerAdminViewModel model = new()
            {

                StaffId = officerAdmin.StaffId,
                OfficerLname = officerAdmin.OfficerLname,
                OfficerFname = officerAdmin.OfficerFname,
                SFullName = $"{officerAdmin.OfficerFname} {officerAdmin.OfficerLname}",
                OfficerDoB = officerAdmin.OfficerDoB,
                TitleId = officerAdmin.TitleId,
                TitleName = officerAdmin.Title.TitleName,
                OfficerDigitalAddress = officerAdmin.OfficerDigitalAddress,
                OfficerResidentialAddress = officerAdmin.OfficerResidentialAddress,
                OfficerContact = officerAdmin.OfficerContact,
                OfficerEmail = officerAdmin.OfficerEmail,
                OfficerNextOfKin = officerAdmin.OfficerNextOfKin,
                OfficerNextOfKinContact = officerAdmin.OfficerNextOfKinContact,
                AssemblyId = officerAdmin.AssemblyId,
                AssemblyName = officerAdmin.Assembly.AssemblyName,
                RankId = officerAdmin.RankId,
                RankName = officerAdmin.Rank.RankName,
                GenderId = officerAdmin.GenderId,
                GenderType = officerAdmin.Gender.GenderType,
                RelationId = officerAdmin.RelationId,
                RelationType = officerAdmin.Relation.RelationType,

                ImageId = officerAdmin.ImageId,
                Photos = officerAdmin.Image.Photo,
                TitleList = new SelectList(_Context.Titles, "TitleId", "TitleName"),
                GenderList = new SelectList(_Context.Genders, "GenderId", "GenderType"),
                RelationList = new SelectList(_Context.Relations, "RelationId", "RelationType"),
                RankList = new SelectList(_Context.OfficeRanks, "RankId", "RankName"),
                AssemblyList = new SelectList(_Context.Assemblies, "AssemblyId", "AssemblyName"),


              
            };

            return model;
        }
        public bool AddStaff(OfficerAdminViewModel model)
        {
            Image image = new Image();
            int ImageId = 0;

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
                ImageId = image.ImageId;
            }
            OfficerAdmin officerAdmin = new()
            {
                OfficerLname = model.OfficerLname,
                OfficerFname = model.OfficerFname,
               
                TitleId = model.TitleId,
                OfficerDigitalAddress = model.OfficerDigitalAddress,
                OfficerResidentialAddress = model.OfficerResidentialAddress,
                OfficerContact = model.OfficerContact,
                OfficerDoB = model.OfficerDoB,
                OfficerEmail = model.OfficerEmail,
                OfficerNextOfKin = model.OfficerNextOfKin,
                OfficerNextOfKinContact = model.OfficerNextOfKinContact,
           
                AssemblyId = model.AssemblyId,
                RankId = model.RankId,
                GenderId = model.GenderId,
                ImageId = ImageId,
                RelationId = model.RelationId,


            };
            _Context.OfficerAdmins.Add(officerAdmin);
            _Context.SaveChanges();

           
            return true;

        }
        public bool UpdateStaff(OfficerAdminViewModel model)
        {
            int ImageId = 0;
            OfficerAdmin officerAdmin = _Context.OfficerAdmins.Where(x => x.StaffId == model.StaffId)
                                            .Include(x => x.Title)
                                            .Include(x => x.Gender)
                                            .Include(x => x.Relation)
                                            .Include(x => x.Rank)
                                            .Include(x => x.Assembly)
                                            .Include(x => x.Image)
                                            .FirstOrDefault();

            if (officerAdmin.ImageId != 0 && model.Image != null) //want to update pic
            {
                byte[] imageByte = new byte[model.Image.Length];
                using (var stream = new MemoryStream())
                {
                    model.Image.CopyTo(stream);
                    imageByte = stream.ToArray();
                }
                Image image1 = _Context.Images.Where(x => x.ImageId == model.ImageId).FirstOrDefault();
                image1.Photo = imageByte;
                _Context.Images.Update(image1);
                _Context.SaveChanges();

                ImageId = image1.ImageId;

            }
            if (officerAdmin.ImageId != 0 && model.Image == null)
            {
                ImageId = officerAdmin.ImageId;
            }

           
            officerAdmin.OfficerLname = model.OfficerLname;
            officerAdmin.OfficerFname = model.OfficerFname;
            officerAdmin.OfficerDoB = model.OfficerDoB;
            officerAdmin.TitleId = model.TitleId;
            officerAdmin.OfficerDigitalAddress = model.OfficerDigitalAddress;
            officerAdmin.OfficerResidentialAddress = model.OfficerResidentialAddress;
            officerAdmin.OfficerEmail = model.OfficerEmail;
            officerAdmin.OfficerNextOfKin = model.OfficerNextOfKin;
            officerAdmin.OfficerNextOfKinContact = model.OfficerNextOfKinContact;
           
            officerAdmin.AssemblyId = officerAdmin.AssemblyId;
            officerAdmin.RankId = model.RankId;
            officerAdmin.GenderId = model.GenderId;
            officerAdmin.ImageId = ImageId;
            officerAdmin.RelationId = model.RelationId;


            _Context.OfficerAdmins.Update(officerAdmin);
            _Context.SaveChanges();

            return true;
        }
        //Delete OfficerAdmin
        public bool DeleteOfficeAdmin(int id)
        {
            OfficerAdmin officerAdmin = _Context.OfficerAdmins.Where(x => x.StaffId == id)
                                           .Include(x => x.Title)
                                           .Include(x => x.Gender)
                                           .Include(x => x.Relation)
                                           .Include(x => x.Rank)
                                           .Include(x => x.Assembly)
                                           .Include(x => x.Image)
                                           .FirstOrDefault();


            //Delete driver
            Image image1 = _Context.Images.Where(x => x.ImageId == officerAdmin.ImageId).FirstOrDefault();
            _Context.Images.Remove(image1);
            _Context.SaveChanges();

            _Context.OfficerAdmins.Remove(officerAdmin);
            _Context.SaveChanges();



            return true;

        }
    }
}
