namespace FestivalManager.Entities.Factories
{
	using System;
	using System.Linq;
	using System.Reflection;
	using System.Runtime.InteropServices.WindowsRuntime;
	using Contracts;
	using Entities.Contracts;
	using Instruments;

	public class InstrumentFactory : IInstrumentFactory
	{
		public IInstrument CreateInstrument(string type)
		{
			Type classType = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(x => x.Name == type);
			return (IInstrument)Activator.CreateInstance(classType);
		}
	}
}