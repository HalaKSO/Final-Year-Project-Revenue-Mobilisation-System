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
    
    public class BusinessDailyPaymentService
    {
        private MailService _MailService;
        private UserManager<ApplicationUser> _UserManager;
        private RevenueDBContext.RevenueDBContext _Context;
        public BusinessDailyPaymentService(RevenueDBContext.RevenueDBContext context, UserManager<ApplicationUser> userManager, MailService mailService)
        {
            _UserManager = userManager;
            _MailService = mailService;
            _Context = context;   
        }
        //create BDP dropdowns
        public BusinessDailyPaymentViewModel CreateBDP()
        {
            BusinessDailyPaymentViewModel model = new()
            {
                BusinessList = new SelectList(_Context.Businesses, "BusId", "BusName"),
                CustomerList = new SelectList(_Context.Customers, "CustomerId", "FullName")
            };

            return model;
        }
        //list of BDP
        public List<BusinessDailyPaymentViewModel> GetBDP()
        {
            List<BusinessDailyPayment> businessDailyPayments = _Context.BusinessDailyPayments.Include(x => x.Bus)
                                                                                              .Include(x => x.Customer)
                                                                                                            .ToList();
            List<BusinessDailyPaymentViewModel> model = businessDailyPayments.Select(x => new BusinessDailyPaymentViewModel
            {
                BusId = x.BusId,
                BusPaymentId = x.BusPaymentId,
                BusinessDailyPaymentDate = x.BusPaymentDate,
                BusAmount = x.BusAmount,
                CustomerId = x.CustomerId,
                CustomerName = $"{x.Customer.CustomerFname} {x.Customer.CustomerLname}",
                BusinessName = x.Bus.BusName
            }).ToList();

            return model;
        }

        //BDP details
        public BusinessDailyPaymentViewModel GetBDPDetails(int id)
        {
            BusinessDailyPayment businessDailyPayment = _Context.BusinessDailyPayments.Where(x => x.BusPaymentId == id)
                                            .Include(x => x.Bus)
                                            .Include(x => x.Customer)
                                            .FirstOrDefault();

            BusinessDailyPaymentViewModel model = new()
            {

                BusAmount = businessDailyPayment.BusAmount,
                BusPaymentId = businessDailyPayment.BusPaymentId,
                BusId = businessDailyPayment.BusId,
                BusinessDailyPaymentDate = businessDailyPayment.BusPaymentDate,
                CustomerId = businessDailyPayment.CustomerId,
                BusinessList = new SelectList(_Context.Businesses, "BusId", "BusName"),
                CustomerList = new SelectList(_Context.Customers, "CustomerId", "FullName"),
                CustomerName = $"{businessDailyPayment.Customer.CustomerFname} {businessDailyPayment.Customer.CustomerLname}"
            };

            return model;
        }
        public async Task<bool> AddBDPAsync(BusinessDailyPaymentViewModel model, int BusBillNumber,ApplicationUser user)
        {
            double netbill, currentbill, prevpayment, arrears, totalAmt;
            int customerId, businessId;
            BusinessBill businessBill = _Context.BusinessBills.Where(x => x.BusBillNumber == BusBillNumber).FirstOrDefault();
            customerId = businessBill.CustomerId;
            businessId = businessBill.BusId;
            netbill = Convert.ToDouble(businessBill.BusCurrentBill) - Convert.ToDouble(model.BusAmount);
            prevpayment = Convert.ToDouble(model.BusAmount);
            currentbill = netbill;
            arrears = netbill;
            totalAmt = arrears;

            BusinessDailyPayment businessDailyPayment = new()
            {
                BusPaymentDate = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
                BusId = businessBill.BusId,
                BusAmount = model.BusAmount,
                CustomerId = businessBill.CustomerId,
                BusBillNumber = BusBillNumber
            };
            _Context.BusinessDailyPayments.Add(businessDailyPayment);
            _Context.SaveChanges();



            //update business bill

            businessBill.BusCurrentBill = currentbill.ToString();
            businessBill.BusPrevPayment = prevpayment.ToString();
            businessBill.BusArrears = arrears.ToString();
            businessBill.BusTotalAmtDue = totalAmt.ToString();
            _Context.BusinessBills.Update(businessBill);
            _Context.SaveChanges();

            //sending receipt via email

            bool result = await SendEmail(customerId, businessId, user, prevpayment.ToString(), arrears.ToString(), totalAmt.ToString(), "Business");
            if (result)
            {
                return true;
            }

            return false;

        }

        private async Task<bool> SendEmail(int customerId, int businessId, ApplicationUser user, string prevPayment, string arrears, string totalAmount, string transactionType)
        {
            string customerName;
            string busCataegory;
            string officerName;
            string paymentDate = DateTime.Now.ToString();

            Customer customer = _Context.Customers.Where(x => x.CustomerId == customerId).FirstOrDefault();
            customerName = $"{customer.CustomerFname} {customer.CustomerLname}";
            officerName = user.FullName;

            Business business = _Context.Businesses.Where(x => x.BusId == businessId).FirstOrDefault();
            BusinessCategory businessCategory = _Context.BusinessCategories.Where(x => x.BusCatId == business.BusCatId).FirstOrDefault();
            busCataegory = businessCategory.BusCatName;

            bool sentEmailResult = await _MailService.SendReceiptByEmailAsync(officerName, customerName, customer.CustomerEmail,
                busCataegory, prevPayment, arrears, totalAmount, transactionType);

            if (sentEmailResult)
            {
                return true;
            }


            return false;
        }

        public bool UpdateBDP(BusinessDailyPaymentViewModel model)
        {
            BusinessDailyPayment businessDailyPayment = _Context.BusinessDailyPayments.Where(x => x.BusPaymentId == model.BusPaymentId).Include(x => x.Bus)
                                                                                                                                       .Include(x => x.Customer)
                                                                                                                                       .FirstOrDefault();
            businessDailyPayment.BusAmount = model.BusAmount;
            businessDailyPayment.BusPaymentId = model.BusPaymentId;
            businessDailyPayment.BusId = model.BusId;
            businessDailyPayment.BusPaymentDate = model.BusinessDailyPaymentDate;
            businessDailyPayment.CustomerId = model.CustomerId;
            _Context.BusinessDailyPayments.Update(businessDailyPayment);
            _Context.SaveChanges();
            return true;
        }
        //Delete BDP
        public bool DeleteBDP(int id)
        {
            BusinessDailyPayment businessDailyPayment = _Context.BusinessDailyPayments.Where(x => x.BusPaymentId == id)
                                           .Include(x => x.Bus)
                                           .Include(x => x.Customer)
                                           .FirstOrDefault();
            _Context.BusinessDailyPayments.Remove(businessDailyPayment);
            _Context.SaveChanges();
            return true;

        }//create BDP dropdowns
        public BusinessDailyPaymentViewModel CreateBRate()
        {
            BusinessDailyPaymentViewModel model = new()
            {
                BusinessList = new SelectList(_Context.Businesses, "BusId", "BusName"),
                CustomerList = new SelectList(_Context.Customers, "CustomerId", "FullName")
            };

            return model;
        }
       
      
    }
}
