using _1.LoggerSOLID.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerSOLID.Appenders
{
    public interface IAppender
    {
        public ReportLevel ReportLevel { get; set; }
        public void Append(string date, ReportLevel reportLevel, string message);
    }
}
