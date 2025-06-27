namespace CollectionsAssgn
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }

        public Employee(int empNo, string name, double salary)
        {
            EmpNo = empNo;
            Name = name;
            Salary = salary;
        }

        public override string ToString()
        {
            return $"Employee [EmpNo={EmpNo}, Name={Name}, Salary={Salary}]";
        }
    }

    public class Program
    {
        public static void Main()
        {
            List<Employee> employees = new List<Employee>();
            Console.WriteLine("Employee Management System");

            while (true)
            {
                Console.WriteLine("\n1. Add Employees");
                Console.WriteLine("2. Show Employee with Highest Salary");
                Console.WriteLine("3. Search Employee by EmpNo");
                Console.WriteLine("4. Show Nth Employee");
                Console.WriteLine("5. Convert Array to List and Display");
                Console.WriteLine("6. Convert List to Array and Display");
                Console.WriteLine("7. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                if (choice == "7") break;

                switch (choice)
                {
                    case "1":
                        // Add Employees in a loop
                        while (true)
                        {
                            Console.Write("Enter Employee Number: ");
                            int empNo = int.Parse(Console.ReadLine());
                            Console.Write("Enter Employee Name: ");
                            string name = Console.ReadLine();
                            Console.Write("Enter Employee Salary: ");
                            double salary = double.Parse(Console.ReadLine());

                            employees.Add(new Employee(empNo, name, salary));

                            Console.Write("Add another employee? (yes/no): ");
                            if (Console.ReadLine().ToLower() == "no") break;
                        }
                        break;

                    case "2":
                        // Show Employee with highest salary
                        if (employees.Any())
                        {
                            Employee highestPaid = employees.OrderByDescending(e => e.Salary).First();
                            Console.WriteLine($"Highest Salary Employee: {highestPaid}");
                        }
                        else
                        {
                            Console.WriteLine("No employees added yet.");
                        }
                        break;

                    case "3":
                        // Search Employee by EmpNo
                        Console.Write("Enter Employee Number to search: ");
                        int searchEmpNo = int.Parse(Console.ReadLine());
                        Employee found = employees.FirstOrDefault(e => e.EmpNo == searchEmpNo);
                        Console.WriteLine(found != null ? $"Found: {found}" : $"Employee with EmpNo {searchEmpNo} not found.");
                        break;

                    case "4":
                        // Show Nth Employee
                        Console.Write("Enter N to display Nth employee: ");
                        int n = int.Parse(Console.ReadLine());
                        if (n > 0 && n <= employees.Count)
                        {
                            Console.WriteLine($"Nth Employee: {employees[n - 1]}");
                        }
                        else
                        {
                            Console.WriteLine($"Invalid N. Must be between 1 and {employees.Count}");
                        }
                        break;

                    case "5":
                        // Convert Array to List and Display
                        Employee[] empArray = new Employee[]
                        {
                        new Employee(101, "Alice", 50000),
                        new Employee(102, "Bob", 60000),
                        new Employee(103, "Charlie", 55000)
                        };
                        List<Employee> empListFromArray = empArray.ToList();
                        Console.WriteLine("Employees from Array to List:");
                        foreach (var emp in empListFromArray)
                        {
                            Console.WriteLine(emp);
                        }
                        break;

                    case "6":
                        // Convert List to Array and Display
                        if (employees.Any())
                        {
                            Employee[] arrayFromList = employees.ToArray();
                            Console.WriteLine("Employees from List to Array:");
                            foreach (var emp in arrayFromList)
                            {
                                Console.WriteLine(emp);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No employees in the list to convert.");
                        }
                        break;

                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }
    }
}
