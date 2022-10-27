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
    /// Логика взаимодействия для AddAlcoPage.xaml
    /// </summary>
    public partial class AddAlcoPage : Page
    {
        public static Alcohol CurrentAlcohol;
        public AddAlcoPage(Alcohol currentAlcohol)
        {
            CurrentAlcohol = currentAlcohol;
            InitializeComponent();
        }

        private void imgAlco_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void btnEditOrAddAlco_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
