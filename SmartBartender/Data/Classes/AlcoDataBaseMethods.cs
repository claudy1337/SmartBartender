using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartBartender.Data.Classes;
using SmartBartender.Data.Model;

namespace SmartBartender.Data.Classes
{
    internal class AlcoDataBaseMethods
    {
        public static ObservableCollection<Alcohol> GetAlcohols()
        {
            return new ObservableCollection<Alcohol>(DataBaseConnection.connection.Alcohol);
        }
        public static IEnumerable<Alcohol> GetAlcohol()
        {
            return GetAlcohols().ToList();
        }
        public static IEnumerable<Alcohol> GetAlcohol(string name)
        {
            return GetAlcohols().Where(a => a.isActive == true && a.Name == name).ToList();
        }
        public static IEnumerable<Alcohol> GetAlcohol(int price)
        {
            return GetAlcohols().Where(a => a.isActive == true && a.Price == price).ToList();
        }
        public static IEnumerable<Alcohol> GetAlcohol(string name, int price)
        {
            return GetAlcohols().Where(a => a.isActive == true && a.Price == price && a.Name == name).ToList();
        }
        public void AddAlco()
        {

        }
    }
}
