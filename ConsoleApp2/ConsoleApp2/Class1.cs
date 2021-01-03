using System;

namespace Project1
{ 
    /////////////1////////////////
    class Water
    {
        public string Name { get; set; }
        public Water(string name)
        {
            Name = name;
        }
        public virtual void Display()
        {
            Console.WriteLine(Name);
        }
        public override string ToString()
        {
            return base.ToString() + ": " + Name.ToString();
        }
    }
    class Sea : Water
    {
        public string Sea_ { get; set; }
        public Sea(string name, string Sea_1)
            : base(name)
        {
            Sea_ = Sea_1;
        }

        public override void Display()
        {
            Console.WriteLine($"Water is {Name}, {Sea_} Sea");
        }
        public override string ToString()
        {
            return base.ToString() + ": " + Sea_.ToString();
        }
    }
    class Land
    {
        public string str = "Earth";
    }
    class Continent : Land
    {
        public string str_ = "America";
        public virtual void ReWrite()
        {
            Console.WriteLine("Land: " + str);
            Console.WriteLine("Continent: " + str_);
        }

    }
    class iIsland : Continent
    {
        public string isla { get; set; }
        public iIsland(string isla_1)
        {
            isla = isla_1;
        }
        public override void ReWrite()
        {
            base.ReWrite();
            Console.WriteLine("Island: " + isla);
        }
    }
    class Country : iIsland
    {
        public string count { get; set; }
        public Country(string isla_, string count_) : base(isla_)
        {
            count = count_;
        }
        public override void ReWrite()
        {
            base.ReWrite();
            Console.WriteLine("Country: " + count);
        }
        public override string ToString()
        {
            return base.ToString() + ": " + str_.ToString();
        }
    }
    /////////////1////////////////
    /////////////2////////////////
    [Serializable]
    class Person
    {
        public string Name { get; set; }
        public Person(string name)
        {
            Name = name;
        }
        public virtual void Display()
        {
            Console.WriteLine(Name);
        }
    }
    [Serializable]
    class Employee : Person
    {
        public string Company { get; set; }
        public Employee(string name, string company) : base(name)
        {
            Company = company;
        }
        class cls
        {
            public string str;  
        }
        [NonSerialized]
        public string str;
    }
    /////////////2////////////////
    /////////////3////////////////
    sealed class SealedClass
    {
        public int x;
        public int y;
    }
    /////////////3////////////////
    /////////////4////////////////
    [Serializable]
    public abstract class Vehicle
    {
        public abstract void Move();
    }
    [Serializable]
    public class Car : Vehicle
    {
        public string str;
        class cls
        {
            public string str;
        }
        [NonSerialized]
        public int a;
        public override void Move()
        {
            Console.WriteLine("Машина едет");
        }
    }
    //////////////////inteface//////////////////
    public interface IMovable
    {
        void Move();
    }
    public abstract class AVehicle1
    { }
    public class Car1 : AVehicle1, IMovable
    {

        public void Move()
        {
            Console.WriteLine("Машина едет");
        }
    }
    /////////////4////////////////

    /////////////7////////////////
    [Serializable]
    class Printer
    {
        public void IAmPrinting(RunThing rn)
        {
            rn.Run();
            Console.WriteLine("ToString() 7 exersize" + rn.ToString());
        }
    }
    public interface Running
    {
        void Run();
    }
    public class RunThing : Running
    {
        public void Run()
        {
            Console.WriteLine("Work");
        }
    }
    /////////////7////////////////
}
