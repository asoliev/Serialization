// See https://aka.ms/new-console-template for more information
using JsonSerialization.Models;
using System.Text.Json;

const string fileName = "MyFile.json";

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
    string jsonString = JsonSerializer.Serialize(department);
    using (var fs = new FileStream(fileName, FileMode.Append, FileAccess.Write, FileShare.None))
    {
        using (var sw = new StreamWriter(fs))
        {
            sw.WriteLine(jsonString);
        }
    }
}
void Deserilize()
{
    using (var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
    {
        using (var sr = new StreamReader(fs))
        {
            string jsonString = sr.ReadToEnd();
            var department = JsonSerializer.Deserialize<Department>(jsonString);
        }
    }
}