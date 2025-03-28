using Projekat_A_DrogerijskaRadnja.Services;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Projekat_A_DrogerijskaRadnja.Views
{
    /// <summary>
    /// Interaction logic for BillsOverview.xaml
    /// </summary>
    public partial class BillsOverview : UserControl
    {
        private readonly BillService billService;
        public BillsOverview()
        {
            InitializeComponent();
            billService = new BillService();
        }

        private void OnSearchButtonClick(object sender, RoutedEventArgs e)
        {
            if(datePicker.SelectedDate.HasValue)
            {
                DateTime selectedDate = datePicker.SelectedDate.Value;
                var bills = billService.GetBillsByDate(selectedDate.ToString());

                billsList.ItemsSource = bills;
                if(bills.Count==0)
                {
                    MessageBox.Show("No bills for provided date.");
                }
            }
            else
            {
                MessageBox.Show("Please select the date.");
            }

        }
    }
}
