using System;
using System.Collections.Generic;
using System.Text;

public interface IMonumentFactory
{
    public IMonument CreateMonument(List<string> args);
}

