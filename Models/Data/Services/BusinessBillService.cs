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
    public class BusinessBillService
    {
        private RevenueDBContext.RevenueDBContext _Context;
        public BusinessBillService(RevenueDBContext.RevenueDBContext context)
        {
            _Context = context;     
        }
        //create BBill dropdowns
        public BusinessBillViewModel CreateBBill()
        {
            BusinessBillViewModel model = new()
            {
                
                BusinessList = new SelectList(_Context.Businesses, "BusId", "BusName"),
                BusRateList = new SelectList(_Context.BusinessRates, "BusRateId", "BusRate"),
                CustomerList = new SelectList(_Context.Customers, "CustomerId", "FullName")
            };

            return model;
        }
        //list of BBill
        public List<BusinessBillViewModel> GetBBill()
        {
            List<BusinessBill> businessBills = _Context.BusinessBills.Include(x => x.Bus)
                                                                     .Include(x => x.BusRate)
                                                                  
                                                                     .Include(x => x.Customer)
                                                                     .ToList();
            List<BusinessBillViewModel> model = businessBills.Select(x => new BusinessBillViewModel
            {
                
                BusBillNumber = x.BusBillNumber,
                BusBillDate = x.BusBillDate,
                BusId = x.BusId,
                BusCurrentBill = x.BusCurrentBill,
                YearBill = x.YearBill,
                BusArrears = x.BusArrears,
                BusTotalAmtDue = x.BusTotalAmtDue,
                BusPrevPayment = x.BusPrevPayment,
                BusRateId = x.BusRateId,
                CustomerId = x.CustomerId,
                CustomerName = $"{x.Customer.CustomerFname} {x.Customer.CustomerLname}"

            }).ToList();

            return model;
        }

        //BBill details
        public BusinessBillViewModel GetBBillDetails(int id)
        {
            BusinessBill businessBill = _Context.BusinessBills.Where(x => x.BusBillNumber == id)
                                          
                                            .Include(x => x.Bus)
                                            .Include(x => x.BusRate)
                                            .Include(x => x.Customer)
                                            .FirstOrDefault();

            BusinessBillViewModel model = new() 
            {
                BusBillNumber = businessBill.BusBillNumber,
                BusBillDate = businessBill.BusBillDate,
                BusId = businessBill.BusId,
                BusCurrentBill = businessBill.BusCurrentBill,
                YearBill = businessBill.YearBill,
                BusArrears = businessBill.BusArrears,
                BusTotalAmtDue = businessBill.BusTotalAmtDue,
                BusPrevPayment = businessBill.BusPrevPayment,
                BusRateId = businessBill.BusRateId,
                CustomerId = businessBill.CustomerId,
                BusinessList = new SelectList(_Context.Businesses, "BusId", "BusName"),
                CustomerList = new SelectList(_Context.Customers, "CustomerId", "FullName"),
                BusRateList = new SelectList(_Context.BusinessRates, "BusRateId", "BusRate"),
                CustomerName = $"{businessBill.Customer.CustomerFname} {businessBill.Customer.CustomerLname}"
            };

            return model;
        }
        public bool AddBBill(BusinessBillViewModel model)
        {
            BusinessBill businessBill = new()
            {
                BusBillNumber = model.BusBillNumber,
                BusBillDate = model.BusBillDate,
                BusId = model.BusId,
                BusCurrentBill = model.BusCurrentBill,
                BusArrears = model.BusArrears,
                BusTotalAmtDue = model.BusTotalAmtDue,
                BusPrevPayment = model.BusPrevPayment,
                BusRateId = model.BusRateId,
                CustomerId = model.CustomerId,
            };
            _Context.BusinessBills.Add(businessBill);
            _Context.SaveChanges();
            return true;

        }
        public bool UpdateBBill(BusinessBillViewModel model)
        {
            BusinessBill businessBill = _Context.BusinessBills.Where(x => x.BusBillNumber == model.BusBillNumber)
                                                                                                
                                                                                                .Include(x => x.Bus)
                                                                                                .Include(x => x.BusRate)
                                                                                                .Include(x => x.Customer)
                                                                                                .FirstOrDefault();
            
            businessBill.BusBillNumber = model.BusBillNumber;
            businessBill.BusBillDate = model.BusBillDate;
            businessBill.BusId = model.BusId;
            businessBill.BusCurrentBill = model.BusCurrentBill;
            businessBill.BusArrears = model.BusArrears;
            businessBill.BusTotalAmtDue = model.BusTotalAmtDue;
            businessBill.BusPrevPayment = model.BusPrevPayment;
            businessBill.CustomerId = model.CustomerId;
            businessBill.BusRateId = model.BusRateId;
            _Context.BusinessBills.Update(businessBill);
            _Context.SaveChanges();
            return true;
        }
        //Delete BBill
        public bool DeleteBBill(int id)
        {
            BusinessBill businessBill = _Context.BusinessBills.Where(x => x.BusBillNumber == id)
                                                              
                                                              .Include(x => x.Bus)
                                                              .Include(x => x.BusRate)
                                                              .Include(x => x.Customer)
                                                              .FirstOrDefault();
            _Context.BusinessBills.Remove(businessBill);
            _Context.SaveChanges();
            return true;

        }

        //View all customer year bills
        public List<BusinessBillViewModel> GetAllCustomerYearBills(int customerId) 
        {
            List<BusinessBill> businessBills = _Context.BusinessBills.Where(x => x.CustomerId == customerId)
                                                                     .Include(x => x.Bus)
                                                                     .Include(x => x.BusRate)
                                                                     .Include(x => x.Customer)
                                                                     .ToList();
            List<BusinessBillViewModel> model = businessBills.Select(x => new BusinessBillViewModel
            {

                BusBillNumber = x.BusBillNumber,
                BusBillDate = x.BusBillDate,
                BusId = x.BusId,
                BusCurrentBill = x.BusCurrentBill,
                YearBill = x.YearBill,
                BusArrears = x.BusArrears,
                BusTotalAmtDue = x.BusTotalAmtDue,
                BusPrevPayment = x.BusPrevPayment,
                BusRateId = x.BusRateId,
                CustomerId = x.CustomerId,
                CustomerName = $"{x.Customer.CustomerFname} {x.Customer.CustomerLname}"

            }).ToList();

            return model;
        }


    }
}
