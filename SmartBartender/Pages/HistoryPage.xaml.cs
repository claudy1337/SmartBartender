using SmartBartender.Data.Classes;
using SmartBartender.Data.Model;
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

namespace SmartBartender.Pages
{
    /// <summary>
    /// Логика взаимодействия для HistoryPage.xaml
    /// </summary>
    public partial class HistoryPage : Page
    {
        public static Client CurrentClient;
        public HistoryPage(Client currentClient)
        {
            CurrentClient = currentClient;
            InitializeComponent();
            BindData();
            if (ClientDataBaseMethods.GetAdminRole(CurrentClient.Authorization.Login) == false)
                CBClient.Visibility = Visibility.Hidden;
            else
                BindingDataForAdmin();
        }
        private void CBAlco_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectAlco = CBAlco.SelectedItem as Alcohol;
            var selectClient = CBClient.SelectedItem as Client;
            if (ClientDataBaseMethods.GetAdminRole(CurrentClient.Authorization.Login) == false)
            {
                lstvDropHistory.ItemsSource = DataBaseConnection.connection.DropHistory.Where(d => d.Client.id == CurrentClient.id && d.Parameters.Alcohol.id ==selectAlco.id).ToList();
            }
            else if (CBClient.SelectedIndex == -1 && ClientDataBaseMethods.GetAdminRole(CurrentClient.Authorization.Login) == true)
            {
                lstvDropHistory.ItemsSource = DataBaseConnection.connection.DropHistory.Where(d =>d.Parameters.Alcohol.id == selectAlco.id).ToList();
            }
            else
            {
                lstvDropHistory.ItemsSource = DataBaseConnection.connection.DropHistory.Where(d => d.Client.id == selectClient.id && d.Parameters.Alcohol.id == selectAlco.id).ToList();
            }
        }
        private void BindingDataForAdmin()
        {
            CBClient.ItemsSource = DataBaseConnection.connection.Client.ToList();
            
        }
        private void BindData()
        {
            CBAlco.ItemsSource = DataBaseConnection.connection.Alcohol.ToList();
            lstvDropHistory.ItemsSource = DataBaseConnection.connection.DropHistory.Where(d=>d.Client.id == CurrentClient.id).ToList();
        }

        private void CBClient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectAlco = CBAlco.SelectedItem as Alcohol;
            var selectClient = CBClient.SelectedItem as Client;
            if(CBAlco.SelectedIndex == -1)
            {
                lstvDropHistory.ItemsSource = DataBaseConnection.connection.DropHistory.Where(d => d.Client.id == selectClient.id).ToList();
            }
            else
            {
                lstvDropHistory.ItemsSource = DataBaseConnection.connection.DropHistory.Where(d => d.Client.id == selectClient.id && d.Parameters.Alcohol.id == selectAlco.id).ToList();
            }
        }
    }
}
