using System;
using Projekat_A_DrogerijskaRadnja.Model;

namespace Projekat_A_DrogerijskaRadnja.Model
{
   public class SellingItem
    {
        public int ProductId { get; set; }
        public int PurchaseId { get; set; }
        public double Price { get; set; }
        public  Product Product { get; set; }

        public SellingItem() { }
        public SellingItem(int productId, int purchaseId, double price,Product product) {
            this.ProductId=productId;
            this.PurchaseId=purchaseId;
            this.Price=price;
            this.Product=product;
        }
    }
}
