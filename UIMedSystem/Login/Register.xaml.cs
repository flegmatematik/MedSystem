using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Newtonsoft.Json.Linq;
using UIMedSystem.Controllers;

namespace UIMedSystem.Login
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : UserControl
    {
        public Register()
        {
            InitializeComponent();
        }

        private async void RegisterAction(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(EmailBox.Text) || 
                String.IsNullOrWhiteSpace(PasswordBox.Password) || 
                String.IsNullOrWhiteSpace(PasswordBoxRepeat.Password) ||
                String.IsNullOrWhiteSpace(RodneCisloBox.Text) ||
                String.IsNullOrWhiteSpace(CeleMenoBox.Text)||
                String.IsNullOrWhiteSpace(AdresaBox.Text))
            {
                ErrorBox.Content = "Všetky položky musia byť vyplnené";
                ErrorBox.Visibility = Visibility.Visible;
            }
            else if (!EmailBox.Text.Contains("@"))
            {
                ErrorBox.Content = "Váš email musí byť v správnom fomáte.";
                ErrorBox.Visibility = Visibility.Visible;
            }
            else if (PasswordBox.Password != PasswordBoxRepeat.Password)
            {
                ErrorBox.Content = "Heslo, a zopakované heslo sa nezhodujú.";
                ErrorBox.Visibility = Visibility.Visible;
            }
            else if(RodneCisloBox.Text.Length != 10 || !long.TryParse(RodneCisloBox.Text, out _))
            {
                ErrorBox.Content = "Rodné číslo nieje v správnom tvare.";
                ErrorBox.Visibility = Visibility.Visible;
            }
            else
            {
                var response = await Controller.Instance.Register(EmailBox.Text,
                    PasswordBox.Password,
                    long.Parse(RodneCisloBox.Text),
                    CeleMenoBox.Text,
                    AdresaBox.Text);


                var responseString = await response.Content.ReadAsStringAsync();
                var details = JObject.Parse(responseString);

                var message = details["message"]?.ToString() ?? "";
                var success = bool.Parse(details["success"]?.ToString() ?? "False");

                if (success)
                {
                    ErrorBox.Content = "úspešne zaregistrovaný";
                    ErrorBox.Background = Brushes.LawnGreen;
                    ErrorBox.Visibility = Visibility.Visible;

                    Content = new Login();
                }
                else
                {
                    ErrorBox.Content = message;
                    ErrorBox.Visibility = Visibility.Visible;
                }
            }

            
        }
    }
}
