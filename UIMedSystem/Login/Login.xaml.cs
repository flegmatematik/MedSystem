using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Newtonsoft.Json.Linq;
using UIMedSystem.Controllers;

namespace UIMedSystem.Login
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login
    {
        public Login()
        {
            InitializeComponent();
        }

        private async void LoginAction(object sender, RoutedEventArgs e)
        {
            Controller controller = Controller.Instance;
            var response = await controller.Login(EmailBox.Text,PasswordBox.Password);

            var responseString = await response.Content.ReadAsStringAsync();
            var details = JObject.Parse(responseString);

            var message = details["message"]?.ToString() ?? "";
            var success = bool.Parse(details["success"]?.ToString() ?? "False");

            if (success)
            {
                ErrorBox.Content = message;
                ErrorBox.Background = Brushes.LawnGreen;
                ErrorBox.Visibility = Visibility.Visible;

                Content = new Home.Home();
            }
            else
            {
                ErrorBox.Content = message;
                ErrorBox.Visibility = Visibility.Visible;
            }
        }
    }
}
