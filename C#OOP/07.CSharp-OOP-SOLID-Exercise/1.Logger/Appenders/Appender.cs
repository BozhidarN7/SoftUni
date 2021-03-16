using _1.LoggerSOLID.Enums;
using LoggerSOLID.Layouts;

namespace LoggerSOLID.Appenders
{
    public abstract class Appender : IAppender
    {
        protected readonly ILayout layout;
        public Appender(ILayout layout)
        {
            this.layout = layout;
        }

        protected int MessagessCount { get; set; }
        public ReportLevel ReportLevel { get; set; }

        protected bool CanAppend(ReportLevel reportLevel)
        {
            return reportLevel >= ReportLevel;
        }
        public abstract void Append(string date, ReportLevel reportLevel, string message);
        public override string ToString()
        {
            return $"Appender type: {GetType().Name}, Layout type: {layout.GetType().Name}, Report level: {ReportLevel}, Messages appended: {MessagessCount}";
        }
    }
}
