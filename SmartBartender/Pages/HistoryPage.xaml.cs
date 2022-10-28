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
            if (ClientDataBaseMethods.GetAdminRole(currentClient.Authorization.Login) == false)
            {

            }
        }
        private void BindingDataForAdmin()
        {
            
        }
        private void BindData()
        {
            lstvDropHistory.ItemsSource = DataBaseConnection.connection.DropHistory.Where(d=>d.Client.id == CurrentClient.id).ToList();
        }
    }
}
