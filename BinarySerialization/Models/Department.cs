namespace BinarySerialization.Models
{
    [Serializable]
    public class Department
    {
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }
    }
}