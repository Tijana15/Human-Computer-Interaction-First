using System;

namespace Projekat_A_DrogerijskaRadnja.Model
{
    class DetailedBilIItem
    {
        private int BillId { get; set; }
        private String DateTime { get; set; }
        private String PayingMethod { get; set; }
        private double CashAmount { get; set; }
        private int CashRegisterId { get; set; }
        private int AccountId { get; set; }
        private int ProductId { get; set; }
        private String ProductName { get; set; }
        private int Amount { get; set; }
        private double SellingPrice { get; set; }
        public DetailedBilIItem(int billId, string dateTime, string payingMethod, double cashAmount, int cashRegisterId, int accountId, int productId, string productName, int amount, double sellingPrice)
        {
            BillId = billId;
            DateTime = dateTime;
            PayingMethod = payingMethod;
            CashAmount = cashAmount;
            CashRegisterId = cashRegisterId;
            AccountId = accountId;
            ProductId = productId;
            ProductName = productName;
            Amount = amount;
            SellingPrice = sellingPrice;
        }
        public DetailedBilIItem() { }
    }
}
