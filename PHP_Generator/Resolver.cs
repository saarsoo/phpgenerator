using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PHP_Generator
{
    internal class Resolver
    {
        private readonly Type[] _types;
        private readonly Dictionary<Type, object> _instances = new Dictionary<Type, object>();

        public Resolver(string assemblyName)
        {
            var assembly = Assembly.Load(new AssemblyName(assemblyName));
            _types = assembly.GetTypes();
        }

        public T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }

        public object Resolve(Type type)
        {
            var typeName = type.Name;

            if (type.IsInterface)
            {
                typeName = typeName.Substring(1);
            }

            type = _types.FirstOrDefault(t => t.Name == typeName);

            if (type == null)
            {
                throw new Exception(String.Format("Could not resolve type {0}", typeName));
            }

            if (_instances.ContainsKey(type))
            {
                return _instances[type];
            }

            var instance = Activator.CreateInstance(type);
            _instances.Add(type, instance);

            var methods = type.GetMethods().Where(m => m.Name == "InjectDependency");

            foreach (var method in methods)
            {
                var parameter = method.GetParameters().First();

                method.Invoke(instance, new[] { Resolve(parameter.ParameterType) });
            }

            return instance;
        }
    }
}
