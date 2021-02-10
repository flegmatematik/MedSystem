using System;
using System.Windows;
using UIMedSystem.Objednavka;

namespace UIMedSystem.ContainerItems
{
    /// <summary>
    /// Interaction logic for ObjednavkaItem.xaml
    /// </summary>
    public partial class ObjednavkaApproved
    {
        private readonly int _objednavkaId;

        public ObjednavkaApproved(int id, string menoPacienta, string nazovVysetrenia, DateTime objednanyTermin)
        {
            InitializeComponent();

            _objednavkaId = id;

            this.PacientBox.Text = menoPacienta;
            this.AppTypeBox.Text = nazovVysetrenia;
            this.ObjednavkaStavBox.Text = objednanyTermin.ToString("dd.MM.yyyy hh:mm");
            
        }

        private void ShowDetailObjednavka(object sender, RoutedEventArgs e)
        {
            new ObjednavkaDetail(_objednavkaId).ShowDialog();
        }
    }
}
