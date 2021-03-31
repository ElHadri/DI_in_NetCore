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
            emp.AssignDepartment(serviceProvider.GetService<IDepartment>());

            var emp1 = serviceProvider.GetService<Employee>();
            emp1.EmployeeId = 2;
            emp1.EmployeeName = "Imrane El Hadri";
            emp1.AssignDepartment(serviceProvider.GetService<IDepartment>());


            /*Manual Injection*/
            //Employee emp = new Employee(0, "Adil El Hadri");
            //emp.AssignDepartment(new Engineering());

            //Employee emp1 = new Employee(1, "Imrane El Hadri");
            //emp1.AssignDepartment(new Marketing());

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

        /* Default Constructor added for .NET Core 2.0 DI.
        * So that it can automatically create the instance.
        */
        public Employee() { }

        /* If we omit the parameterless constructor + Using DI container ==> runtime error
         * System.InvalidOperationException: 'Unable to resolve service for type 'System.Int32' while attempting to activate 'DI_Patterns.Employee'.'
         * 
         * Et même si je garde ce constructeur, il ne sera pas invoqué dans Composition Root
        */
        //public Employee(int id, string name)
        //{
        //    EmployeeId = id;
        //    EmployeeName = name;
        //}

        public void AssignDepartment(IDepartment department)
        {
            EmployeeDept = department ?? throw new ArgumentNullException("value");
            // Other business logic if required.
        }
    }
}
