using LoggerSOLID.Layouts;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerSOLID.Core.Factories
{
    public interface ILayoutFactory
    {
        ILayout CreateFactory(string type);
    }
}
