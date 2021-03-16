using _1.LoggerSOLID.Enums;
using LoggerSOLID.Appenders;
using LoggerSOLID.Layouts;
using LoggerSOLID.Loggers;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerSOLID.Core.Factories
{
    public class AppenderFactory : IAppenderFactory
    {
        public IAppender CreateAppender(string type, ILayout layout, ReportLevel reportLevel)
        {
            IAppender appender = null;
            switch (type)
            {
                case nameof(ConsoleAppender):
                    appender = new ConsoleAppender(layout)
                    {
                        ReportLevel = reportLevel
                    };
                    break;
                case nameof(FileAppender):
                    appender = new FileAppender(layout, new LogFile())
                    {
                        ReportLevel = reportLevel
                    };
                    break;
                default:
                    throw new ArgumentException($"{type} is invalid Appender type.");

            }
            return appender;
        }
    }
}
