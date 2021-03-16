using _1.LoggerSOLID.Enums;
using LoggerSOLID.Appenders;
using System.Text;

namespace LoggerSOLID.Loggers
{
    public class Logger : ILogger
    {
        private readonly IAppender[] appenders;

        public Logger(params IAppender[] appenders)
        {
            this.appenders = appenders;
        }
        public void Info(string date, string message)
        {
            AppendToAppender(date, ReportLevel.Info, message);
        }
        public void Warning(string date, string message)
        {
            AppendToAppender(date, ReportLevel.Warning, message);
        }
        public void Error(string date, string message)
        {
            AppendToAppender(date, ReportLevel.Error, message);
        }
        public void Fatal(string date, string message)
        {
            AppendToAppender(date, ReportLevel.Fatal, message);
        }
        public void Critical(string date, string message)
        {
            AppendToAppender(date, ReportLevel.Critical, message);
        }

        private void AppendToAppender(string date, ReportLevel reportLevel, string message)
        {
            foreach (IAppender appender in appenders)
            {
                appender.Append(date, reportLevel, message);
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach(IAppender appender in appenders)
            {
                sb.AppendLine(appender.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
