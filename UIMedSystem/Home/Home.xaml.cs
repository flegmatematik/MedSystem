using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json.Linq;
using UIMedSystem.ContainerItems;
using UIMedSystem.Controllers;

namespace UIMedSystem.Home
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : UserControl
    {
        public Home()
        {
            InitializeComponent();

            LoadApprovedApps();
            LoadUnapprovedApps();
        }

        private async Task LoadUnapprovedApps()
        {
            Controller controller = Controller.Instance;
            var response = await controller.GetVysetreniaNeobjednane();

            var responseString = await response.Content.ReadAsStringAsync();
            var details = JObject.Parse(responseString);

            GreetBlock.Text = $"Vitajte {controller.User.CeleMeno}";
            TimeBlock.Text = $"Dnes je {DateTime.Now.ToString("dd/MM/yyyy")}";

            bool success = details["success"].ToObject<bool>();

            if (success)
            {
                var list = details["data"].ToObject<List<ObjednavkaNonApp>>();

                if (list.Count != 0)
                {
                    foreach (var objednavka in list)
                    {
                        this.NonListedApps.Items.Add(objednavka);
                    }
                }
                else
                {
                    NonAppsLabel.Text = "Zdá sa, že všetky vaše objednávky sú naplánované";
                    NonListedApps.Visibility = Visibility.Hidden;
                }
            }
        }

        public async Task LoadApprovedApps()
        {
            Controller controller = Controller.Instance;
            var response = await controller.GetVysetreniaNextWeek();

            var responseString = await response.Content.ReadAsStringAsync();
            var details = JObject.Parse(responseString);

            bool success = details["success"].ToObject<bool>();

            if (success)
            {
                var list = details["data"].ToObject<List<ObjednavkaApproved>>();

                if (list.Count != 0)
                {
                    foreach (var objednavka in list)
                    {
                        this.ListedApps.Items.Add(objednavka);
                    }
                }
                else
                {
                    ListedAppsLabel.Text = "Zdá sa že nemáte žiadne naplánované objednávky";
                    ListedApps.Visibility = Visibility.Hidden;
                }
                
            }
        }
    }
}
