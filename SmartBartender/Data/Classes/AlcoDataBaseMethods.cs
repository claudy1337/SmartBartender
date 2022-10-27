using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SmartBartender.Data.Classes;
using SmartBartender.Data.Model;

namespace SmartBartender.Data.Classes
{
    internal class AlcoDataBaseMethods
    {
        public static ObservableCollection<Alcohol> GetAllAlcohol()
        {
            return new ObservableCollection<Alcohol>(DataBaseConnection.connection.Alcohol);
        }
        public static IEnumerable<Alcohol> GetAlcohol()
        {
            return GetAllAlcohol().ToList();
        }
        public static IEnumerable<Alcohol> GetAlcohol(string name)
        {
            return GetAllAlcohol().Where(a => a.Name == name).ToList();
        }
        public static IEnumerable<Alcohol> GetAlcohol(int price)
        {
            return GetAllAlcohol().Where(a => a.Price == price).ToList();
        }
        public static IEnumerable<Alcohol> GetAlcohol(string name, int price)
        {
            return GetAllAlcohol().Where(a => a.Name == name).ToList();
        }
        public static Alcohol GetCurrentAlcohol(string name)
        {
            return GetAllAlcohol().FirstOrDefault(a => a.Name == name);
        }
        public static void AddAlco(string SearchName, string name, int degrees, int price, int isactive, byte[] image)
        {
            var getAlco = GetCurrentAlcohol(SearchName);
            if (getAlco == null)
            {
                Alcohol alcohol = new Alcohol
                {
                    Name = name,
                    isActive = isactive,
                    StrengthDegrees = degrees,
                    Price = price,
                    Image = image
                };
                DataBaseConnection.connection.Alcohol.Add(alcohol);
                DataBaseConnection.connection.SaveChanges();
                MessageBox.Show("добавлен");
            }
            else
            {
                MessageBox.Show("уже существует");
            }
        }
        public static void EditAlco(Alcohol oldAlcohol, string name)
        {

        }
    }
}
