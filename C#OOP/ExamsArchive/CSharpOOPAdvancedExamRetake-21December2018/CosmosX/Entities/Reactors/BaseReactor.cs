using CosmosX.Entities.CommonContracts;
using CosmosX.Entities.Containers.Contracts;
using CosmosX.Entities.Modules.Absorbing.Contracts;
using CosmosX.Entities.Modules.Energy.Contracts;
using CosmosX.Entities.Reactors.Contracts;
using System.Text;

namespace CosmosX.Entities.Reactors
{
    public abstract class BaseReactor : IReactor, IIdentifiable
    {
        private readonly IContainer moduleContainer;
        private int id;

        protected BaseReactor(int id, IContainer moduleContainer)
        {
            this.Id = id;
            this.moduleContainer = moduleContainer;
        }

        public int Id
        {
            get
            {
                return this.id;
            }
            private set
            {
                this.id = value;
            }
        }

        public virtual long TotalEnergyOutput 
            => this.moduleContainer.TotalEnergyOutput;

        public virtual long TotalHeatAbsorbing 
            => this.moduleContainer.TotalHeatAbsorbing;

        public int ModuleCount 
            => this.moduleContainer.ModulesByInput.Count;

        public void AddEnergyModule(IEnergyModule energyModule)
        {
            this.moduleContainer.AddEnergyModule(energyModule);
        }

        public void AddAbsorbingModule(IAbsorbingModule absorbingModule)
        {
            this.moduleContainer.AddAbsorbingModule(absorbingModule);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"{this.GetType().Name} - {this.Id}");
            result.AppendLine($"Energy Output: {this.TotalEnergyOutput}");
            result.AppendLine($"Heat Absorbing: {this.TotalHeatAbsorbing}");
            result.AppendLine($"Modules: {this.ModuleCount}");

            return result.ToString().TrimEnd();
        }
    }
}