using System;
using System.Reflection;
using CodeGeneration.DynamicClass;

namespace CodeGeneration
{
    public static class Bootstrap
    {
        public static void Start()
        {
            AdapterGenerator adapterGenerator = new AdapterGenerator();
            IoC.Bind("Adapter", objects => adapterGenerator.Generate((Type)objects[0]));
            IoC.Bind("IMovable.Position", objects => ((IMovable)objects[0]).getPosition());
            
            //IMovable adapterInstance = IoC.Resolve<IMovable>("Adapter", typeof(IMovable));
            //IMovable adapterInstance2 = IoC.Resolve<IMovable>("Adapter", typeof(IMovable));
            
            //Console.WriteLine(adapterInstance.getPosition().ToString());


            var adapter = adapterGenerator.GetAdapter(typeof(IMovable));
            Console.WriteLine(((IMovable) adapter).getPosition().ToString());
             
            //Assembly.Load(adapterGenerator.GenerateClass(typeof(IMovable)));
            //var adapter = Type.GetType("IMovableAdapter");
            //HelloWorldGenerated.HelloWorld.SayHello(); 
            // working!
            Example example = new Example();
            example.Start2();

            //AdapterGenerator.GenerateCSFile(typeof(IMovable));
        }
    }
}