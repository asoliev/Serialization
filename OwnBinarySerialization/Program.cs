// See https://aka.ms/new-console-template for more information
using OwnBinarySerialization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
//using System.Runtime.Serialization.Formatters.Soap;

string fileName = "dataStuff.myData";

IFormatter formatter = new BinaryFormatter();
//IFormatter formatter = new SoapFormatter();

SerializeItem(fileName, formatter);
DeserializeItem(fileName, formatter);

void SerializeItem(string fileName, IFormatter formatter)
{
    SimpleClass t = new()
    {
        Id = 1,
        Name = "Hello World"
    };

    using (FileStream fs = new(fileName, FileMode.Create))
    {
        formatter.Serialize(fs, t);
    }
}
void DeserializeItem(string fileName, IFormatter formatter)
{
    using (FileStream fs = new FileStream(fileName, FileMode.Open))
    {
        SimpleClass t = (SimpleClass)formatter.Deserialize(fs);
    }
}