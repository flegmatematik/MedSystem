using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json.Linq;
using UIMedSystem.Controllers;

namespace UIMedSystem.Objednavka
{
    /// <summary>
    /// Interaction logic for ObjednavkaObjednat.xaml
    /// </summary>
    public partial class ObjednavkaObjednat : Window
    {
        private int _objednavkaId;

        public ObjednavkaObjednat(int idObjednavky)
        {
            InitializeComponent();

            _objednavkaId = idObjednavky;

            DateFidget.Text = "Vyberte dátum z ponuky:";
            DateFidget.FirstDayOfWeek = DayOfWeek.Monday;
            DateFidget.DisplayDateStart = DateTime.Today.AddDays(1);
            DateFidget.DisplayDateEnd = DateTime.Today.AddDays(21);
            DateFidget.IsTodayHighlighted = true;

            //TimeFidget.StartTime = DateTime.Today.AddHours(7).TimeOfDay;
            //TimeFidget.EndTime = DateTime.Today.AddHours(14).TimeOfDay;
            //TimeFidget.TimeInterval = TimeSpan.FromMinutes(30);

            
            //TimeFidget.
            //DateFidget.DefaultValue = DateTime.Today.AddHours(8);
            //DateFidget.AllowTextInput = false;
            //DateFidget.Minimum = DateTime.Today.AddDays(1);
            //DateFidget.Maximum = DateTime.Today.AddMonths(2);

            LoadData();
        }

        public async Task LoadData()
        {
            Controller controller = Controller.Instance;

            var response = await controller.GetVysetrenie(_objednavkaId);

            var responseString = await response.Content.ReadAsStringAsync();
            var details = JObject.Parse(responseString);

            var message = details["message"]?.ToString() ?? "";
            var success = bool.Parse(details["success"]?.ToString() ?? "False");

            if (success)
            {
                var data = details["data"];

                PacientBlock.Text = data["menoPacienta"].ToObject<string>();
                AmbulanciaBlock.Text = data["ambulancia"].ToObject<string>();
                DoktorBlock.Text = data["menoDoktora"].ToObject<string>();
                RodneCisloBlock.Text = data["rodneCisloPacienta"].ToObject<long>().ToString();

                VysetrenieBlock.Text = data["nazovVysetrenia"].ToObject<String>();

                bool potvrdene = data["potvrdeneDoktorom"].ToObject<bool>();
                if (potvrdene)
                {
                    StavObjednavkyBlock.Text = "Potvrdené doktorom";
                    ObjednanyTerminBlock.Text = data["objednanyTermin"].ToObject<DateTime>().ToString("dd.MM.yyyy HH:MM");
                }
                else
                {
                    StavObjednavkyBlock.Text = "Objednávka nepotvrdená";
                    ObjednanyTerminBlock.Text = "Neurčený dátum";
                }
            }
        }

        private void Objednaj(object sender, RoutedEventArgs e)
        {
            SetObjednavka();
        }

        private void PickedDate(object sender, RoutedEventArgs e)
        {
            GetCasy();
        }

        public async Task SetObjednavka()
        {
            string datum = DateFidget.SelectedDate.Value.ToString("yyyyMMdd");
            string cas = TimeFidget.Text;
            string dokopy = datum + cas;
            DateTime newTime = DateTime.ParseExact(dokopy,"yyyyMMddhh:mm", CultureInfo.InvariantCulture);

            Controller controller = Controller.Instance;
            var response = await controller.ObjednavkaSetTime(newTime,_objednavkaId);

            var responseString = await response.Content.ReadAsStringAsync();
            var details = JObject.Parse(responseString);

            var success = bool.Parse(details["success"]?.ToString() ?? "False");

            if (success)
            {
                this.Close();
                new ObjednavkaDetail(_objednavkaId).ShowDialog();
            }
        }

        public async Task GetCasy()
        {
            DateTime time = DateFidget.SelectedDate.Value;

            Controller controller = Controller.Instance;
            var response = await controller.GetCasyByDay(_objednavkaId, time);

            List<string> listofTimes = new List<string>();

            var responseString = await response.Content.ReadAsStringAsync();
            var details = JObject.Parse(responseString);

            var success = bool.Parse(details["success"]?.ToString() ?? "False");

            if (success)
            {
                listofTimes = details["data"].ToObject<List<string>>();
            }
            TimeFidget.ItemsSource = listofTimes;
        }
    }
}
