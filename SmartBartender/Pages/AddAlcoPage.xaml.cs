using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.Win32;
using SmartBartender.Data.Classes;
using SmartBartender.Data.Model;
using static System.Net.Mime.MediaTypeNames;

namespace SmartBartender.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddAlcoPage.xaml
    /// </summary>
    public partial class AddAlcoPage : Page
    {
        public static Alcohol CurrentAlcohol;
        byte[] image;
        public AddAlcoPage(Alcohol currentAlcohol)
        {
            CurrentAlcohol = currentAlcohol;
            InitializeComponent();
            if (CurrentAlcohol.Name == null || CurrentAlcohol.Price == null || CurrentAlcohol.StrengthDegrees == null)
            {
                isNullData();
            }
            else
            {
                isNotNullData();
            }
            CBIsActive.ItemsSource = DataBaseConnection.connection.isActive.ToList();
        }

        private void imgAlco_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FilterIndex = 1;
            if (ofd.ShowDialog() == true)
            {
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.UriSource = new Uri(ofd.FileName);
                bitmapImage.EndInit();
                imgAlco.Source = bitmapImage;
                image = File.ReadAllBytes(ofd.FileName);
            }
        }

        private void btnEditOrAddAlco_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtPrice.Text) || string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtStrengthDegrees.Text)
                    || CBIsActive.SelectedIndex == -1)
                {
                    MessageBox.Show("заполните все поля");
                }
                else
                {
                    if (CurrentAlcohol.Name == null || CurrentAlcohol.Price == null || CurrentAlcohol.StrengthDegrees == null)
                    {
                        var selectActive = CBIsActive.SelectedItem as isActive;
                        AlcoDataBaseMethods.AddAlco(txtName.Text, txtName.Text, Convert.ToInt32(txtStrengthDegrees.Text), Convert.ToInt32(txtPrice.Text), selectActive.id, image);
                        NavigationService.Navigate(new SupplyOfAlcoholPage());
                    }
                    else
                    {

                    }
                }
            }
            catch(FormatException)
            {
                MessageBox.Show("не корректный формат");
                return;
            }
            
        }
        private void isNotNullData()
        {
            this.DataContext = CurrentAlcohol;
            CBIsActive.SelectedIndex = CurrentAlcohol.isActive1.id;
            btnEditOrAddAlco.Content = "Edit";
        }
        private void isNullData()
        {
            btnEditOrAddAlco.Content = "Add";            
        }
    }
}
