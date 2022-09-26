using RevenueApp.Models.Data.RevenueDBContext;
using RevenueApp.Models.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RevenueApp.Models.Data.Services
{
    public class BusinessCategoryService
    {
        private RevenueDBContext.RevenueDBContext _Context;
        public BusinessCategoryService(RevenueDBContext.RevenueDBContext context)
        {
            _Context = context;
        }
        //Create a list 
        public List<BusinessCategoryViewModel> GetBusCat()
        {
            List<BusinessCategory> businessCategories = _Context.BusinessCategories.ToList();
            List<BusinessCategoryViewModel> model = businessCategories.Select(x => new BusinessCategoryViewModel
            {
                BusCatId = x.BusCatId,
                BusCatName = x.BusCatName
            }).ToList();
            return model;
        }

        //Add new data 
        public bool AddBusCat(BusinessCategoryViewModel model)
        {
            BusinessCategory businessCategory = new BusinessCategory()
            {
                BusCatId = model.BusCatId,
                BusCatName = model.BusCatName
            };
            _Context.BusinessCategories.Add(businessCategory);
            _Context.SaveChanges();
            return true;
        }
        //update data
        public bool UpdateBusCat(BusinessCategoryViewModel model)
        {
            BusinessCategory businessCategory = _Context.BusinessCategories.Where(x => x.BusCatId == model.BusCatId).FirstOrDefault();
            businessCategory.BusCatId = model.BusCatId;
            businessCategory.BusCatName = model.BusCatName;
            _Context.BusinessCategories.Update(businessCategory);
            _Context.SaveChanges();

            return true;

        }
        //Delete data
        public bool DeleteBusCat(int id)
        {
            BusinessCategory businessCategory = _Context.BusinessCategories.Where(x => x.BusCatId == id).FirstOrDefault();
            _Context.BusinessCategories.Remove(businessCategory);
            _Context.SaveChanges();
            return true;
        }
        //Get details of the table
        public BusinessCategoryViewModel GetBusCatDetails(int id)
        {
            BusinessCategory businessCategory = _Context.BusinessCategories.Where(x => x.BusCatId == id).FirstOrDefault();
            BusinessCategoryViewModel model = new BusinessCategoryViewModel
            {
                BusCatId = businessCategory.BusCatId,
                BusCatName = businessCategory.BusCatName
            };
            return model;
        }
    }
}
