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
    public class BusinessRateService
    {
        private RevenueDBContext.RevenueDBContext _Context;
        public BusinessRateService(RevenueDBContext.RevenueDBContext context)
        {
            _Context = context;
        }
        //create BRate dropdowns
        public BusinessRateViewModel CreateBRate()
        {
            BusinessRateViewModel model = new()
            {
                BusCatList = new SelectList(_Context.BusinessCategories, "BusCatId", "BusCatName")
            };

            return model;
        }
        //list of BRate
        public List<BusinessRateViewModel> GetBRate()
        {
            List<BusinessRate> businessRates = _Context.BusinessRates.Include(x => x.BusCat)
                                                   .ToList();
            List<BusinessRateViewModel> model = businessRates.Select(x => new BusinessRateViewModel
            {
                BusRateId = x.BusRateId,
                BusCatId = x.BusCatId,
                BusRate = x.BusRate,
                

            }).ToList();

            return model;
        }

        //BRate details
        public BusinessRateViewModel GetBRateDetails(int id)
        {
            BusinessRate businessRate = _Context.BusinessRates.Where(x => x.BusRateId == id)
                                            .Include(x => x.BusCat)
                                            .FirstOrDefault();

            BusinessRateViewModel model = new()
            {

                BusRate = businessRate.BusRate,
                BusRateId = businessRate.BusRateId,
                BusCatId = businessRate.BusCatId,
                BusCatList = new SelectList(_Context.BusinessCategories, "BusCatId", "BusCatName"),
            };

            return model;
        }
        public bool AddBRate(BusinessRateViewModel model)
        {

            
            BusinessRate businessRate = new()
            {
                BusRate = model.BusRate,
                BusCatId = model.BusCatId,
            };
            _Context.BusinessRates.Add(businessRate);
            _Context.SaveChanges();
            return true;

        }
        public bool UpdateBRate(BusinessRateViewModel model)
        {
            BusinessRate businessRate = _Context.BusinessRates.Where(x => x.BusRateId == model.BusRateId).Include(x => x.BusCat)
                                            .FirstOrDefault();

        

            businessRate.BusRateId = model.BusRateId;
            businessRate.BusCatId = model.BusCatId;
            businessRate.BusRate = model.BusRate;
            _Context.BusinessRates.Update(businessRate);
            _Context.SaveChanges();
            return true;
        }
        //Delete BRate
        public bool DeleteBRate(int id)
        {
            BusinessRate businessRate = _Context.BusinessRates.Where(x => x.BusRateId == id)
                                           .Include(x => x.BusCat)
                                           .FirstOrDefault();
            _Context.BusinessRates.Remove(businessRate);
            _Context.SaveChanges();
            return true;

        }
    }
}
