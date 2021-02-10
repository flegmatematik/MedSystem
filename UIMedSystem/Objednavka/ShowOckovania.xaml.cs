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
    public partial class ShowOckovania
    {
        public ShowOckovania() 
        {
            InitializeComponent();

            LoadData();
        }

        private async Task LoadData()
        {
            Controller controller = Controller.Instance;
            var response = await controller.GetHistoriaOckovani();

            var responseString = await response.Content.ReadAsStringAsync();
            var details = JObject.Parse(responseString);

            GreetBox.Text = $"História pacienta {controller.User.CeleMeno}";

            bool success = details["success"].ToObject<bool>();

            if (success)
            {
                var list = details["data"].ToObject<List<ObjednavkaHistory>>();

                if (list != null && list.Count > 0)
                {
                    foreach (var objednavka in list)
                    {
                        this.ListedOckovania.Items.Add(objednavka);
                    }
                }
                else
                {
                    OckovaniaLabel.Text = "Zdá sa, že vaša história je prázdna";
                    ListedOckovania.Visibility = Visibility.Hidden;
                }
            }
        }
    }
}
