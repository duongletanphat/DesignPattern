using System;
using System.Collections.Generic;

namespace testCSharp.DesignPattern.Builder.Conceptual
{
    public interface IBuilder
    {
        void BuilderPartA();
        void BuilderPartB();
        void BuilderPartC();
    }

    public class ConcreteBuilder : IBuilder
    {
        private Product _product = new Product();

        public ConcreteBuilder(){
            this.Reset();
        }

        public void Reset(){
            this._product = new Product();
        }

        public void BuilderPartA(){
            this._product.Add("Part A1");
        }

        public void BuilderPartB(){
            this._product.Add("Part B1");
        }

        public void BuilderPartC(){
            this._product.Add("Part C1");
        }

        public Product GetProduct(){
            Product result = this._product;

            this.Reset();

            return result;
        }
    }

    public class Product
    {
        private List<object> _part = new List<object>();

        public void Add(string part){
            this._part.Add(part);
        }

        public string ListParts(){
            string str = string.Empty;

            for (int i = 0; i < this._part.Count; i++)
            {
                str += this._part[i] + " , ";
            }

            str = str.Remove(str.Length - 2);

            return "Product parts: " + str + "\n";
        }
    }

    public class Director
    {
        private IBuilder _builder;

        public IBuilder Builder{
            set {_builder = value;}
        }

        public void BuildMinimalViableProduct(){
            this._builder.BuilderPartA();
        }

        public void BuildFullFeaturedProduct(){
            this._builder.BuilderPartA();
            this._builder.BuilderPartB();
            this._builder.BuilderPartC();
        }
    }
    class Program
    {
        static void Main(string[] args){
            var director = new Director();
            var builder = new ConcreteBuilder();
            director.Builder = builder;

            System.Console.WriteLine("Stand basic product");
            director.BuildMinimalViableProduct();
            System.Console.WriteLine(builder.GetProduct().ListParts());

            System.Console.WriteLine("Stand full featured product:");
            director.BuildFullFeaturedProduct();
            System.Console.WriteLine(builder.GetProduct().ListParts());

            System.Console.WriteLine("Custom product: ");
            builder.BuilderPartA();
            builder.BuilderPartC();
            System.Console.WriteLine(builder.GetProduct().ListParts());
        }
    }
}