using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MimeKit;
using RevenueApp.Models.Data.RevenueDBContext;
using RevenueApp.Models.Data.Settings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RevenueApp.Models.Data.Services
{
    public class MailService
    {
        private readonly MailSettings _mailSettings;
       
        private RevenueDBContext.RevenueDBContext _Context;
        public MailService(IOptions<MailSettings> mailSettings, RevenueDBContext.RevenueDBContext context)
        {
            _mailSettings = mailSettings.Value;
            _Context = context;
        }

        public async Task<bool> SendReceiptByEmailAsync(string OfficerName,string customerName,string customerEmail,string houseCategory,
            string previousPayment,string arrears,string totalamount,string transactionType
            ) 
        {
            

            HseMessageBodyModel model = new()
            {
                
                CustomerName = customerName,
                CustomerEmail = customerEmail,
                HouseCategoryName = houseCategory,
                PaymemtDate = DateTime.Now.ToShortDateString(),
                OfficerName = OfficerName,
                HsePrevPayment = previousPayment,
                HseArrears = arrears,
                HseTotalAmtDue = totalamount,
                Subject = "Payment Receipt for " + DateTime.Now.Year.ToString(),
                TransactionType = transactionType
            };

            string FilePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\HouseInvoice.html");
            StreamReader str = new(FilePath);
            string MailText = str.ReadToEnd();
            str.Close();
            MailText = MailText.Replace("[CustomerName]", model.CustomerName)
                               .Replace("[HouseCategoryName]", model.HouseCategoryName)
                               .Replace("[OfficerName]", model.OfficerName)
                               .Replace("[PaymemtDate]", model.PaymemtDate)
                               .Replace("[HsePrevPayment]", model.HsePrevPayment)
                               .Replace("[HseArrears]", model.HseArrears)
                               .Replace("[HseTotalAmtDue]", model.HseTotalAmtDue)
                               .Replace("[TransactionType]", model.TransactionType);
                               
                               
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
            email.To.Add(MailboxAddress.Parse(model.CustomerEmail));
            email.Subject = model.Subject;

            var builder = new BodyBuilder
            {
                HtmlBody = MailText      
            };
            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);

            return true;
        }

    }
}
