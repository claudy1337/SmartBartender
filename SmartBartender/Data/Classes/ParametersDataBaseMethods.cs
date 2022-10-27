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
        public static void HistoryDrop(Parameters parameters, Client client, int count)
        {
            var getParameter = GetParameter(parameters.Alcohol.id, parameters.MoodType.id, parameters.TimesOfTheDay.id, parameters.LevelType.id);
            DropHistory dropHistory = new DropHistory
            {
                idParameters = getParameter.id,
                Price = getParameter.Alcohol.Price,
                DateDrop = DateTime.Now,
                idClient = client.id,
                Count = count

            };
            DataBaseConnection.connection.DropHistory.Add(dropHistory);
            DataBaseConnection.connection.SaveChanges();
        }
        public static int RandomCount(int mood, int level)
        {
            Random rnd = new Random();
            int value;
            if (level>4 && mood>2)
            {
                return value = rnd.Next(4, 6);
            }
            else
            {
                return value = rnd.Next(1, 5);
            }
            
            
        }
    }
}
