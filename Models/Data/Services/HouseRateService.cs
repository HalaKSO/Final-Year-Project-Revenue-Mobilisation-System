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
    public class HouseRateService
    {
        private RevenueDBContext.RevenueDBContext _Context;
        public HouseRateService(RevenueDBContext.RevenueDBContext context)
        {
            _Context = context;

        }
        //create HRate dropdowns
        public HouseRateViewModel CreateHRate()
        {
            HouseRateViewModel model = new()
            {
                HseCatList = new SelectList(_Context.HouseCategories, "HseCatId", "HseCatName")
            };

            return model;
        }
        //list of HRate
        public List<HouseRateViewModel> GetHRate()
        {
            List<HouseRate> houseRates = _Context.HouseRates.Include(x => x.HseCat)
                                                                           .ToList();
            List<HouseRateViewModel> model = houseRates.Select(x => new HouseRateViewModel
            {
                HseRateId = x.HseRateId,
                HseCatId = x.HseCatId,
                HseRate = x.HseRate,
            }).ToList();
            return model;
        }

        //HRate details
        public HouseRateViewModel GetHRateDetails(int id)
        {
            HouseRate houseRate = _Context.HouseRates.Where(x => x.HseRateId == id)
                                            .Include(x => x.HseCat)
                                            .FirstOrDefault();

            HouseRateViewModel model = new()
            {

                HseRate = houseRate.HseRate,
                HseRateId = houseRate.HseRateId,
                HseCatId = houseRate.HseCatId,
                HseCatList = new SelectList(_Context.HouseCategories, "HseCatId", "HseCatName"),
            };

            return model;
        }
        public bool AddHRate(HouseRateViewModel model)
        {


            HouseRate houseRate = new()
            {
                HseRateId = model.HseRateId,
                HseRate = model.HseRate,
                HseCatId = model.HseCatId,
            };
            _Context.HouseRates.Add(houseRate);
            _Context.SaveChanges();
            return true;

        }
        public bool UpdateHRate(HouseRateViewModel model)
        {
            HouseRate houseRate = _Context.HouseRates.Where(x => x.HseRateId == model.HseRateId).Include(x => x.HseCat)
                                                                                                .FirstOrDefault();
            houseRate.HseRateId = model.HseRateId;
            houseRate.HseCatId = model.HseCatId;
            houseRate.HseRate = model.HseRate;
            _Context.HouseRates.Update(houseRate);
            _Context.SaveChanges();
            return true;
        }
        //Delete HRate
        public bool DeleteHRate(int id)
        {
            HouseRate houseRate = _Context.HouseRates.Where(x => x.HseRateId == id)
                                                                  .Include(x => x.HseCat)
                                                                  .FirstOrDefault();
            _Context.HouseRates.Remove(houseRate);
            _Context.SaveChanges();
            return true;

        }
    }
}
