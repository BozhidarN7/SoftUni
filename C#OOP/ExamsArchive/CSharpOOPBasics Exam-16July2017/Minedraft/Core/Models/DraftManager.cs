using Minedraft.Factories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager : IDraftManager
{
    private double totalMinedOre;
    private double totalStoredEnergy;
    private readonly List<Harvester> harvesters;
    private readonly List<Provider> providers;
    private readonly ICreateHarvester harvesterCreator;
    private readonly ICreateProvider providerCreator;
    private Mode mode;
    public DraftManager()
    {
        harvesters = new List<Harvester>();
        providers = new List<Provider>();
        harvesterCreator = new CreateHarvester();
        providerCreator = new CreateProvider();
        mode = Enum.Parse<Mode>("Full", true);
    }
    public string Check(List<string> arguments)
    {
        string id = arguments[0];
        Provider provider = FindProviderWithId(id);
        if (provider != null)
        {
            return provider.ToString();
        }

        Harvester harvester = FindHarvesterWithId(id);
        if (harvester != null)
        {
            return harvester.ToString();
        }
        return string.Format(ConstantMessages.UnSuccessfullCheckCommand, id);
    }

    public string Day()
    {
        StringBuilder result = new StringBuilder();
        result.AppendLine(ConstantMessages.DayPassedMessage);

        double providedEnergy = CalculateTotalProvidedEnergy();
        result.AppendLine(string.Format(ConstantMessages.ProvidedEnergyMessage, providedEnergy));

        totalStoredEnergy += providedEnergy;

        double energyModifier = 1;
        double oreOutputModifier = 1;
        if (Enum.Parse<Mode>("Half") == mode)
        {
            energyModifier = (int)mode / (double)100;
            oreOutputModifier = 0.5;
        }
        double harvestersdNeededEnergy = CalculateHarvesterNeededEnergy(energyModifier);

        if (totalStoredEnergy < harvestersdNeededEnergy || Enum.Parse<Mode>("Energy", true) == mode)
        {
            result.AppendLine(string.Format(ConstantMessages.PlumbsOreMinedMessage, 0));
            return result.ToString().TrimEnd();
        }

        double currentDayMinedOre = 0;
        foreach (Harvester harvester in harvesters)
        {
            totalStoredEnergy -= harvester.EnergyRequirement * energyModifier;
            currentDayMinedOre += harvester.OreOutput * oreOutputModifier;
        }
        totalMinedOre += currentDayMinedOre;
        return result.AppendLine(string.Format(ConstantMessages.PlumbsOreMinedMessage, currentDayMinedOre)).ToString().TrimEnd();
    }

    public string Mode(List<string> arguments)
    {
        string modeAsString = arguments[0];
        if (Enum.TryParse<Mode>(modeAsString, out Mode newMode))
        {
            mode = newMode;
        }
        return string.Format(ConstantMessages.SuccessfullyChandedMode, modeAsString);
    }

    public string RegisterHarvester(List<string> arguments)
    {
        KeyValuePair<Harvester, string> pair = harvesterCreator.CreateHarvester(arguments);
        Harvester harvester = pair.Key;
        string message = pair.Value;
        if (harvester == null)
        {
            return string.Format(ConstantMessages.UnSuccessfullyRegisterHarvester, message);
        }
        harvesters.Add(harvester);
        return string.Format(ConstantMessages.SuccessfullyRegisterHarvester, arguments[0], arguments[1]);
    }

    public string RegisterProvider(List<string> arguments)
    {
        KeyValuePair<Provider, string> pair = providerCreator.CreateProvider(arguments);
        Provider provider = pair.Key;
        string message = pair.Value;

        if (provider == null)
        {
            return string.Format(ConstantMessages.UnSuccessfullyRegisterProvider, message);
        }

        providers.Add(provider);
        return string.Format(ConstantMessages.SuccessfullyRegisterProvider, arguments[0], arguments[1]);
    }

    public string ShutDown()
    {
        StringBuilder result = new StringBuilder();
        result.AppendLine("System Shutdown");
        result.AppendLine($"Total Energy Stored: {totalStoredEnergy}");
        result.AppendLine($"Total Mined Plumbus Ore: {totalMinedOre}");
        return result.ToString().TrimEnd();
    }
    private double CalculateTotalProvidedEnergy()
    {
        return providers.Sum(x => x.EnergyOutput);
    }

    private double CalculateHarvesterNeededEnergy(double energyModifier)
    {
        return harvesters.Sum(x => x.EnergyRequirement * energyModifier);
    }
    private Provider FindProviderWithId(string id)
    {
        return providers.Find(x => x.Id == id);
    }
    private Harvester FindHarvesterWithId(string id)
    {
        return harvesters.Find(x => x.Id == id);
    }
}
