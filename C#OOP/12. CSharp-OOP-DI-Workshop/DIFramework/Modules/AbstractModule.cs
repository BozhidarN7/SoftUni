using DIFramework.Attributes;
using DIFramework.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DIFramework.Modules
{
    public abstract class AbstractModule : IModule
    {
        private IDictionary<Type, Dictionary<string, Type>> implementations;
        private IDictionary<Type, object> instances;

        protected AbstractModule()
        {
            implementations = new Dictionary<Type, Dictionary<string, Type>>();
            instances = new Dictionary<Type, object>();
        }

        protected void CreateMapping<TInter, TImpl>()
        {
            if (!implementations.ContainsKey(typeof(TInter)))
            {
                implementations[typeof(TInter)] = new Dictionary<string, Type>();
            }
            implementations[typeof(TInter)].Add(typeof(TImpl).Name, typeof(TImpl));
        }
        public abstract void Configure();

        public object GetInstance(Type implementation)
        {
            this.instances.TryGetValue(implementation, out object value);
            return value;
        }

        public Type GetMapping(Type currentInterface, object attribute)
        {
            Dictionary<string,Type> currentImplementation = implementations[currentInterface];

            Type type = null;

            if(attribute is Inject)
            {
                if (currentImplementation.Count == 1)
                {
                    type = currentImplementation.Values.First();
                }
                else
                {
                    throw new ArgumentException("No available mapping for class: " + currentInterface.FullName);
                }
            }
            else if(attribute is Named)
            {
                Named named = attribute as Named;
                string dependencyName = named.Name;
                type = currentImplementation[dependencyName];
            }

            return type;
        }

        public void SetInstance(Type implementation, object instance)
        {
            if (!instances.ContainsKey(implementation))
            {
                instances.Add(implementation, instance);
            }
        }
    }
}
