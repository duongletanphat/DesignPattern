using System;

namespace testCSharp
{
    abstract class Creator
    {
        public abstract IProduct FactoryMethod();

        public string SomeOperation(){
            var product = FactoryMethod();

            var result = "Create: The same create's code has just worked with"
                        + product.Operation();
            
            return result;
        }
    }

    class ConcreteCreator1 : Creator
    {
        public override IProduct FactoryMethod()
        {
            return new ConcreteProduct1();
        }
    }

    class ConcreteCreator2 : Creator
    {
        public override IProduct FactoryMethod(){
            return new ConcreteProduct2();
        }
    }

    public interface IProduct{
        string Operation();
    }

    class ConcreteProduct1 : IProduct
    {
        public string Operation(){
            return "{Result of ConcreteProduct1}";
        }
    }

    class ConcreteProduct2 : IProduct
    {
        public string Operation(){
            return "{Result of ConcreteProduct2}";
        }
    }

    class CLient
    {
        public void Main(){
            System.Console.WriteLine("App: Launched with the ConcreteCreator1.");
            ClientCode(new ConcreteCreator1());

            System.Console.WriteLine("");

            System.Console.WriteLine("App: Launched with the ConcreteCreator2.");
            ClientCode(new ConcreteCreator2());
        }
        public void ClientCode(Creator creator){
            System.Console.WriteLine("Client: I'm not aware of the creator's class, but it still works.\n" 
            + creator.SomeOperation());
        }
    }    

    class Progam
    {
        static void Main(string[] args){
            new CLient().Main();
        }
    }
}