using System;

namespace InheritanceAssign
{
 
    public interface IDbFunctions
    {
        void Insert();
    }

   
    public abstract class Employee : IDbFunctions
    {
        private string name;
        private readonly int empNo;
        private short deptNo;
        private static int counter = 1; 

        
        public string Name
        {
            get => name;
            set
            {
                if (!string.IsNullOrEmpty(value))
                    name = value;
                else
                    Console.WriteLine("Name cannot be blank.");
            }
        }

        public int EmpNo
        {
            get => empNo;
        }

        public short DeptNo
        {
            get => deptNo;
            set
            {
                if (value > 0)
                    deptNo = value;
                else
                    Console.WriteLine("Department number must be greater than 0.");
            }
        }

        public abstract decimal Basic { get; set; }

        
        public Employee(string name, short deptNo)
        {
            empNo = counter++;
            Name = name;
            DeptNo = deptNo;
        }

        public Employee(string name, short deptNo, decimal basic) : this(name, deptNo)
        {
            Basic = basic;
        }

        
        public abstract decimal CalcNetSalary();

       
        public virtual void Insert()
        {
            Console.Write("Enter Name: ");
            Name = Console.ReadLine();

            Console.Write("Enter Department Number: ");
            if (short.TryParse(Console.ReadLine(), out short deptNo))
                DeptNo = deptNo;
            else
                Console.WriteLine("Invalid department number.");
        }
    }

    
    public class Manager : Employee
    {
        private string designation;
        private decimal basic;

        
        public string Designation
        {
            get => designation;
            set
            {
                if (!string.IsNullOrEmpty(value))
                    designation = value;
                else
                    Console.WriteLine("Designation cannot be blank.");
            }
        }

        public override decimal Basic
        {
            get => basic;
            set
            {
                if (value >= 25000 && value <= 80000)
                    basic = value;
                else
                    Console.WriteLine("Basic salary must be between 25000 and 80000.");
            }
        }

       
        public Manager(string name, short deptNo, string designation) : base(name, deptNo)
        {
            Designation = designation;
        }

        public Manager(string name, short deptNo, string designation, decimal basic) : base(name, deptNo, basic)
        {
            Designation = designation;
        }

        public override decimal CalcNetSalary()
        {
            return Basic + (Basic * 0.10m); 
        }

        public override void Insert()
        {
            base.Insert();
            Console.Write("Enter Designation: ");
            Designation = Console.ReadLine();
            Console.Write("Enter Basic Salary: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal basicSalary))
                Basic = basicSalary;
            else
                Console.WriteLine("Invalid basic salary.");
        }
    }

   
    public class GeneralManager : Manager
    {
        private string perks;
        private decimal basic;

        
        public string Perks
        {
            get => perks;
            set => perks = value;
        }

        public override decimal Basic
        {
            get => basic;
            set
            {
                if (value >= 50000 && value <= 120000)
                    basic = value;
                else
                    Console.WriteLine("Basic salary must be between 50000 and 120000.");
            }
        }

        
        public GeneralManager(string name, short deptNo, string designation, string perks)
            : base(name, deptNo, designation)
        {
            Perks = perks;
        }

        public GeneralManager(string name, short deptNo, string designation, string perks, decimal basic)
            : base(name, deptNo, designation, basic)
        {
            Perks = perks;
        }

        
        public override decimal CalcNetSalary()
        {
            return Basic + (Basic * 0.15m); 
        }

        public override void Insert()
        {
            base.Insert();
            Console.Write("Enter Perks: ");
            Perks = Console.ReadLine();
            Console.Write("Enter Basic Salary: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal basicSalary))
                Basic = basicSalary;
            else
                Console.WriteLine("Invalid basic salary.");
        }
    }

    
    public class CEO : Employee
    {
        private decimal basic;

        
        public override decimal Basic
        {
            get => basic;
            set
            {
                if (value >= 100000 && value <= 200000)
                    basic = value;
                else
                    Console.WriteLine("Basic salary must be between 100000 and 200000.");
            }
        }

        
        public CEO(string name, short deptNo) : base(name, deptNo)
        {
        }

        public CEO(string name, short deptNo, decimal basic) : base(name, deptNo, basic)
        {
        }

        
        public sealed override decimal CalcNetSalary()
        {
            return Basic + (Basic * 0.20m); 
        }

        public override void Insert()
        {
            base.Insert();
            Console.Write("Enter Basic Salary: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal basicSalary))
                Basic = basicSalary;
            else
                Console.WriteLine("Invalid basic salary.");
        }
    }

   
    public class Program
    {
        public static void Main()
        {
           
            Manager manager = new Manager("John Doe", 10, "Team Lead", 30000);
            GeneralManager gm = new GeneralManager("Jane Smith", 20, "Senior Manager", "Car, Housing", 60000);
            CEO ceo = new CEO("Alice Johnson", 30, 150000);

            
            Console.WriteLine("\nManager Details:");
            manager.Insert();
            Console.WriteLine($"Manager Net Salary: {manager.CalcNetSalary()}");

            Console.WriteLine("\nGeneral Manager Details:");
            gm.Insert();
            Console.WriteLine($"General Manager Net Salary: {gm.CalcNetSalary()}");

            Console.WriteLine("\nCEO Details:");
            ceo.Insert();
            Console.WriteLine($"CEO Net Salary: {ceo.CalcNetSalary()}");
        }
    }
}