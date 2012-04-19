using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;

namespace csclr
{
    class Program
    {
        static void Main(string[] args)
        {

            ConcurrentStack<object> stack = new ConcurrentStack<object>();

            AssemblyName[] names = Assembly.GetExecutingAssembly()
                                           .GetReferencedAssemblies();

            Stopwatch watch = Stopwatch.StartNew();

            Parallel.For(0, names.Length, (i) =>
            {
                Assembly assembly = Assembly.Load(names[i]);
                Type[] types = assembly.GetTypes();
                Parallel.For(0, types.Length, (j) =>
                {
                    if (types[j].IsPublic)
                    {
                        ConstructorInfo[] constructors = types[j].GetConstructors();
                        Parallel.ForEach(constructors, (constructor) =>
                        {
                            if (constructor.GetParameters().Length == 0 &&
                                 types[j].GetGenericArguments().Length == 0)
                            {
                                stack.Push(Activator.CreateInstance(types[j]));
                            }
                        });
                    }
                });
            });

            long elapsedTime = watch.ElapsedMilliseconds;
            foreach (var type in stack)
            {
                Console.WriteLine(type.GetType().Name);
            }
            Console.WriteLine("Total objects: {0}", stack.Count);
            Console.WriteLine("Elapsed time: {0}", elapsedTime);            
        }
    }
}
