

// ........... Inheritance in C# ...........


using System;

namespace InheritanceDemo
{
    public class Person
    {
        private string name;
        private int age;

        public void GetInformation()
        {
            Console.WriteLine("Enter name:");
            name = Console.ReadLine();

            Console.WriteLine("Enter age:");
            age = Convert.ToInt32(Console.ReadLine());
        }

        public void DisplayInformation()
        {
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Age: " + age);
        }
    }

    public class Employee : Person
    {
        protected int EmployeeScore;
        private string company;
        private int EmployeeId;

        public void GetEmployeeInformation()
        {
            Console.WriteLine("Enter company name:");
            company = Console.ReadLine();

            Console.WriteLine("Enter employee ID:");
            EmployeeId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter employee score:");
            EmployeeScore = Convert.ToInt32(Console.ReadLine());
        }

        public void DisplayCompany()
        {
            Console.WriteLine("Company: " + company);
            Console.WriteLine("Employee ID: " + EmployeeId);
            Console.WriteLine("Employee Score: " + EmployeeScore);
        }
    }

    interface IDepartment
    {
        string DepartmentName { get; set; }
        void DisplayDepartmentDetails();
    }

    public class GradeLevel : Employee, IDepartment
    {
        
        public string DepartmentName { get; set; }

        public void CheckEligible()
        {
            Console.WriteLine("Every employee should have above 150 score");

            if (EmployeeScore > 150)
                Console.WriteLine("You are Eligible!");
            else
                Console.WriteLine("You are not Eligible!");
        }

        public void DisplayDepartmentDetails()
        {
            Console.WriteLine("Department: " + DepartmentName);
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            GradeLevel emp = new GradeLevel();

            emp.GetInformation();
            emp.GetEmployeeInformation();

            emp.DepartmentName = "IT Department";

            Console.WriteLine("\nEmployee Information:");
            emp.DisplayInformation();
            emp.DisplayCompany();
            emp.DisplayDepartmentDetails();
            emp.CheckEligible();
        }
    }
}
