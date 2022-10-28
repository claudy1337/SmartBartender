using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SmartBartender.Data.Classes;
using SmartBartender.Data.Model;
using SmartBartender.Pages;
using SmartBartender.Windws;

namespace SmartBartender
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Client CurrentClient;
        public static Alcohol alcohol;
        public MainWindow(Client currentClient)
        {
            CurrentClient = currentClient;
            InitializeComponent();
            if (ClientDataBaseMethods.GetAdminRole(currentClient.Authorization.Login) == false)
            {
                txtAdmin.Visibility = Visibility.Hidden;
                btnGenerator.Visibility = Visibility.Hidden;
                btnSupplyOfAlcohol.Visibility = Visibility.Hidden;
            }
            txtName.Text = "Welcome: " + CurrentClient.Name;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (e.ChangedButton == MouseButton.Left)
                    this.DragMove();
            }
            catch (System.InvalidOperationException)
            {
                return;
            }
        }

        private void PIMinus_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void PIClose_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void btnAccount_Click(object sender, RoutedEventArgs e)
        {
            FramePageContainer.Navigate(new AccountPage(CurrentClient));
        }
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Auth auth = new Auth();
            auth.Show();
            this.Close();
        }

        private void btnSupplyOfAlcohol_Click(object sender, RoutedEventArgs e)
        {
            FramePageContainer.Navigate(new SupplyOfAlcoholPage());
        }

        private void btnGenerator_Click(object sender, RoutedEventArgs e)
        {
            FramePageContainer.Navigate(new CreateGeneratorPage());
        }

        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {
            FramePageContainer.Navigate(new CocktailsPage(alcohol));
        }

        private void btnOpenGenerator_Click(object sender, RoutedEventArgs e)
        {
            FramePageContainer.Navigate(new GeneratorPage(CurrentClient));
        }

        private void btnHistory_Click(object sender, RoutedEventArgs e)
        {
            FramePageContainer.Navigate(new HistoryPage(CurrentClient));
        }
    }
}
