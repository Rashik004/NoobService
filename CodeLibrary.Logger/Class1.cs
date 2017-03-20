using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace CodeLibrary.Logger
{
    public class Logger
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static string _messageFormat = "{0} - {1}";

        public Logger()
        {

        }

        public static void ConfigLogger()
        {
            log4net.Config.XmlConfigurator.Configure(configFile: new FileInfo("log4net.config"));
        }

        public void Debug(string message,Exception ex = null)
        {
            _logger.Debug(ex == null ? message : String.Format(_messageFormat,message,ex));
        }

        public void Info(string message,Exception ex = null)
        {
            _logger.Info(ex == null ? message : String.Format(_messageFormat,message,ex));
        }

        public void Warn(string message,Exception ex = null)
        {
            _logger.Warn(ex == null ? message : String.Format(_messageFormat,message,ex));
        }

        public void Error(string message,Exception ex = null)
        {
            _logger.Error(ex == null ? message : String.Format(_messageFormat,message,ex));
        }

        public void Fatal(string message,Exception ex = null)
        {
            _logger.Fatal(ex == null ? message : String.Format(_messageFormat,message,ex));
        }
    }

}
