using DeepCloning.Models;

namespace DeepCloning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var department = new Department
            {
                Name = "Mechanical",
                Employees = new List<Employee>
                {
                    new Employee { Name = "Jhon" },
                }
            };
            var departmentClone = ObjExt.Clone<Department>(department);
        }
    }

    
}