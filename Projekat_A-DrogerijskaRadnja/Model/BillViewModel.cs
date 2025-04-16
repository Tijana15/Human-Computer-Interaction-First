using Projekat_A_DrogerijskaRadnja.Model;
using System.Collections.ObjectModel;

namespace Projekat_A_DrogerijskaRadnja.ViewModels
{
    public class BillViewModel
    {
        public Bill Bill { get; set; }
        public ObservableCollection<BaseBillItem> BillItems { get; set; }

        public BillViewModel(Bill bill)
        {
            Bill = bill;
            BillItems = new ObservableCollection<BaseBillItem>();
        }
    }
}