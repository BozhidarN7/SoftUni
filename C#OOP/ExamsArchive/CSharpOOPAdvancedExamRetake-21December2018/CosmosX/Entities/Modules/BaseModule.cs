using CosmosX.Entities.Modules.Absorbing;
using CosmosX.Entities.Modules.Contracts;
using CosmosX.Entities.Modules.Energy;
using System;
using System.Linq;
using System.Text;

namespace CosmosX.Entities.Modules
{
    public abstract class BaseModule : IModule
    {
        protected BaseModule(int id)
        {
            this.Id = id;
        }

        public int Id { get;}

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"{this.GetType().Name} Module - {this.Id}");

            if(GetType().Name == "CryogenRod")
            {
                result.AppendLine($"Energy Output: {((CryogenRod)this).EnergyOutput}");
            }
            else if(GetType().Name == nameof(HeatProcessor))
            {
                result.AppendLine($"Heat Absorbing: {((HeatProcessor)this).HeatAbsorbing}");
            }
            else  if (GetType().Name == nameof(CooldownSystem))
            {
                result.AppendLine($"Heat Absorbing: {((CooldownSystem)this).HeatAbsorbing}");
            }

            return result.ToString().TrimEnd();
        }
    }
}