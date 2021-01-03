using System;
using Project1;
using System.IO;
using System.Text.Json;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Xml;


namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
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
                formatter1.Serialize(fs, pr);

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

            Car tom = new Car(){ str = "Name" };
            string json = JsonSerializer.Serialize<Car>(tom);
            Console.WriteLine(json);
            Car restoredPerson = JsonSerializer.Deserialize<Car>(json);
            Console.WriteLine(restoredPerson.str);



            // объект для сериализации
            Console.WriteLine("Объект создан");

            // передаем в конструктор тип класса
            XmlSerializer formatter2 = new XmlSerializer(typeof(Car));

            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream(@"D:\Даник\Учеба\3 семестр\ООП\Лабораторные работы\14\ConsoleApp2\ConsoleApp2\people19.xml", FileMode.OpenOrCreate))
            {
                formatter2.Serialize(fs, tom);
                Console.WriteLine("Объект сериализован");
            }

            // десериализация
            using (FileStream fs = new FileStream(@"D:\Даник\Учеба\3 семестр\ООП\Лабораторные работы\14\ConsoleApp2\ConsoleApp2\people19.xml", FileMode.OpenOrCreate))
            {
                Car newPerson = (Car)formatter2.Deserialize(fs);
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
            // создаем атрибут name
            XmlAttribute nameAttr = xDoc.CreateAttribute("Name");
            XmlAttribute nameAttr1 = xDoc.CreateAttribute("Compony");

            // создаем элементы company и age
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

            Console.ReadLine();
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
