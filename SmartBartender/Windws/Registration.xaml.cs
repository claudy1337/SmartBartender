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
using System.Windows.Shapes;
using SmartBartender.Data.Model;
using SmartBartender.Data.Classes;

namespace SmartBartender.Windws
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public static Client Client;
        public Registration()
        {
            InitializeComponent();
        }

        private void btnRegistration_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtPassword.Password) || string.IsNullOrWhiteSpace(txtLogin.Text))
            {
                MessageBox.Show("заполните все поля");
            }
            else
            {
                if (ClientDataBaseMethods.IsCorrectClient(txtLogin.Text, txtPassword.Password) == false && 
                    ClientDataBaseMethods.GetAdminRole(txtLogin.Text) == false)
                {
                    ClientDataBaseMethods.AddAuthorization(txtLogin.Text, txtPassword.Password);
                    ClientDataBaseMethods.AddClient(txtName.Text);
                    Client = ClientDataBaseMethods.CurrentClient;
                    MainWindow main = new MainWindow(Client);
                    MessageBox.Show($"Welcome {Client.Name}");
                    main.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("пользователь уже существует");
                    Refresh();
                }
                   
            }
            
        }

        private void btnAuth_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Auth auth = new Auth();
            auth.Show();
            this.Close();
        }
        private void Refresh()
        {
            txtLogin.Text = null;
            txtName.Text = null;
            txtPassword.Password = null;
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
    }
}
