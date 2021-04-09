using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private readonly List<IComputer> computers;
        private readonly List<IComponent> components;
        private readonly List<IPeripheral> peripherals;
        public Controller()
        {
            computers = new List<IComputer>();
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();
        }
        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            ThrowExceptionIfComputerNotExists(computerId);

            if (components.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }
            IComponent component = null;
            if (componentType == "CentralProcessingUnit")
            {
                component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "Motherboard")
            {
                component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "PowerSupply")
            {
                component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "RandomAccessMemory")
            {
                component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "SolidStateDrive")
            {
                component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "VideoCard")
            {
                component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidComponentType);
            }

            components.Add(component);
            IComputer computer = computers.FirstOrDefault(x => x.Id == computerId);
            computer.AddComponent(component);

            return string.Format(SuccessMessages.AddedComponent, componentType, id, computerId);
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            if (computers.Any(x => x.Id == id))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingComputerId));
            }

            if (computerType == "Laptop")
            {
                computers.Add(new Laptop(id, manufacturer, model, price));
            }
            else if (computerType == "DesktopComputer")
            {
                computers.Add(new DesktopComputer(id, manufacturer, model, price));
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidComputerType));
            }
            return string.Format(SuccessMessages.AddedComputer, id);
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            ThrowExceptionIfComputerNotExists(computerId);

            if (peripherals.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheralId);
            }
            IPeripheral peripheral = null;
            if (peripheralType == "Headset")
            {
                peripheral = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Keyboard")
            {
                peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Monitor")
            {
                peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Mouse")
            {
                peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidPeripheralType);
            }

            peripherals.Add(peripheral);
            IComputer computer = computers.FirstOrDefault(x => x.Id == computerId);
            computer.AddPeripheral(peripheral);

            return string.Format(SuccessMessages.AddedPeripheral, peripheralType, id, computerId);
        }

        public string BuyBest(decimal budget)
        {
            List<IComputer> possibleComputers = computers.Where(x => x.Price <= budget).ToList();
            if (computers.Count == 0 || possibleComputers.Count == 0)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CanNotBuyComputer, budget));
            }
            IComputer computer = possibleComputers.OrderByDescending(x => x.OverallPerformance).ToList()[0];
            computers.Remove(computer);
            return computer.ToString();
        }

        public string BuyComputer(int id)
        {
            ThrowExceptionIfComputerNotExists(id);

            IComputer computer = computers.FirstOrDefault(x => x.Id == id);
            computers.Remove(computer);
            return computer.ToString();
        }

        public string GetComputerData(int id)
        {
            ThrowExceptionIfComputerNotExists(id);
            return computers.FirstOrDefault(x => x.Id == id).ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            ThrowExceptionIfComputerNotExists(computerId);

            IComputer computer = computers.FirstOrDefault(x => x.Id == computerId);
            IComponent component = components.FirstOrDefault(x => x.GetType().Name == componentType);
            computer.RemoveComponent(componentType);
            components.Remove(component);

            return string.Format(SuccessMessages.RemovedComponent, componentType, component.Id);
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            ThrowExceptionIfComputerNotExists(computerId);

            IComputer computer = computers.FirstOrDefault(x => x.Id == computerId);
            IPeripheral peripheral = peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);
            computer.RemovePeripheral(peripheralType);
            peripherals.Remove(peripheral);

            return string.Format(SuccessMessages.RemovedPeripheral, peripheralType, peripheral.Id);
        }

        private void ThrowExceptionIfComputerNotExists(int id)
        {
            if (!computers.Any(x => x.Id == id))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComputerId));
            }
        }
    }
}
