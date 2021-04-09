using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private readonly List<IComponent> components;
        private readonly List<IPeripheral> peripherals;
        public Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();
        }

        public override double OverallPerformance
        {
            get
            {
                if (components.Count == 0)
                {
                    return base.OverallPerformance;
                }
                return base.OverallPerformance + components.Average(x => x.OverallPerformance);
            }
        }
        public override decimal Price => base.Price + components.Sum(x => x.Price) + peripherals.Sum(x => x.Price);

        public IReadOnlyCollection<IComponent> Components => components.AsReadOnly();

        public IReadOnlyCollection<IPeripheral> Peripherals => peripherals.AsReadOnly();

        public void AddComponent(IComponent component)
        {
            if (components.Any(x => x.GetType().Name == component.GetType().Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingComponent, component.GetType().Name, GetType().Name, Id));
            }
            components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (peripherals.Any(x => x.GetType().Name == peripheral.GetType().Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingPeripheral, peripheral.GetType().Name, GetType().Name, Id));
            }
            peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            if (components.Any(x => x.GetType().Name != componentType) || components.Count == 0)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComponent, componentType, GetType().Name, Id));
            }
            IComponent component = components.FirstOrDefault(x => x.GetType().Name == componentType);
            components.Remove(component);
            return component;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            if (peripherals.Any(x => x.GetType().Name != peripheralType) || peripherals.Count == 0)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingPeripheral, peripheralType, GetType().Name, Id));
            }
            IPeripheral peripheral = peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);
            peripherals.Remove(peripheral);
            return peripheral;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(base.ToString());

            result.AppendLine(" " + string.Format(SuccessMessages.ComputerComponentsToString, components.Count));
            components.ForEach(x => result.AppendLine($"  {x.ToString()}"));

            result.AppendLine(" " + string.Format(SuccessMessages.ComputerPeripheralsToString, peripherals.Count,
                (peripherals.Count != 0 ? peripherals.Average(x => x.OverallPerformance) : 0)));
            peripherals.ForEach(x => result.AppendLine($"  {x.ToString()}"));

            return result.ToString().TrimEnd();
        }
    }
}
