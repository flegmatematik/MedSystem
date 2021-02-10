using System.Windows;

namespace UIMedSystem.Welcome
{
    /// <summary>
    /// Interaction logic for Welcome.xaml
    /// </summary>
    public partial class Welcome
    {
        public Welcome()
        {
            InitializeComponent();
        }

        private void RedirectLogin(object sender, RoutedEventArgs e)
        {  
            Content = new Login.Login();
        }

        private void RedirectRegister(object sender, RoutedEventArgs e)
        {
            Content = new Login.Register();
        }
    }
}
