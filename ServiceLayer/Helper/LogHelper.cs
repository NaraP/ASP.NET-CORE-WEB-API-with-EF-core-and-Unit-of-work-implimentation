using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Helper
{
    public static class LogHelper
    {
        public static LogEventLevel GetLoggingType(string errorConfig)
        {
            LogEventLevel logEventLevel = LogEventLevel.Error;

            switch (errorConfig)
            {
                case "Debug":
                    logEventLevel = LogEventLevel.Debug;
                    break;

                case "Error":
                    logEventLevel = LogEventLevel.Error;
                    break;

                case "Fatal":
                    logEventLevel = LogEventLevel.Fatal;
                    break;

                case "Information":
                    logEventLevel = LogEventLevel.Information;
                    break;

                case "Verbose":
                    logEventLevel = LogEventLevel.Verbose;
                    break;

                case "Warning":
                    logEventLevel = LogEventLevel.Warning;
                    break;
            }
            return logEventLevel;

        }
    }
}
