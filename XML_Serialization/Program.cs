// See https://aka.ms/new-console-template for more information
using System.Xml.Serialization;
using XmlSerializaion.Models;

const string fileName = "MyFile.xml";
Serialize();
Deserialize();

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
    XmlSerializer serializer = new(typeof(Department));
    using (TextWriter writer = new StreamWriter(fileName))
    {
        serializer.Serialize(writer, department);
    }
}
void Deserialize()
{
    // Create an instance of the XmlSerializer class;
    // specify the type of object to be deserialized.
    XmlSerializer serializer = new(typeof(Department));
    
    /* If the XML document has been altered with unknown
    nodes or attributes, handle them with the
    UnknownNode and UnknownAttribute events.*/
    serializer.UnknownNode += new XmlNodeEventHandler(serializer_UnknownNode);
    serializer.UnknownAttribute += new XmlAttributeEventHandler(serializer_UnknownAttribute);
    
    Department department;

    using (var fs = new FileStream(fileName, FileMode.Open))
    {
        object? obj = serializer.Deserialize(fs);
        if (obj != null) department = (Department)obj;
    }
}

void serializer_UnknownNode(object? sender, XmlNodeEventArgs e)
{
    Console.WriteLine("Unknown Node:" + e.Name + "\t" + e.Text);
}

void serializer_UnknownAttribute(object? sender, XmlAttributeEventArgs e)
{
    System.Xml.XmlAttribute attr = e.Attr;
    Console.WriteLine("Unknown attribute " + attr.Name + "='" + attr.Value + "'");
}