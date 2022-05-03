using System;

namespace testCSharp
{
    public interface ITarget
    {
        string GetRequest();
    }

    class Adaptee
    {
        public string GetSpecificRequest(){
            return "Specific request";
        }
    }

    class Adapter : ITarget
    {
        private readonly Adaptee _adaptee;

        public Adapter(Adaptee adaptee){
            this._adaptee = adaptee;
        }

        public string GetRequest(){
            return $"This is '{this._adaptee.GetSpecificRequest()}'";
        }
    }
}