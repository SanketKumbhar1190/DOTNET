using System;
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
        Console.WriteLine("CDAC and Employee Management System");

        // Part 1: CDAC Batches and Student Marks
        Console.WriteLine("\n--- CDAC Batches and Student Marks ---");
        Console.Write("Enter number of batches: ");
        int numBatches = int.Parse(Console.ReadLine());

        // Create jagged array to store marks for each batch
        int[][] batchMarks = new int[numBatches][];

        // Accept number of students and marks for each batch
        for (int i = 0; i < numBatches; i++)
        {
            Console.Write($"Enter number of students in batch {i + 1}: ");
            int numStudents = int.Parse(Console.ReadLine());
            batchMarks[i] = new int[numStudents];

            Console.WriteLine($"Enter marks for {numStudents} students in batch {i + 1}:");
            for (int j = 0; j < numStudents; j++)
            {
                Console.Write($"Student {j + 1} mark: ");
                batchMarks[i][j] = int.Parse(Console.ReadLine());
            }
        }

        // Display marks
        Console.WriteLine("\nStudent Marks by Batch:");
        for (int i = 0; i < batchMarks.Length; i++)
        {
            Console.Write($"Batch {i + 1}: ");
            foreach (int mark in batchMarks[i])
            {
                Console.Write($"{mark} ");
            }
            Console.WriteLine();
        }

        // Part 2: Employee Array Operations
        Console.WriteLine("\n--- Employee Management ---");
        Console.Write("Enter number of employees: ");
        int numEmployees = int.Parse(Console.ReadLine());

        // Create array of Employee objects
        Employee[] employees = new Employee[numEmployees];

        // Accept details for all employees
        for (int i = 0; i < numEmployees; i++)
        {
            Console.WriteLine($"\nEnter details for Employee {i + 1}:");
            Console.Write("Employee Number: ");
            int empNo = int.Parse(Console.ReadLine());
            Console.Write("Employee Name: ");
            string name = Console.ReadLine();
            Console.Write("Employee Salary: ");
            double salary = double.Parse(Console.ReadLine());

            employees[i] = new Employee(empNo, name, salary);
        }

        // Display employee with highest salary
        Employee highestPaid = employees.OrderByDescending(e => e.Salary).FirstOrDefault();
        if (highestPaid != null)
        {
            Console.WriteLine($"\nEmployee with highest salary: {highestPaid}");
        }

        // Search employee by EmpNo
        Console.Write("\nEnter Employee Number to search: ");
        int searchEmpNo = int.Parse(Console.ReadLine());
        Employee found = employees.FirstOrDefault(e => e.EmpNo == searchEmpNo);
        if (found != null)
        {
            Console.WriteLine($"Found: {found}");
        }
        else
        {
            Console.WriteLine($"Employee with EmpNo {searchEmpNo} not found.");
        }
    }
}