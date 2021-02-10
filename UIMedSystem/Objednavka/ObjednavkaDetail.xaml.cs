using System;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json.Linq;
using UIMedSystem.Controllers;

namespace UIMedSystem.Objednavka
{
    /// <summary>
    /// Interaction logic for ObjednavkaDetail.xaml
    /// </summary>
    public partial class ObjednavkaDetail : Window
    {
        public ObjednavkaDetail(int idObjednavky)
        {
            InitializeComponent();

            LoadData(idObjednavky);
        }

        public async Task LoadData(int idObjednavky)
        {
            Controller controller = Controller.Instance;

            var response = await controller.GetVysetrenie(idObjednavky);

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
                    ObjednanyTerminBlock.Text = data["objednanyTermin"].ToObject<DateTime>().ToString("dd.MM.yyyy hh:mm");
                }
                else
                {
                    StavObjednavkyBlock.Text = "Objednávka nepotvrdená";
                    if (data["objednanePacientom"].ToObject<bool>())
                    {
                        ObjednanyTerminBlock.Text = data["objednanyTermin"].ToObject<DateTime>().ToString("dd.MM.yyyy hh:mm");
                    }
                    else
                    {
                        ObjednanyTerminBlock.Text = "Neobjednané vyšetrenie";
                    }
                }
                    



            }
        }
    }
}
