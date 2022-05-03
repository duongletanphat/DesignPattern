using System;

namespace testCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            // ->>> ADAPTER
            Adaptee adaptee = new Adaptee();
            ITarget target = new Adapter(adaptee);

            System.Console.WriteLine("Adaptee interface is incompatible with the client.");
            System.Console.WriteLine("But with adapter client can call it's method");

            System.Console.WriteLine(target.GetRequest());
            System.Console.WriteLine();

            //========================================================

            //->> Abstract Factory
            new Client().Main();
        }
    }
}
