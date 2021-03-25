using System;
using System.Collections.Generic;
using System.Text;

public interface ICreateProvider
{
    public KeyValuePair<Provider,string> CreateProvider(List<string> args);
}

