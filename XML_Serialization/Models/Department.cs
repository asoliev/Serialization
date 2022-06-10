using System.Xml.Serialization;

namespace XmlSerializaion.Models
{
    [XmlRoot("Department", IsNullable = false)]
    public class Department
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlArray("Employees")]
        public List<Employee> Employees { get; set; }
    }
}