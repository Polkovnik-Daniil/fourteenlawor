using System;
using Project1;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
using System.Runtime.Serialization.Json;

namespace Project1
{
    [Serializable]
    public class Myclass
    {
        public int age;
        public string name;
    }
    class Person2
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    class Program
    {
        static async System.Threading.Tasks.Task maAsync()
        {
            using (FileStream fs = new FileStream("user.json", FileMode.OpenOrCreate))
            {
                Person2 tom = new Person2() { Name = "Tom", Age = 35 };
                //асинхронное выполнение
                await JsonSerializer.SerializeAsync<Person2>(fs, tom);
                Console.WriteLine("Data has been saved to file");
            }

            // чтение данных
            using (FileStream fs = new FileStream("user.json", FileMode.OpenOrCreate))
            {
                Person2 restoredPerson = await JsonSerializer.DeserializeAsync<Person2>(fs);
                Console.WriteLine($"Name: {restoredPerson.Name}  Age: {restoredPerson.Age}");
            }
        }
        static void Main(string[] args)
        {
            Program.maAsync();
            Console.WriteLine("Hello World!");
            Employee pr = new Employee("name", "company");
            Employee pr2 = new Employee("name", "company");
            Employee[] people = new Employee[] { pr, pr2 };

            BinaryFormatter formatter = new BinaryFormatter();
            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream(@"D:\Даник\Учеба\3 семестр\ООП\Лабораторные работы\14\ConsoleApp2\ConsoleApp2\people.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, pr);
                Console.WriteLine("Объект сериализован");
            }

            // десериализация из файла people.dat
            using (FileStream fs = new FileStream(@"D:\Даник\Учеба\3 семестр\ООП\Лабораторные работы\14\ConsoleApp2\ConsoleApp2\people.dat", FileMode.OpenOrCreate))
            {
                Employee newPerson = (Employee)formatter.Deserialize(fs);
                Console.WriteLine("Объект десериализован");
                Console.WriteLine($"Имя: {newPerson.Company}");
            }
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            // создаем объект SoapFormatter
            var formatter1 = new SoapFormatter();
            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream(@"D:\Даник\Учеба\3 семестр\ООП\Лабораторные работы\14\ConsoleApp2\ConsoleApp2\people.soap", FileMode.OpenOrCreate))
            {
                formatter1.Serialize(fs, people);
                Console.WriteLine("Объект сериализован");
            }

            // десериализация
            using (FileStream fs = new FileStream(@"D:\Даник\Учеба\3 семестр\ООП\Лабораторные работы\14\ConsoleApp2\ConsoleApp2\people.soap", FileMode.OpenOrCreate))
            {
                Employee[] newPeople = (Employee[])formatter1.Deserialize(fs);
                Console.WriteLine("Объект десериализован");
                foreach (Employee p in newPeople)
                {
                    Console.WriteLine("Name: ", p.Company);
                }
            }

            Myclass my = new Myclass();
            my.name = "Andrey";
            my.age = 35;

            FileStream stream = File.Create("test.json");
            DataContractJsonSerializer formatter2 = new DataContractJsonSerializer(my.GetType());
            //Сериализация
            formatter2.WriteObject(stream, my);
            stream.Close();

            //Десериализация
            stream = File.OpenRead("test.json");

            my = formatter2.ReadObject(stream) as Myclass;

            Console.WriteLine("Имя    : " + my.name);
            Console.WriteLine("Возраст: " + my.age);
            stream.Close();
            Console.ReadKey();


            // объект для сериализации
            Console.WriteLine("Объект создан");

            // передаем в конструктор тип класса
            XmlSerializer formatter3 = new XmlSerializer(typeof(Car));

            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream(@"D:\Даник\Учеба\3 семестр\ООП\Лабораторные работы\14\ConsoleApp2\ConsoleApp2\people19.xml", FileMode.OpenOrCreate))
            {
                Car newCAr = new Car();
                newCAr.str = "strnew";
                formatter3.Serialize(fs, newCAr);
                Console.WriteLine("Объект сериализован");
            }

            // десериализация
            using (FileStream fs = new FileStream(@"D:\Даник\Учеба\3 семестр\ООП\Лабораторные работы\14\ConsoleApp2\ConsoleApp2\people19.xml", FileMode.OpenOrCreate))
            {
                Car newPerson = (Car)formatter3.Deserialize(fs);
                Console.WriteLine("Объект десериализован");
                Console.WriteLine($"Name: {newPerson.str}");
            }


            List<string> str = new List<string>();

            //Serialization
            Serializer.Save("data.bin", str);

            //Deserialization
            str = Serializer.Load<List<string>>("data.bin");


            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(@"D:\Даник\Учеба\3 семестр\ООП\Лабораторные работы\14\ConsoleApp2\ConsoleApp2\people5.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            // создаем новый элемент user
            XmlElement userElem = xDoc.CreateElement("user");
            // создаем атрибут name и compony
            XmlAttribute nameAttr = xDoc.CreateAttribute("Name");
            XmlAttribute nameAttr1 = xDoc.CreateAttribute("Compony");

            // создаем элементы company и name
            XmlElement companyElem = xDoc.CreateElement("company");
            XmlElement ageElem = xDoc.CreateElement("name");
            // создаем текстовые значения для элементов и атрибута
            XmlText nameText = xDoc.CreateTextNode("Mark Zuckerberg");
            XmlText companyText = xDoc.CreateTextNode("Facebook");
            XmlText ageText = xDoc.CreateTextNode("30");

            //добавляем узлы
            nameAttr.AppendChild(nameText);
            companyElem.AppendChild(companyText);
            ageElem.AppendChild(ageText);
            userElem.Attributes.Append(nameAttr);
            userElem.AppendChild(companyElem);
            userElem.AppendChild(ageElem);
            xRoot.AppendChild(userElem);

            xDoc.Save(@"D:\Даник\Учеба\3 семестр\ООП\Лабораторные работы\14\ConsoleApp2\ConsoleApp2\people5.xml");
            Employees[] emps1 = new[] {
                    new Employees { FirstName = "Alex", LastName="Erohin", EmployeType=EmployeTypes.Programmer},
                    new Employees { FirstName="Elena", LastName="Chuchina", EmployeType=EmployeTypes.Editor}};

            XElement xEmp1 =
                            new XElement("Employeess",
                                emps1.Select(p =>
                                    new XElement("Employee",                    // создаем элементы
                                        new XAttribute("type", p.EmployeType),  // создаем атрибут
                                        new XElement("FirstName", p.FirstName), // создаем элементы
                                        new XElement("LastName", p.LastName))));    // создаем элементы
            Console.WriteLine(xEmp1);
            Console.ReadLine();
        }

        private void ma()
        {
            throw new NotImplementedException();
        }
    }
    public static class Serializer
    {
        public static void Save(string filePath, object objToSerialize)
        {
            try
            {
                using (Stream stream = File.Open(filePath, FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, objToSerialize);
                }
            }
            catch (IOException IOex)
            {
                Console.WriteLine(IOex.Message);
            }
        }

        public static T Load<T>(string filePath) where T : new()
        {
            T rez = new T();

            try
            {
                using (Stream stream = File.Open(filePath, FileMode.Open))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    rez = (T)bin.Deserialize(stream);
                }
            }
            catch (IOException IOex)
            {
                Console.WriteLine(IOex.Message);
            }

            return rez;
        }
    }
}
