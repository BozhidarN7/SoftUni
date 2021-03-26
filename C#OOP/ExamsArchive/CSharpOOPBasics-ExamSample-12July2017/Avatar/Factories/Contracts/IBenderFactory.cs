using System;
using System.Collections.Generic;
using System.Text;

public interface IBenderFactory
{
    public IBender CreateBender(List<string> args);
}

