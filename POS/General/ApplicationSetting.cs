using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace POS.General
{
    public class ApplicationSetting
    {
        public static string ConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["ConnctionPOS"].ConnectionString;
        }
}
}
