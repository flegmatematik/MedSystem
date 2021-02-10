using System.Windows;
using UIMedSystem.Controllers;
using UIMedSystem.Objednavka;

namespace UIMedSystem
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        public Main()
        {
            InitializeComponent();

            DynamicContent.Content = new Welcome.Welcome();

        }

        private void Close(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void RedirectHome(object sender, RoutedEventArgs e)
        {
            Controller controller = Controller.Instance;

            if (controller.LoggedIn())
            {
                DynamicContent.Content = new Home.Home();
            }
            else
            {
                DynamicContent.Content = new Welcome.Welcome();
            }
        }

        private void RedirectWelcome(object sender, RoutedEventArgs e)
        {
            Controller controller = Controller.Instance;

            if (controller.LoggedIn())
            {
                controller.Logout();
                DynamicContent.Content = new Welcome.Welcome();
            }
            else
            {
                DynamicContent.Content = new Login.Login();
            }
           
        }

        private void RedirectApps(object sender, RoutedEventArgs e)
        {
            Controller controller = Controller.Instance;

            if (controller.LoggedIn())
            {
                DynamicContent.Content = new ShowObjednavky();
            }
            else
            {
                DynamicContent.Content = new Login.Login();
            }

        }

        private void RedirectOckovanie(object sender, RoutedEventArgs e)
        {
            Controller controller = Controller.Instance;

            if (controller.LoggedIn())
            {
                DynamicContent.Content = new ShowOckovania();
            }
            else
            {
                DynamicContent.Content = new Login.Login();
            }
        }
    }
}
