using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;
using SmartBartender.Data.Model;
namespace SmartBartender.Data.Classes
{
    internal class ClientDataBaseMethods
    {
        public static Client CurrentClient;
        public static Model.Authorization CurrentAuthorization;
        public static bool IsCorrectClient(string login, string password)
        {
            ObservableCollection<Client> client = new ObservableCollection<Client>(DataBaseConnection.connection.Client);
            var currentUser = client.Where(u => u.Authorization.Login == login && u.Authorization.Password == password).FirstOrDefault();
            return currentUser != null;
        }
        public static ObservableCollection<Client> GetClients()
        {
            return new ObservableCollection<Client>(DataBaseConnection.connection.Client);
        }
        public static Client GetClient(string login, string password)
        {
            return GetClients().FirstOrDefault(x => x.Authorization.Login == login && x.Authorization.Password == password);
        }
        public static bool GetAdminRole(string login)
        {
            ObservableCollection<Client> admin = new ObservableCollection<Client>(DataBaseConnection.connection.Client);
            var currentAdmin = admin.Where(a => a.Authorization.Login == login && a.idRole == 1).FirstOrDefault();
            return currentAdmin != null;
        }
        public static void AddAuthorization(string login, string password)
        {
            var getadminrole = GetAdminRole(login);
            var getclient = GetClient(login, password);
            if (getadminrole == false && getclient == null)
            {
                Model.Authorization authorization = new Model.Authorization
                {
                    Login = login,
                    Password = password
                };
                CurrentAuthorization = authorization;
                DataBaseConnection.connection.Authorization.Add(authorization);
                DataBaseConnection.connection.SaveChanges();
            }
            else
            {
                MessageBox.Show("пользователь уже существует");
            }
        }
        public static void AddClient(string name, int role = 2)
        {
                if (CurrentAuthorization != null)
                {
                    Client client = new Client
                    {
                        idAuthorization = CurrentAuthorization.id,
                        Name = name,
                        idRole = role
                    };
                    CurrentClient = client;
                    DataBaseConnection.connection.Client.Add(client);
                    DataBaseConnection.connection.SaveChanges();
                }
                else
                {
                    return;
                }
        }
        public static void EditClient(Client oldCLient, int age, string name, int gender)
        {
            var getClient = GetClient(oldCLient.Authorization.Login, oldCLient.Authorization.Password);
            if (getClient != null && age >= 18)
            {
                getClient.Age = age;
                getClient.Name = name;
                getClient.Gender = gender;
                DataBaseConnection.connection.SaveChanges();
                MessageBox.Show("данные успешно поменялись");
            }
            else
            {
                MessageBox.Show("возраст меньше 18");
                return;
            }
        }
        public static void EditImageClient(Client oldClient)
        {
            var getuser = GetClient(oldClient.Authorization.Login, oldClient.Authorization.Password);
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog().GetValueOrDefault())
            {
                getuser.Image = File.ReadAllBytes(openFileDialog.FileName);
            }
            DataBaseConnection.connection.SaveChanges();
        }
        
        
    }
}
