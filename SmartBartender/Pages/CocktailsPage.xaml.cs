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
    /// Логика взаимодействия для CocktailsPage.xaml
    /// </summary>
    public partial class CocktailsPage : Page
    {
        public static Alcohol Alcohol;
        public CocktailsPage(Alcohol alcohol)
        {
            Alcohol = alcohol;
            InitializeComponent();
            if (Alcohol == null)
            {
                BindingData();
            }
            else
                itemsControl.ItemsSource = AlcoDataBaseMethods.GetAlcohol(alcohol.Name).ToList();

        }
        private void BindingData()
        {
            itemsControl.ItemsSource = AlcoDataBaseMethods.GetActiveAlcohol();
        }

        private void WrapPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Random rnd = new Random();
            MessageBox.Show($"Code: {rnd.Next(100, 900)}");
        }
    }
}
