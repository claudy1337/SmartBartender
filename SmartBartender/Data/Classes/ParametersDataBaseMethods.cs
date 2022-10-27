using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartBartender.Data.Model;
using SmartBartender.Data.Classes;
using System.Collections.ObjectModel;
using System.Windows;

namespace SmartBartender.Data.Classes
{
    internal class ParametersDataBaseMethods
    {
        public static ObservableCollection<Parameters> GetParameters()
        {
            return new ObservableCollection<Parameters>(DataBaseConnection.connection.Parameters);
        }
        public static IEnumerable<Parameters> GetParameter()
        {
            return GetParameters().ToList();
        }
        public static Parameters GetParameter(int idalco, int idmood, int idtime, int idlevel)
        {
            return GetParameters().FirstOrDefault(p=>p.Alcohol.id == idalco && p.MoodType.id == idmood && p.TimesOfTheDay.id == p.idTimesOfDay && p.LevelType.id == idlevel);
        }
        public static void AddParameters(int idalco, int idmood, int idtime, int idlevel, string descrition, byte[] image)
        {
            var getParameter = GetParameter(idalco, idmood, idtime, idlevel);
            if (getParameter == null)
            {
                Parameters parameters = new Parameters
                {
                    idAlcohol = idalco,
                    idMoodType = idmood,
                    idLevelType = idlevel,
                    idTimesOfDay = idtime,
                    Descrition = descrition,
                    Image = image
                };
                DataBaseConnection.connection.Parameters.Add(parameters);
                DataBaseConnection.connection.SaveChanges();
                MessageBox.Show("конфигурация создана");
            }
            else
            {
                MessageBox.Show("такая конфигурация уже есть");
                return;
            }
        }
    }
}
