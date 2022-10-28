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

namespace SmartBartender.Pages
{
    /// <summary>
    /// Логика взаимодействия для CreateGeneratorPage.xaml
    /// </summary>
    public partial class CreateGeneratorPage : Page
    {
        byte[] image;
        public CreateGeneratorPage()
        {
            InitializeComponent();
            BindingData();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescrition.Text) || CBAlco.SelectedIndex == -1 || CBLevel.SelectedIndex == -1 ||
                CBMoodType.SelectedIndex == -1 || CBTimesOfDay.SelectedIndex == -1)
            {
                MessageBox.Show("есть пустые значения");
            }
            else
            {
                var selectAlco = CBAlco.SelectedItem as Alcohol;
                var selectMood = CBMoodType.SelectedItem as MoodType;
                var selectLevel = CBLevel.SelectedItem as LevelType;
                var selectTime = CBTimesOfDay.SelectedItem as TimesOfTheDay;
                ParametersDataBaseMethods.AddParameters(selectAlco.id, selectMood.id, selectTime.id, selectLevel.id, txtDescrition.Text, image);
                NavigationService.Navigate(new CreateGeneratorPage());
            }
            
        }

        private void imgParametrs_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FilterIndex = 1;
            if (ofd.ShowDialog() == true)
            {
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.UriSource = new Uri(ofd.FileName);
                bitmapImage.EndInit();
                imgParametrs.Source = bitmapImage;
                image = File.ReadAllBytes(ofd.FileName);
            }
        }
        private void BindingData()
        {
            CBAlco.ItemsSource = DataBaseConnection.connection.Alcohol.Where(a=>a.isActive1.id == 1).ToList();
            CBLevel.ItemsSource = DataBaseConnection.connection.LevelType.ToList();
            CBMoodType.ItemsSource = DataBaseConnection.connection.MoodType.ToList();
            CBTimesOfDay.ItemsSource = DataBaseConnection.connection.TimesOfTheDay.ToList();
        }
    }
}
