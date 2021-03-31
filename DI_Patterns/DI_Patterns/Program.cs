using Microsoft.Extensions.DependencyInjection;

using System;

namespace DI_Patterns
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Injecting with .Net Core*/
            var serviceProvider = new ServiceCollection()
                .AddTransient<IDepartment, Engineering>()
                .AddTransient<Employee>()
                .BuildServiceProvider();

            var emp = serviceProvider.GetService<Employee>();
            emp.EmployeeId = 1;
            emp.EmployeeName = "Adil El Hadri";

            var emp1 = serviceProvider.GetService<Employee>();
            emp1.EmployeeId = 2;
            emp1.EmployeeName = "Imrane El Hadri";


            /*Manual Injection*/
            //Employee emp = new Employee(new Engineering());
            //emp.EmployeeId = 0;
            //emp.EmployeeName = "Adil El Hadri";

            //Employee emp1 = new Employee(new Marketing());
            //emp1.EmployeeId = 1;
            //emp1.EmployeeName = "Imrane El Hadri";


            Console.WriteLine("Emp Name: " + emp.EmployeeName + ", Department: " + emp.GetEmployeeDept().DeptName);
            Console.WriteLine();
            Console.WriteLine("Emp Name: " + emp1.EmployeeName + ", Department: " + emp1.GetEmployeeDept().DeptName);
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
        private readonly IDepartment EmployeeDept;

        public Employee(IDepartment dept)
        {
            EmployeeDept = dept ?? throw new ArgumentNullException();
        }

        // Adil
        public IDepartment GetEmployeeDept()
        {
            return EmployeeDept;
        }
    }
}
