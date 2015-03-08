using System;

namespace Neemo.Web.Infrastructure
{
    public class Log4NetLog : ILogger
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void Error(string message)
        {
            log.Error(message);
        }

        public void Error(string message, Exception exception)
        {
            log.Error(message, exception);
        }

        public void Info(string message)
        {
            log.Info(message);
        }
    }
}
