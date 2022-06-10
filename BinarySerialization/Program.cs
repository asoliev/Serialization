// See https://aka.ms/new-console-template for more information
using BinarySerialization.Models;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

const string fileName = "MyFile.bin";

Serialize();
Deserilize();

void Serialize()
{
    var department = new Department
    {
        Name = "Mechanical",
        Employees = new List<Employee>
        {
            new Employee { Name = "Jhon" },
        }
    };
    IFormatter formatter = new BinaryFormatter();
    using (var stream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
    {
        formatter.Serialize(stream, department);
    }
}
void Deserilize()
{
    IFormatter formatter = new BinaryFormatter();
    using (var stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
    {
        var obj = (Department)formatter.Deserialize(stream);
    }
}