using System;
using System.Collections.Generic;

namespace Calculator
{ 
    public static class Container
    {
        public static void Register(Type contract, Type implementation)
        {
            _map.Add(contract, implementation);
        }

        public static void Register<TContract, TImplementation>()
        {
            _map.Add(typeof(TContract), typeof(TImplementation));
        }

        public static T Resolve<T>()
        {
            return (T)Activator.CreateInstance(_map[typeof(T)]);
        }

        static TypeMap _map = new TypeMap();
    }
}
