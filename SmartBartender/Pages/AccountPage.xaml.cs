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
using SmartBartender.Data.Model;
using SmartBartender.Data.Classes;

namespace SmartBartender.Pages
{
    /// <summary>
    /// Логика взаимодействия для AccountPage.xaml
    /// </summary>
    public partial class AccountPage : Page
    {
        public static Client CurrentClient;
        public AccountPage(Client currentClient)
        {
            CurrentClient = currentClient;
            InitializeComponent();
            BindingData();
        }
        private void BindingData()
        {
            if (CurrentClient.Gender == null)
            {

            }
            else
                CBGender.SelectedIndex = CurrentClient.Gender1.id;
            CBGender.ItemsSource = DataBaseConnection.connection.Gender.ToList();
            if (CurrentClient.Image == null)
                imgAccount.Source = new BitmapImage(new Uri("/Resources/user.png", UriKind.RelativeOrAbsolute));
            else
                this.DataContext = CurrentClient;

            this.DataContext = CurrentClient;
        }

        private void imgAccount_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ClientDataBaseMethods.EditImageClient(CurrentClient);
            NavigationService.Navigate(new AccountPage(CurrentClient));
        }

        private void btnEditAccount_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtAge.Text) || string.IsNullOrEmpty(txtName.Text) || CBGender.SelectedIndex == -1)
                {
                    MessageBox.Show("заполните все поля");
                }
                else
                {
                    var selectGender = CBGender.SelectedItem as Gender;
                    ClientDataBaseMethods.EditClient(CurrentClient, Convert.ToInt32(txtAge.Text), txtName.Text, selectGender.id);
                }
            }
            catch(FormatException)
            {
                return;
            }
        }
    }
}
