using System;
using System.Collections.Generic;

namespace InjectIt
{
    public class Container
    {
        private Dictionary<Type, Type> _map = new Dictionary<Type, Type>();

        public ContainerBuilder For<TSource>()
        {
            return For(typeof(TSource));
        }

        public ContainerBuilder For(Type sourceType)
        {
            return new ContainerBuilder(this, sourceType);
        }

        public TSource Resolve<TSource>()
        {
            return (TSource)Resolve(typeof(TSource));
        }

        public object Resolve(Type sourceType)
        {
            if (_map.ContainsKey(sourceType))
            {
                var destinationType = _map[sourceType];
                return Activator.CreateInstance(destinationType);
            }
            else
            {
                throw new InvalidOperationException($"Dependency not registered for: {sourceType.FullName}");
            }
        }

        public class ContainerBuilder
        {
            private Container _container;
            private Type _typeSource;

            public ContainerBuilder(Container container, Type type)
            {
                _container = container;
                _typeSource = type;
            }

            public void Use<TDestination>()
            {
                Use(typeof(TDestination));
            }

            public void Use(Type typeDestination)
            {
                _container._map.Add(_typeSource, typeDestination);
            }
        }
    }
}
