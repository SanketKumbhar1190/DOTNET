namespace Employee2 { 
using System;

public class Employee
{
    // Static field to keep track of next employee number
    private static int nextEmpNo = 1;

    // Private backing fields
    private string name;
    private readonly int empNo;
    private decimal basic;
    private short deptNo;

    // Constants for basic salary range
    private const decimal MIN_BASIC = 5000;
    private const decimal MAX_BASIC = 100000;

    // Properties
    public string Name
    {
        get => name;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Name cannot be blank or empty.");
            name = value;
        }
    }

    public int EmpNo
    {
        get => empNo;
    }

    public decimal Basic
    {
        get => basic;
        set
        {
            if (value < MIN_BASIC || value > MAX_BASIC)
                throw new ArgumentException($"Basic salary must be between {MIN_BASIC} and {MAX_BASIC}.");
            basic = value;
        }
    }

    public short DeptNo
    {
        get => deptNo;
        set
        {
            if (value <= 0)
                throw new ArgumentException("Department number must be greater than 0.");
            deptNo = value;
        }
    }

   
    public Employee()
    {
        empNo = nextEmpNo++;
        Name = "Default";
        Basic = MIN_BASIC;
        DeptNo = 1;
    }

    public Employee(string name) : this()
    {
        Name = name;
    }

    public Employee(string name, decimal basic) : this(name)
    {
        Basic = basic;
    }

    public Employee(string name, decimal basic, short deptNo) : this(name, basic)
    {
        DeptNo = deptNo;
    }

    
    public decimal GetNetSalary()
    {
       
        decimal hra = Basic * 0.30m;
        decimal da = Basic * 0.20m;
        decimal tax = Basic * 0.10m;
        return Basic + hra + da - tax;
    }
}


public class Program
{
    public static void Main()
    {
        // Test case 1
        Employee o1 = new Employee();
        Employee o2 = new Employee();
        Employee o3 = new Employee();

        Console.WriteLine(o1.EmpNo); 
        Console.WriteLine(o2.EmpNo); 
        Console.WriteLine(o3.EmpNo); 

        // Test case 2
        Console.WriteLine(o3.EmpNo); 
        Console.WriteLine(o2.EmpNo); 
        Console.WriteLine(o1.EmpNo); 
    }
}
}