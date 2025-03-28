using System;

namespace Projekat_A_DrogerijskaRadnja.Model
{
    public class Bill
    {
         public int BillId { get;set; }
        public DateTime DateTime { get; set; }
        public String PayingMethod { get; set; }
        public double Price { get; set; }
        public int CashRegisterId { get; set; }
        public int AccountId { get; set; }
        public  Bill(int billId, DateTime dateTime, string payingMethod, double price, int cashRegisterId, int accountId)
        {
            BillId = billId;
            DateTime = dateTime;
            PayingMethod = payingMethod;
            Price = price;
            CashRegisterId = cashRegisterId;
            AccountId = accountId;
        }
        
    }
    
}
