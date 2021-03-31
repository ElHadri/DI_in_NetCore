using Microsoft.Extensions.DependencyInjection;

using System;

namespace Ambient_Context
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddTransient<IDepartment, Engineering>()
                .AddTransient<Employee>()
                .AddTransient<MarketingProvider>()
                .BuildServiceProvider();

            // Set the Current value by resolving with MarketingProvider.
            DepartmentProvider.Current = serviceProvider.GetService<MarketingProvider>();

            Employee emp = serviceProvider.GetService<Employee>();
            emp.EmployeeId = 1;
            emp.EmployeeName = "Adil El Hadri";
            emp.EmployeeDept = DepartmentProvider.Current.Department; // j'en ai besoin je l'appelle directement

            Employee emp1 = serviceProvider.GetService<Employee>();
            emp1.EmployeeId = 2;
            emp1.EmployeeName = "Imrane El Hadri";
            emp1.EmployeeDept = DepartmentProvider.Current.Department; // j'en ai besoin je l'appelle directement

            Console.WriteLine("Emp Name: " + emp.EmployeeName + ",Department: " + emp.EmployeeDept.DeptName); // Marketing
            Console.WriteLine("Emp Name: " + emp1.EmployeeName + ",Department: " + emp1.EmployeeDept.DeptName); // Marketing
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
    }


    abstract class DepartmentProvider
    {
        private static DepartmentProvider current;
        public static DepartmentProvider Current
        {
            get
            {
                if (current == null)
                    current = new DefaultDepartmentProvider();
                return current;
            }
            set
            {
                current = value ?? new DefaultDepartmentProvider();
            }
        }

        public virtual Department Department { get; }
    }

    class MarketingProvider : DepartmentProvider
    {
        public override Department Department
        {
            get { return new Marketing(); }
        }
    }

    class DefaultDepartmentProvider : DepartmentProvider
    {
        public override Department Department
        {
            get { return new Marketing(); }
        }
    }
}
