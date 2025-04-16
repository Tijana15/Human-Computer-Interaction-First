using MySql.Data.MySqlClient;
using Projekat_A_DrogerijskaRadnja.Model;
using Projekat_A_DrogerijskaRadnja.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Windows;

namespace Projekat_A_DrogerijskaRadnja.Services
{
    public class BillService
    {
        private readonly string connectionString;
        private readonly BillItemBaseService billItemService;


        public BillService()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
            billItemService = new BillItemBaseService();
        }

        public List<Bill> GetAllBills()
        {
            var bills = new List<Bill>();
            using (var connection = new MySqlConnection(connectionString))
            {
                var query = "SELECT * FROM račun";
                var command = new MySqlCommand(query, connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        bills.Add(new Bill(
                            reader.GetInt32("IdRačun"),
                             reader.GetDateTime("DatumVrijemeIzdavanja"),
                            reader.GetString("NacinPlacanja"),
                            reader.GetDouble("Iznos"),
                            reader.GetInt32("KASA_IdKasa"),
                            reader.GetInt32("NALOG_IdNaloga")
                        ));
                    }
                }
            }
            return bills;
        }

        public ObservableCollection<BillViewModel> GetBillsByDate(string date)
        {
            ObservableCollection<BillViewModel> billViewModels = new ObservableCollection<BillViewModel>();
            DateTime searchDate;

            if (DateTime.TryParse(date, out searchDate))
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
                        SELECT
                            IdRačun AS Id,
                            DatumVrijemeIzdavanja AS DateTime,
                            Iznos AS Price,
                            NacinPlacanja AS PayingMethod,
                            KASA_IdKasa AS CashRegisterId,
                            NALOG_IdNaloga AS AccountId
                        FROM
                            račun
                        WHERE
                            DATE(DatumVrijemeIzdavanja) = @Date";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Date", searchDate.ToString("yyyy-MM-dd"));

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Bill bill = new Bill(
                                    reader.GetInt32("Id"),
                                    reader.GetDateTime("DateTime"),
                                    reader.GetString("PayingMethod"),
                                    reader.GetDouble("Price"),
                                    reader.GetInt32("CashRegisterId"),
                                    reader.GetInt32("AccountId")
                                );

                                var billItems = billItemService.GetAllById(bill.BillId);

                                BillViewModel billViewModel = new BillViewModel(bill);
                                foreach (var item in billItems)
                                {
                                    billViewModel.BillItems.Add(item);
                                }
                                billViewModels.Add(billViewModel);
                            }
                        }
                    }
                }
            }

            return billViewModels;
        }

        public int CreateBill(Bill bill)
        {
            int insertedId = -1;

            using (var connection = new MySqlConnection(connectionString))
            {
                string query = @"
            INSERT INTO račun (DatumVrijemeIzdavanja, NacinPlacanja, Iznos, KASA_IdKasa, NALOG_IdNaloga) 
            VALUES (@DatumVrijemeIzdavanja, @NacinPlacanja, @Iznos, @KasaId, @NalogId);
            SELECT LAST_INSERT_ID();";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DatumVrijemeIzdavanja", bill.DateTime);
                    command.Parameters.AddWithValue("@NacinPlacanja", bill.PayingMethod);
                    command.Parameters.AddWithValue("@Iznos", bill.Price);
                    command.Parameters.AddWithValue("@KasaId", bill.CashRegisterId);
                    command.Parameters.AddWithValue("@NalogId", bill.AccountId);

                    connection.Open();
                    insertedId = Convert.ToInt32(command.ExecuteScalar());
                }
            }

            return insertedId;
        }


    }
}
