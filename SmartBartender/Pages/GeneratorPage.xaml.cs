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
    /// Логика взаимодействия для GeneratorPage.xaml
    /// </summary>
    public partial class GeneratorPage : Page
    {
        int count;
        public static Client CurrentClient;
        public GeneratorPage(Client currentClient)
        {
            CurrentClient = currentClient;
            InitializeComponent();
            BindingData();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var selectAlco = CBAlco.SelectedItem as Alcohol;
            var selectMood = CBMoodType.SelectedItem as MoodType;
            var selectTime = CBTimesOfDay.SelectedItem as TimesOfTheDay;
            var selectLevel = CBLevel.SelectedItem as LevelType;
            if (CBAlco.SelectedIndex == -1 || CBLevel.SelectedIndex == -1 || CBMoodType.SelectedIndex == -1 || CBTimesOfDay.SelectedIndex ==-1)
            {
                MessageBox.Show("выберите все значения");
            }
            else
            {
                var getParams = ParametersDataBaseMethods.GetParameter(selectAlco.id, selectMood.id, selectTime.id, selectLevel.id);
                count = ParametersDataBaseMethods.RandomCount(getParams.MoodType.id, getParams.LevelType.id);
                ParametersDataBaseMethods.HistoryDrop(getParams, CurrentClient, count);
                MessageBox.Show($"вам выпал {getParams.Alcohol.Name} в количестве {count}");
                txtDescrition.Text = getParams.Descrition;
                this.DataContext = getParams;
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
