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
    public class HouseBillService
    {
        private RevenueDBContext.RevenueDBContext _Context;
        public HouseBillService(RevenueDBContext.RevenueDBContext context)
        {
            _Context = context;
        }
        //create HBill dropdowns
        public HouseBillViewModel CreateHBill()
        {
            HouseBillViewModel model = new();

            return model;
        }
        //list of HBill
        public List<HouseBillViewModel> GetHBill()
        {
            List<HouseBill> houseBills = _Context.HouseBills.Include(x => x.Hse)
                                                            .Include(x => x.HseRate)
                                                            .Include(x => x.Customer)
                                                            .ToList();
            List<HouseBillViewModel> model = houseBills.Select(x => new HouseBillViewModel
            {

                HseArrears = x.HseArrears,
                HseBillDate = x.HseBillDate,
                HseId = x.HseId,
                HseBillNumber = x.HseBillNumber,
                HseCurrentBill = x.HseCurrentBill,
                HseTotalAmtDue = x.HseTotalAmtDue,
                HsePrevPayment = x.HsePrevPayment,
                YearBill = x.YearBill,
                HseRateId = x.HseRateId,
                CustomerId = x.CustomerId,
                CustomerName = $"{x.Customer.CustomerFname} {x.Customer.CustomerLname}"

            }).ToList();

            return model;
        }

        //HBill details
        public HouseBillViewModel GetHBillDetails(int id)
        {
            HouseBill houseBill = _Context.HouseBills.Where(x => x.HseBillNumber == id)
                                                     .Include(x => x.Hse)
                                                     .Include(x => x.Customer)
                                                     .Include(x => x.HseRate)
                                                     .FirstOrDefault();

            HouseBillViewModel model = new()
            {
                HseBillNumber = houseBill.HseBillNumber,
                HsePrevPayment = houseBill.HsePrevPayment,
                HseId = houseBill.HseId,
                HseCurrentBill = houseBill.HseCurrentBill,
                
                HseArrears = houseBill.HseArrears,
                HseTotalAmtDue = houseBill.HseTotalAmtDue,
                HseBillDate = houseBill.HseBillDate,
                HseRateId = houseBill.HseRateId,
                CustomerId = houseBill.CustomerId,
                HseList = new SelectList(_Context.Houses, "HseId", "HseName"),
                CustomerList = new SelectList(_Context.Customers, "CustomerId", "FullName"),
                HseRateList = new SelectList(_Context.HouseRates, "HseRateId", "HseRate"),
            };

            return model;
        }
        public bool AddHBill(HouseBillViewModel model)
        {


            HouseBill houseBill = new()
            {
                HseArrears = model.HseArrears,
                HseBillDate = model.HseBillDate,
                HseId = model.HseId,
                HseBillNumber = model.HseBillNumber,
            
                HseCurrentBill = model.HseCurrentBill,
                HsePrevPayment = model.HsePrevPayment,
                HseTotalAmtDue = model.HseTotalAmtDue,
                HseRateId = model.HseRateId,
                CustomerId = model.CustomerId,
            };
            _Context.HouseBills.Add(houseBill);
            _Context.SaveChanges();
            return true;

        }
        public bool UpdateHBill(HouseBillViewModel model)
        {
            HouseBill houseBill = _Context.HouseBills.Where(x => x.HseBillNumber == model.HseBillNumber)
                                                                                        .Include(x => x.Hse)
                                                                                         .Include(x => x.HseRate)
                                                                                         .Include(x => x.Customer)
                                                                                         .FirstOrDefault();

            houseBill.HseArrears = model.HseArrears;
            houseBill.HseBillDate = model.HseBillDate;
            houseBill.HseId = model.HseId;
         
            houseBill.HseCurrentBill = model.HseCurrentBill;
            houseBill.HsePrevPayment = model.HsePrevPayment;
            houseBill.HseBillNumber = model.HseBillNumber;
            houseBill.HseTotalAmtDue = model.HseTotalAmtDue;
            houseBill.HseRateId = model.HseRateId;
            houseBill.CustomerId = model.CustomerId;
            _Context.HouseBills.Update(houseBill);
            _Context.SaveChanges();
            return true;
        }
        //Delete HBill
        public bool DeleteHBill(int id)
        {
            HouseBill houseBill = _Context.HouseBills.Where(x => x.HseBillNumber == id)
                                                              .Include(x => x.Hse)
                                                              .Include(x => x.HseRate)
                                                              .Include(x => x.Customer)
                                                              .FirstOrDefault();
            _Context.HouseBills.Remove(houseBill);
            _Context.SaveChanges();
            return true;

        }

        public HouseBillViewModel GetHouseBillById(int id)
        {
            HouseBill houseBill = _Context.HouseBills.Where(x => x.HseBillNumber == id).FirstOrDefault();
            HouseBillViewModel model = new()
            {
                HseBillNumber = houseBill.HseBillNumber,
                HseBillDate = houseBill.HseBillDate,
                HseId = houseBill.HseId,
                HseCurrentBill = houseBill.HseCurrentBill,
                HsePrevPayment = houseBill.HsePrevPayment,
                HseArrears = houseBill.HseArrears,
                HseTotalAmtDue = houseBill.HseTotalAmtDue,
                CustomerId = houseBill.CustomerId,
                HseRateId = houseBill.HseRateId,
                YearBill = houseBill.YearBill
            };


            return model;
        }
        

    }
}
