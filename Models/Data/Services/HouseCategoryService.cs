using RevenueApp.Models.Data.RevenueDBContext;
using RevenueApp.Models.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RevenueApp.Models.Data.Services
{
    public class HouseCategoryService
    {
        private RevenueDBContext.RevenueDBContext _Context;
        public HouseCategoryService(RevenueDBContext.RevenueDBContext context)
        {
            _Context = context;
        }
        //Create a list 
        public List<HouseCategoryViewModel> GetHseCat()
        {
            List<HouseCategory> houseCategories = _Context.HouseCategories.ToList();
            List<HouseCategoryViewModel> model = houseCategories.Select(x => new HouseCategoryViewModel
            {
                HseCatId = x.HseCatId,
                HseCatName = x.HseCatName
            }).ToList();
            return model;
        }

        //Add new data 
        public bool AddHseCat(HouseCategoryViewModel model)
        {
            HouseCategory houseCategory = new HouseCategory()
            {
                HseCatId=model.HseCatId,
                HseCatName = model.HseCatName
            };
            _Context.HouseCategories.Add(houseCategory);
            _Context.SaveChanges();
            return true;
        }
        //update data
        public bool UpdateHseCat(HouseCategoryViewModel model)
        {
            HouseCategory houseCategory = _Context.HouseCategories.Where(x => x.HseCatId == model.HseCatId).FirstOrDefault();           
            houseCategory.HseCatName = model.HseCatName;
            _Context.HouseCategories.Update(houseCategory);
            _Context.SaveChanges();

            return true;

        }
        //Delete data
        public bool DeleteHseCat(int id)
        {
            HouseCategory houseCategory = _Context.HouseCategories.Where(x => x.HseCatId == id).FirstOrDefault();
            _Context.HouseCategories.Remove(houseCategory);
            _Context.SaveChanges();
            return true;
        }
        //Details
        public HouseCategoryViewModel GetHseCatDetails(int id)
        {
            HouseCategory houseCategory = _Context.HouseCategories.Where(x => x.HseCatId == id).FirstOrDefault();
            HouseCategoryViewModel model = new HouseCategoryViewModel
            {
                HseCatId = houseCategory.HseCatId,
                HseCatName = houseCategory.HseCatName
            };
            return model;
        }

    }
}
