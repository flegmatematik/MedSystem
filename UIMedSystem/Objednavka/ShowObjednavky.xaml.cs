using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json.Linq;
using UIMedSystem.ContainerItems;
using UIMedSystem.Controllers;

namespace UIMedSystem.Objednavka
{
    /// <summary>
    /// Interaction logic for ShowObjednavky.xaml
    /// </summary>
    public partial class ShowObjednavky
    {
        public ShowObjednavky() 
        {
            InitializeComponent();

            LoadApprovedApps();
            LoadUnapprovedApps();
            LoadHistoryApps();
        }

        private async Task LoadHistoryApps()
        {
            Controller controller = Controller.Instance;
            var response = await controller.GetHistoriaVysetreni();

            var responseString = await response.Content.ReadAsStringAsync();
            var details = JObject.Parse(responseString);

            GreetBlock.Text = $"História pacienta {controller.User.CeleMeno}";

            bool success = details["success"].ToObject<bool>();

            if (success)
            {
                var list = details["data"].ToObject<List<ObjednavkaHistory>>();

                if (list != null && list.Count > 0)
                {
                    foreach (var objednavka in list)
                    {
                        this.PastApps.Items.Add(objednavka);
                    }
                }
                else
                {
                    PastAppsLabel.Text = "Zdá sa, že vaša história je prázdna";
                    PastApps.Visibility = Visibility.Hidden;
                }
            }
        }


        private async Task LoadUnapprovedApps()
        {
            Controller controller = Controller.Instance;
            var response = await controller.GetVysetreniaNeobjednane();

            var responseString = await response.Content.ReadAsStringAsync();
            var details = JObject.Parse(responseString);

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
