using DIFramework.Attributes;
using DIFramework.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DIFramework.Injectors
{
    public class Injector
    {
        private IModule module;

        public Injector(IModule module)
        {
            this.module = module;
        }

        private bool CheckForFieldInjection<TClass>()
        {
            return typeof(TClass).GetFields((BindingFlags)62).Any(field => field.GetCustomAttributes(typeof(Inject), true).Any());
        }
        private bool CheckForConstructorInjection<TClass>()
        {
            return typeof(TClass).GetConstructors().Any(ctor => ctor.GetCustomAttributes(typeof(Inject), true).Any());
        }
        private TClass CreateConstructorInjection<TClass>()
        {
            Type desireClass = typeof(TClass);

            if (desireClass is null) return default(TClass);

            ConstructorInfo[] constructors = desireClass.GetConstructors();

            foreach (ConstructorInfo constructor in constructors)
            {
                if (!CheckForConstructorInjection<TClass>()) continue;

                Inject inject = (Inject)constructor.GetCustomAttributes(typeof(Inject), true).FirstOrDefault();

                ParameterInfo[] parameterTypes = constructor.GetParameters();
                object[] constructorParams = new object[parameterTypes.Length];

                int i = 0;
                foreach (ParameterInfo parameterType in parameterTypes)
                {
                    Attribute named = parameterType.GetCustomAttribute(typeof(Named));
                    Type dependency = null;
                    if (named == null)
                    {
                        dependency = module.GetMapping(parameterType.ParameterType, inject);
                    }
                    else
                    {
                        dependency = module.GetMapping(parameterType.ParameterType, named);
                    }

                    if (parameterType.ParameterType.IsAssignableFrom(dependency))
                    {
                        object instance = module.GetInstance(dependency);
                        if (instance != null)
                        {
                            constructorParams[i++] = instance;
                        }
                        else
                        {
                            instance = Activator.CreateInstance(dependency);
                            constructorParams[i++] = instance;
                            module.SetInstance(parameterType.ParameterType, instance);
                        }
                    }
                }
                return (TClass)Activator.CreateInstance(desireClass, constructorParams);
            }
            return default(TClass);
        }
        private TClass CreateFieldInjection<TClass>()
        {
            Type desireClass = typeof(TClass);
            object desireClassInstance = module.GetInstance(desireClass);

            if (desireClassInstance is null)
            {
                desireClassInstance = Activator.CreateInstance(desireClass);
                module.SetInstance(desireClass, desireClassInstance);
            }

            FieldInfo[] fields = desireClass.GetFields((BindingFlags)62);
            foreach( FieldInfo field in fields)
            {
                if (field.GetCustomAttributes(typeof(Inject), true).Any())
                {
                    Inject injection = (Inject)field.GetCustomAttributes(typeof(Inject), true).FirstOrDefault();
                    Type dependency = null;

                    Attribute named = field.GetCustomAttribute(typeof(Named), true);
                    Type type = field.FieldType;

                    if (named == null)
                    {
                        dependency = module.GetMapping(type, injection);
                    }
                    else
                    {
                        dependency = module.GetMapping(type, named);
                    }

                    if (type.IsAssignableFrom(dependency))
                    {
                        object instance = module.GetInstance(dependency);
                        if (instance is null)
                        {
                            instance = Activator.CreateInstance(dependency);
                            module.SetInstance(dependency, instance);
                        }
                        field.SetValue(desireClassInstance, instance);
                    }
                }
            }
            return (TClass)desireClassInstance;
        }
        public TClass Inject<TClass>()
        {
            bool hasConstructorAttribute = CheckForConstructorInjection<TClass>();
            bool hasFieldAttribute = CheckForFieldInjection<TClass>();

            if (hasConstructorAttribute && hasFieldAttribute)
            {
                throw new ArgumentException("There must be only field or construtor annotated with Inject attribute");
            }

            if (hasConstructorAttribute)
            {
                return CreateConstructorInjection<TClass>();
            }
            else if (hasFieldAttribute)
            {
                return CreateFieldInjection<TClass>();
            }
            return default(TClass);
        }
    }
}
