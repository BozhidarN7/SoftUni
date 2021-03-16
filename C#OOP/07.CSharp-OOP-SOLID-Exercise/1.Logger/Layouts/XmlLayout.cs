using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerSOLID.Layouts
{
    public class XmlLayout : ILayout
    {
        public string Template
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("<log>");
                sb.AppendLine(" <date>{0}</date");
                sb.AppendLine(" <level>{0}</level");
                sb.AppendLine(" <message>{0}</message");
                sb.AppendLine("</log>");
                return sb.ToString().TrimEnd();
            }
        }
    }
}
