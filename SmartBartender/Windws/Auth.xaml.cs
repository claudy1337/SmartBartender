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
using SmartBartender.Data.Classes;
using SmartBartender.Data.Model;

namespace SmartBartender.Windws
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Window
    {
        public static Client CurrentClient;
        public Auth()
        {
            InitializeComponent();
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

        private void btnAuth_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLogin.Text) || string.IsNullOrWhiteSpace(txtPassword.Password))
            {
                MessageBox.Show("заполните все поля");
                return;
            }
            else
            {
                if (ClientDataBaseMethods.IsCorrectClient(txtLogin.Text, txtPassword.Password))
                {
                    CurrentClient = ClientDataBaseMethods.GetClient(txtLogin.Text, txtPassword.Password);
                    MainWindow main = new MainWindow(CurrentClient);
                    main.Show();
                    this.Close();
                }
                else
                    MessageBox.Show("неверный логин или пароль");

            }
        }

        private void txtReg_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            this.Close();
        }
    }
}
