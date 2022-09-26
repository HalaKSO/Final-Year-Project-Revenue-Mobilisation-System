using RevenueApp.Models.Data.RevenueDBContext;
using RevenueApp.Models.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RevenueApp.Models.Data.Services
{
    public class GenderService
    {
        private RevenueDBContext.RevenueDBContext _Context;
        public GenderService(RevenueDBContext.RevenueDBContext context)
        {
            _Context = context;

        }
        //Create a list 
        public List<GenderViewModel> GetGender()
        {
            List<Gender> genders = _Context.Genders.ToList();
            List<GenderViewModel> model = genders.Select(x => new GenderViewModel
            {
                GenderId = x.GenderId,
                GenderType = x.GenderType
            }).ToList();
            return model;
        }
        //Add new data 
        public bool AddGender(GenderViewModel model)
        {
            Gender gender = new()
            {
                GenderType = model.GenderType
            };
            _Context.Genders.Add(gender);
            _Context.SaveChanges();
            return true;
        }
        //update data
        public bool UpdateGender(GenderViewModel model)
        {
            Gender gender = _Context.Genders.Where(x => x.GenderId == model.GenderId).FirstOrDefault();
            gender.GenderType = model.GenderType;
            _Context.Genders.Update(gender);
            _Context.SaveChanges();

            return true;

        }
        //Delete data
        public bool DeleteGender(int id)
        {
            //localhost:1234/Gender/Delete/1
            Gender gender = _Context.Genders.Where(x => x.GenderId == id).FirstOrDefault();
            _Context.Genders.Remove(gender);
            _Context.SaveChanges();
            return true;
        }
        //Get details of the table
        public GenderViewModel GetGenderDetails(int id)
        {
            Gender gender = _Context.Genders.Where(x => x.GenderId == id).FirstOrDefault();
            GenderViewModel model = new()
            {
                GenderId = gender.GenderId,
                GenderType = gender.GenderType
            };
            return model;
        }
    }
}
