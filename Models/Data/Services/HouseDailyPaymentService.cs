using Microsoft.AspNetCore.Identity;
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
    public class HouseDailyPaymentService
    {
        private MailService _MailService;
        private UserManager<ApplicationUser> _UserManager;
        private RevenueDBContext.RevenueDBContext _Context;
        public HouseDailyPaymentService(RevenueDBContext.RevenueDBContext context, UserManager<ApplicationUser> userManager, MailService mailService)
        {
            _Context = context;
            _UserManager = userManager;
            _MailService = mailService;
        }
        //create HDP dropdowns
        public HouseDailyPaymentViewModel CreateHDP()
        {
            HouseDailyPaymentViewModel model = new()
            {
                HseList = new SelectList(_Context.Houses, "HseId", "HseName"),
                CustomerList = new SelectList(_Context.Customers, "CustomerId", "FullName")
            };

            return model;
        }
        //list of HDP
        public List<HouseDailyPaymentViewModel> GetHDP()
        {
            List<HouseDailyPayment> houseDailyPayments = _Context.HouseDailyPayments.Include(x => x.Hse)
                                                                                    .Include(x => x .Customer)
                                                                                    .ToList();
            List<HouseDailyPaymentViewModel> model = houseDailyPayments.Select(x => new HouseDailyPaymentViewModel
            {
                HseId = x.HseId,
                HouseName = x.Hse.HseName,
                HsePaymentId = x.HsePaymentId,
                HsePaymentDate = x.HsePaymentDate,
                HseAmount = x.HseAmount,
                CustomerId = x.CustomerId,
                customerName = $"{x.Customer.CustomerFname} {x.Customer.CustomerLname}",
                
            }).ToList();
            return model;
        }

        //HDP details
        public HouseDailyPaymentViewModel GetHDPDetails(int id)
        {
            HouseDailyPayment houseDailyPayment = _Context.HouseDailyPayments.Where(x => x.HsePaymentId == id)
                                            .Include(x => x.Hse)
                                            .Include(x => x.Customer)
                                            .FirstOrDefault();

            HouseDailyPaymentViewModel model = new()
            {

                HseAmount = houseDailyPayment.HseAmount,
                HsePaymentId = houseDailyPayment.HsePaymentId,
                HseId = houseDailyPayment.HseId,
                HsePaymentDate = houseDailyPayment.HsePaymentDate,
                CustomerId = houseDailyPayment.CustomerId,
                CustomerList = new SelectList(_Context.Customers, "CustomerId", "FullName"),
            };
            return model;
        }
        public async Task<bool> AddHDPAsync(HouseDailyPaymentViewModel model, int id,ApplicationUser user)
        {
            double netbill, currentbill, prevpayment, arrears, totalAmt;
            int customerId, houseId;

            HouseBill houseBill = _Context.HouseBills.Where(x => x.HseBillNumber == id).FirstOrDefault();
            customerId= houseBill.CustomerId;
            houseId = houseBill.HseId;
            netbill = Convert.ToDouble(houseBill.HseCurrentBill) - Convert.ToDouble(model.HseAmount);
            prevpayment = Convert.ToDouble(model.HseAmount);
            currentbill = netbill;
            arrears = netbill;
            totalAmt = arrears;
            HouseDailyPayment houseDailyPayment = new()
            {
                HsePaymentDate = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
                HseId = houseBill.HseId,
                HseAmount = model.HseAmount,
                CustomerId = houseBill.CustomerId,
                
                
            };
            _Context.HouseDailyPayments.Add(houseDailyPayment);
            _Context.SaveChanges();

            //update business bill

            houseBill.HseCurrentBill = currentbill.ToString();
            houseBill.HsePrevPayment = prevpayment.ToString();
            houseBill.HseArrears = arrears.ToString();
            houseBill.HseTotalAmtDue = totalAmt.ToString();
            _Context.HouseBills.Update(houseBill);
            _Context.SaveChanges();

            //sending receipt via email

            bool result = await SendEmail(customerId, houseId, user, prevpayment.ToString(), arrears.ToString(), totalAmt.ToString(), "Property");
            if (result)
            {
                return true;
            }

            return false;

        }

        private async Task<bool> SendEmail(int customerId,int houseId,ApplicationUser user,string prevPayment,string arrears,string totalAmount,string transactionType)
        {
            string customerName;
            string houseCatgoryName;
            string officerName;
            string paymentDate = DateTime.Now.ToString();

            Customer customer = _Context.Customers.Where(x => x.CustomerId == customerId).FirstOrDefault();
            customerName = $"{customer.CustomerFname} {customer.CustomerLname}";
            officerName = user.FullName;

            House house = _Context.Houses.Where(x => x.HseId == houseId).FirstOrDefault();
            HouseCategory houseCategory = _Context.HouseCategories.Where(x => x.HseCatId == house.HseCatId).FirstOrDefault();
            houseCatgoryName = houseCategory.HseCatName;

            bool sentEmailResult = await _MailService.SendReceiptByEmailAsync(officerName, customerName, customer.CustomerEmail,
                houseCatgoryName, prevPayment, arrears, totalAmount, transactionType);

            if (sentEmailResult)
            {
                return true;
            }


            return false;
        }




        public bool UpdateHDP(HouseDailyPaymentViewModel model)
        {
            HouseDailyPayment houseDailyPayment = _Context.HouseDailyPayments.Where(x => x.HsePaymentId == model.HsePaymentId).Include(x => x.Hse)
                                                                                                                              .Include(x => x.Customer)
                                                                                                                              .FirstOrDefault();



            houseDailyPayment.HseAmount = model.HseAmount;
            houseDailyPayment.HsePaymentId = model.HsePaymentId;
            houseDailyPayment.HseId = model.HseId;
            houseDailyPayment.HsePaymentDate = model.HsePaymentDate;
            houseDailyPayment.CustomerId = model.CustomerId;
            _Context.HouseDailyPayments.Update(houseDailyPayment);
            _Context.SaveChanges();
            return true;
        }
        //Delete HDP
        public bool DeleteHseDP(int id)
        {
            HouseDailyPayment houseDailyPayment = _Context.HouseDailyPayments.Where(x => x.HsePaymentId == id)
                                                                                          .Include(x => x.Hse)
                                                                                          .Include(x => x.Customer)
                                                                                          .FirstOrDefault();
            _Context.HouseDailyPayments.Remove(houseDailyPayment);
            _Context.SaveChanges();
            return true;

        }
    }
}
