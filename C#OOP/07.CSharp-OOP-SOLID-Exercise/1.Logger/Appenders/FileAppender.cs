using _1.LoggerSOLID.Enums;
using LoggerSOLID.Layouts;
using LoggerSOLID.Loggers;
using System;

namespace LoggerSOLID.Appenders
{
    public class FileAppender : Appender
    {
        private readonly ILogFile logFile;
        public FileAppender(ILayout layout, ILogFile logFile)
            : base(layout)
        {
            this.logFile = logFile;
        }
        public override void Append(string date, ReportLevel reportLevel, string message)
        {
            if (!CanAppend(reportLevel))
            {
                return;
            }

            MessagessCount += 1;

            string content = string.Format(layout.Template, date, reportLevel, message) + Environment.NewLine;
            logFile.Write(content);
        }
        public override string ToString()
        {
            return base.ToString() + $", File size: {logFile.Size}";
        }
    }
}
