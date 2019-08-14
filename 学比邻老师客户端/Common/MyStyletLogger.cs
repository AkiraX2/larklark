using System;
using NLog;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    class MyStyletLogger : Stylet.Logging.ILogger
    {
        private Logger logger;
        public MyStyletLogger(string loggerName)
        {

            logger = NLog.LogManager.GetLogger(loggerName);
        }

        public void Error(Exception exception, string message = null)
        {
            logger.Error(exception, message);
        }

        public void Info(string format, params object[] args)
        {
            logger.Debug(format, args);
        }

        public void Warn(string format, params object[] args)
        {
            logger.Warn(format, args);
        }
    }
}
