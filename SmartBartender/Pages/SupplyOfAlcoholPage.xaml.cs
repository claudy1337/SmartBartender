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
namespace SmartBartender.Pages
{
    /// <summary>
    /// Логика взаимодействия для SupplyOfAlcoholPage.xaml
    /// </summary>
    public partial class SupplyOfAlcoholPage : Page
    {
        public SupplyOfAlcoholPage()
        {
            InitializeComponent();
            BindingData();
        }

        private void btnEditAccount_Click(object sender, RoutedEventArgs e)
        {
            Alcohol alcohol = new Alcohol();
            NavigationService.Navigate(new AddAlcoPage(alcohol));
        }
        private void BindingData()
        {
            lstvAlco.ItemsSource = AlcoDataBaseMethods.GetAlcohol();
        }

        private void txtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                string price = txtPrice.Text;
                if (string.IsNullOrWhiteSpace(txtPrice.Text))
                    lstvAlco.ItemsSource = AlcoDataBaseMethods.GetAlcohol(txtName.Text);
                else
                    lstvAlco.ItemsSource = AlcoDataBaseMethods.GetAlcohol(txtName.Text, Convert.ToInt32(txtPrice.Text));
            }
            catch(FormatException)
            {
                return;
            }
        }

        private void txtPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtName.Text))
                    lstvAlco.ItemsSource = AlcoDataBaseMethods.GetAlcohol(Convert.ToInt32(txtPrice.Text));
                else
                    lstvAlco.ItemsSource = AlcoDataBaseMethods.GetAlcohol(txtName.Text, Convert.ToInt32(txtPrice.Text));
            }
            catch(FormatException)
            {
                return;
            }
        }

        private void txtClear_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new SupplyOfAlcoholPage());
        }

        private void lstvAlco_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectAlco = lstvAlco.SelectedItem as Alcohol;
            NavigationService.Navigate(new AddAlcoPage(selectAlco));
        }
    }
}
