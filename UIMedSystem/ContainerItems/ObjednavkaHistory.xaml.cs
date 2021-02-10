using System;
using System.Windows;
using System.Windows.Controls;
using UIMedSystem.Objednavka;

namespace UIMedSystem.ContainerItems
{
    /// <summary>
    /// Interaction logic for ObjednavkaItem.xaml
    /// </summary>
    public partial class ObjednavkaHistory : UserControl
    {
        private readonly int _objednavkaId;
        public ObjednavkaHistory(int id, string menoPacienta, string nazovVysetrenia, DateTime objednanyTermin)
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
