using System;
using System.Collections.Generic;
using System.Text;

public interface ICreateHarvester
{
    public KeyValuePair<Harvester,string> CreateHarvester(List<string> args);
}

