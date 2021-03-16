using _1.LoggerSOLID.Enums;
using LoggerSOLID.Layouts;
using System;

namespace LoggerSOLID.Appenders
{
    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout)
            : base(layout) 
        { }
        public override void Append(string date, ReportLevel reportLevel, string message)
        {
            if(!CanAppend(reportLevel))
            {
                return;
            }

            MessagessCount += 1;

            string content = string.Format(layout.Template, date, reportLevel, message);
            Console.WriteLine(content);
        }
    }
}
