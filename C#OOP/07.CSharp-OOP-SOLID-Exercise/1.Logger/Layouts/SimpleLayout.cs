using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerSOLID.Layouts
{
    public class SimpleLayout : ILayout
    {
        public string Template => "{0} - {1} - {2}";
    }
}
