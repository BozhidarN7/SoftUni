using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class NationsBuilder : INationsBuilder
{
    private readonly IBenderFactory benderFactory;
    private readonly IMonumentFactory monumentFactory;
    private readonly List<IBender> benders;
    private readonly List<IMonument> monuments;
    private readonly List<string> wars;
    public NationsBuilder()
    {
        benderFactory = new BenderFactory();
        monumentFactory = new MonumentFactory();
        benders = new List<IBender>();
        monuments = new List<IMonument>();
        wars = new List<string>();
    }
    public void AssignBender(List<string> benderArgs)
    {
        IBender bender = benderFactory.CreateBender(benderArgs);
        benders.Add(bender);
    }

    public void AssignMonument(List<string> monumentArgs)
    {
        IMonument monument = monumentFactory.CreateMonument(monumentArgs);
        monuments.Add(monument);
    }

    public string GetStatus(string nationsType)
    {
        StringBuilder result = new StringBuilder();
        result.AppendLine($"{nationsType} Nation");

        if (benders.Where(x => x.GetType().Name.StartsWith(nationsType)).Count() == 0)
        {
            result.AppendLine("Benders: None");
        }
        else
        {
            result.AppendLine("Benders:");
            benders.Where(x => x.GetType().Name.StartsWith(nationsType)).ToList().ForEach(x => result.AppendLine("###" + x.ToString()));
        }
        if (monuments.Where(x => x.GetType().Name.StartsWith(nationsType)).Count() == 0)
        {
            result.AppendLine("Monuments: None");
        }
        else
        {
            result.AppendLine("Monuments:");
            monuments.Where(x => x.GetType().Name.StartsWith(nationsType)).ToList().ForEach(x => result.AppendLine("###" + x.ToString()));
        }

        return result.ToString().TrimEnd();
    }

    public string GetWarsRecord()
    {
        StringBuilder result = new StringBuilder();

        for (int i = 0; i < wars.Count; i++)
        {
            result.AppendLine($"War {i + 1} issued by {wars[i]}");
        }
        return result.ToString().TrimEnd();
    }

    public void IssueWar(string nationsType)
    {
        Dictionary<string, double> totalPowersByNation = new Dictionary<string, double>();

        foreach (Nation nation in (Nation[])Enum.GetValues(typeof(Nation)))
        {
            totalPowersByNation.Add(nation.ToString(), CalculateTotalPower(nation.ToString()));
        }

        string winner = totalPowersByNation.OrderByDescending(x => x.Value).FirstOrDefault().Key;
        benders.RemoveAll(x => x.GetType().Name != (winner + "Bender"));

        wars.Add(nationsType);

        //double airNationTotalPower = CalculateTotalPower("Air");
        //double waterNationTotalPower = CalculateTotalPower("Water");
        //double fireNationTotalPower = CalculateTotalPower("Fire");
        //double earthNationTotalPower = CalculateTotalPower("Earth");


    }

    private double CalculateTotalPower(string nation)
    {
        int monumentsTotalPower = monuments.Where(x => x.GetType().Name.StartsWith(nation))
            .Sum(x => (int)x.GetType().GetProperty(nation + "Affinity").GetValue(x));
        //int monumentsTotalPower = monuments.Where(x => x.GetType().Name.StartsWith(nation)).Sum(x =>
        //{
        //    if (x.GetType().Name == "AirMonument")
        //    {
        //        return ((AirMonument)x).AirAffinity;
        //    }
        //    else if (x.GetType().Name == "EarthMonument")
        //    {
        //        return ((EarthMonument)x).EarthAffinity;
        //    }
        //    else if (x.GetType().Name == "WaterMonument")
        //    {
        //        return ((WaterMonument)x).WaterAffinity;
        //    }
        //    else
        //    {
        //        return ((FireMonument)x).FireAffinity;
        //    }
        //});

        double bendersTotalPower = benders.Where(x => x.GetType().Name.StartsWith(nation)).Sum(x => x.BenderPower);
        return bendersTotalPower * monumentsTotalPower / 100;
    }
}

