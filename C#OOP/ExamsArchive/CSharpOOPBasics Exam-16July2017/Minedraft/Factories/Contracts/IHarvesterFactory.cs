using System;
using System.Collections.Generic;
using System.Text;

public interface IHarvesterFactory
{
    public KeyValuePair<Harvester,string> CreateHarvester(List<string> args);
}

