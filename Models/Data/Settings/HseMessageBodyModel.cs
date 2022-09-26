using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RevenueApp.Models.Data.Settings
{
    public class HseMessageBodyModel
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } 
        public string CustomerEmail { get; set; }  
        public string HouseCategoryName { get; set; }
        public string PaymemtDate { get; set; }
        public string OfficerName { get; set; }
        public string HsePrevPayment { get; set; }
        public string HseArrears { get; set; }
        public string HseTotalAmtDue { get; set; }
        public string TransactionType { get; set; } 
        public string Subject { get; set; } 


    }
}
