using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;

namespace Vueling.Common.Layer
{
    public static class VuelingLogger
    {
        public static void Logger(Exception ex)
        {
            Log.Logger = new LoggerConfiguration()
                    .WriteTo.File(ConfigurationManager.AppSettings.Get("Error"))
                    .CreateLogger();
            Log.Error(ex.Message +" "+ ex.InnerException.Message + ex.StackTrace);
        }

    }
}
