namespace Employee1
{
    public class Employee
    {
        // Private fields
        private string name;
        private int empNo;
        private decimal basic;
        private short deptNo;

        // Properties
        public string Name
        {
            get => name;
            set
            {
                if (!string.IsNullOrEmpty(value))
                    name = value;
                else
                    throw new ArgumentException("Name cannot be blank.");
            }
        }

        public int EmpNo
        {
            get => empNo;
            set
            {
                if (value > 0)
                    empNo = value;
                else
                    throw new ArgumentException("Employee number must be greater than 0.");
            }
        }

        public decimal Basic
        {
            get => basic;
            set
            {
                if (value >= 10000 && value <= 100000)
                    basic = value;
                else
                    throw new ArgumentException("Basic salary must be between 10,000 and 100,000.");
            }
        }

        public short DeptNo
        {
            get => deptNo;
            set
            {
                if (value > 0)
                    deptNo = value;
                else
                    throw new ArgumentException("Department number must be greater than 0.");
            }
        }

        // Constructor
        public Employee(string name, int empNo, decimal basic, short deptNo)
        {
            Name = name;
            EmpNo = empNo;
            Basic = basic;
            DeptNo = deptNo;
        }

        public override string ToString()
        {
            return "name: " + Name+ " empno: " + EmpNo + " basic: " + Basic + " DeptNo: " + DeptNo;
        }
        // Method to calculate net salary
        public decimal GetNetSalary()
        {
            return Basic + (Basic * 0.10m); // Basic salary + 10% bonus
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
           
             Employee emp = new Employee("John Doe", 101, 50000, 10);
            Console.WriteLine(emp);
            
        }
    }
}