namespace Projekat_A_DrogerijskaRadnja.Model
{
    public class BaseBillItem
    {
        public int ProductId { get; set; }
        public int BillId { get; set; }
        public int Amount { get; set; }
        public double SellingPrice { get; set; }
        public BaseBillItem() { }
    }
}
