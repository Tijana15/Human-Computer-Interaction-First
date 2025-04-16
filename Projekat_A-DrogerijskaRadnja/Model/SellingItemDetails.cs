using System;

namespace Projekat_A_DrogerijskaRadnja.Model
{
    public class SellingItemDetails
    {
        public decimal NabavnaCijena { get; set; }
        public DateTime DatumNabavke { get; set; }
        public string DobavljacNaziv { get; set; }
        public string ToString(string purchasePriceLabel, string purchaseDateLabel, string supplierLabel)
        {
            return $"{purchasePriceLabel} : {NabavnaCijena:C}\n" +
                   $"{purchaseDateLabel} : {DatumNabavke:dd/MM/yyyy}\n" +
                   $"{supplierLabel} : {DobavljacNaziv}";
        }

        public override string ToString()
        {
            return $"Purchase price : {NabavnaCijena:C}\n" +
                   $"Purchase date : {DatumNabavke:dd/MM/yyyy}\n" +
                   $"Supplier : {DobavljacNaziv}"; 
        }
    }

}
