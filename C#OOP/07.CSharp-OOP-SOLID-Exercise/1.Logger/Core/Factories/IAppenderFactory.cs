using _1.LoggerSOLID.Enums;
using LoggerSOLID.Appenders;
using LoggerSOLID.Layouts;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerSOLID.Core.Factories
{
    public interface IAppenderFactory
    {
        IAppender CreateAppender(string type, ILayout layout, ReportLevel reportLevel);
    }
}
