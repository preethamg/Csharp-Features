using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Object_Serialization_in_C_sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal animal1 = new Animal(name:"Lion",height:4.57,weight:272.05);
            BinarySerialize(animal1);
            PrintData(true, animal1,true);
            BinaryDeserialize();

            Console.WriteLine("***********************************************");

            Animal animal2 = new Animal(name: "Tiger", height: 4.3, weight: 243.54);
            XMLSerializer(animal2);
            PrintData(true, animal2, false);
            XMLDeserializer();
            Console.ReadKey();
        }

        static void BinarySerialize(Animal animal)
        {
            FileStream stream = File.Open("animal.txt", FileMode.Create);

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(stream, animal);
            stream.Close();
        }

        static void BinaryDeserialize()
        {
            FileStream stream = File.Open("animal.txt", FileMode.Open);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            Animal animal = (Animal)binaryFormatter.Deserialize(stream);
            stream.Close();
            PrintData(false, animal,true);
        }

        static void XMLSerializer(Animal animal)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Animal));
            StreamWriter streamWriter = new StreamWriter("animal.xml");
            xmlSerializer.Serialize(streamWriter, animal);
            streamWriter.Close();
        }

        static void XMLDeserializer()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Animal));
            StreamReader streamReader = new StreamReader("animal.xml");
            Animal animal=(Animal)xmlSerializer.Deserialize(streamReader);
            PrintData(false, animal, false);
        }

        static void PrintData(bool isSerialized,Animal animal,bool isBinarySerializer)
        {
            if (isSerialized)
            {
                if (isBinarySerializer)
                {
                    Console.WriteLine("This Animal Data is Serialized in Binary Format");
                }
                else
                {
                    Console.WriteLine("This Animal Data is Serialized in XML Format");
                }
            }
            else
            {
                if (isBinarySerializer)
                {
                    Console.WriteLine("This Animal Data is Deserialized from Binary");
                }
                else
                {
                    Console.WriteLine("This Animal Data is Deserialized from XML");
                }
            }
            Console.WriteLine(animal.ToString());
            Console.WriteLine();
        }
    }


    [Serializable()]
    public class Animal : ISerializable
    {
        public string Name { get; set; }

        public double Height { get; set; }

        public double Weight { get; set; }

        public Animal()
        {

        }

        public Animal(string name, double height, double weight)
        {
            this.Name = name;
            this.Height = height;
            this.Weight = weight;
        }

        public override string ToString()
        {
            return String.Format("{0} weighs {1} Kgs and is {2} Feet Tall", this.Name, this.Weight, this.Height);
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", this.Name);
            info.AddValue("Weight", this.Weight);
            info.AddValue("Height", this.Height);
        }

        public Animal(SerializationInfo info, StreamingContext context)
        {
            Name = (string)info.GetValue("Name", typeof(string));
            Height = (double)info.GetValue("Height", typeof(double));
            Weight = (double)info.GetValue("Weight", typeof(double));
        }
    }
}
