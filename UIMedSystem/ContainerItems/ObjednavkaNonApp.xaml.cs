using System.Windows;
using System.Windows.Controls;
using UIMedSystem.Objednavka;

namespace UIMedSystem.ContainerItems
{
    /// <summary>
    /// Interaction logic for ObjednavkaNonApp.xaml
    /// </summary>
    public partial class ObjednavkaNonApp
    {
        private readonly int _objednavkaId;
        public ObjednavkaNonApp(int id, string menoPacienta, string nazovVysetrenia, string ambulancia)
        {
            InitializeComponent();

            _objednavkaId = id;

            this.PacientBox.Text = menoPacienta;
            this.AppTypeBox.Text = nazovVysetrenia;
            this.ObjednavkaStavBox.Text = ambulancia;
        }

        private void ShowDetailObjednavka(object sender, RoutedEventArgs e)
        {
            new ObjednavkaObjednat(_objednavkaId).ShowDialog();
        }
    }
}
