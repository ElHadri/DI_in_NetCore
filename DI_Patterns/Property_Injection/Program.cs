using System;

namespace DI_Patterns
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Manual Injection*/
            Employee emp = new Employee(0, "Adil El Hadri");
            emp.EmployeeDept = new Engineering();

            Employee emp1 = new Employee(1, "Imrane El Hadri");
            emp1.EmployeeDept = new Marketing();

            Console.WriteLine("Emp Name: " + emp.EmployeeName + ", Department: " + emp.EmployeeDept.DeptName);
            Console.WriteLine("Emp Name: " + emp1.EmployeeName + ", Department: " + emp1.EmployeeDept.DeptName);
        }
    }

    public interface IDepartment
    {
        int DeptId { get; set; }
        string DeptName { get; set; }
    }
    public class Department : IDepartment
    {
        public int DeptId { get; set; }
        public string DeptName { get; set; }
    }
    public class Engineering : Department
    {
        public Engineering()
        {
            DeptName = "Engineering";
        }
    }
    public class Marketing : Department
    {
        public Marketing()
        {
            DeptName = "Marketing";
        }
    }
    public class Employee
    {
        public int EmployeeId;
        public string EmployeeName;
        public IDepartment EmployeeDept;

        public Employee(int id, string name)
        {
            EmployeeId = id;
            EmployeeName = name;
        }
    }
}
