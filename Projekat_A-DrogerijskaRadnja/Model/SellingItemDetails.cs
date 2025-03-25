using System;

namespace Projekat_A_DrogerijskaRadnja.Model
{
    public class SellingItemDetails
    {
        public decimal NabavnaCijena { get; set; }
        public DateTime DatumNabavke { get; set; }
        public string DobavljacNaziv { get; set; }
        public override string ToString()
        {
            return $"Purchase price : {NabavnaCijena}$\n" +
                   $"Purchase date : {DatumNabavke:dd/MM/yyyy}\n" +
                   $"Supplier : {DobavljacNaziv}";
        }
    }

}
