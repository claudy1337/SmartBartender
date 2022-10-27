using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartBartender.Data.Model;

namespace SmartBartender.Data.Classes
{
    internal class DataBaseConnection
    {
        public static SmartBartenderEntities connection = new SmartBartenderEntities();
    }
}
