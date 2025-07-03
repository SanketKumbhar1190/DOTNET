namespace Linq_Thread_
{
    public class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }
        public decimal Basic { get; set; }
        public int DeptNo { get; set; }
        public string Gender { get; set; }
        public override string ToString()
        {
            string s = Name + "," + EmpNo.ToString() + "," + Basic.ToString() + "," + DeptNo.ToString();
            return s;
        }
    }
    public class Department
    {
        public int DeptNo { get; set; }
        public string DeptName { get; set; }
    }

    internal class Program
    {
        static List<Employee> lstEmp = new List<Employee>();
        static List<Department> lstDept = new List<Department>();
        public static void AddRecs()
        {
            lstDept.Add(new Department { DeptNo = 10, DeptName = "SALES" });
            lstDept.Add(new Department { DeptNo = 20, DeptName = "MKTG" });
            lstDept.Add(new Department { DeptNo = 30, DeptName = "IT" });
            lstDept.Add(new Department { DeptNo = 40, DeptName = "HR" });

            lstEmp.Add(new Employee { EmpNo = 1, Name = "Vikram", Basic = 10000, DeptNo = 10, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 2, Name = "Vishal", Basic = 11000, DeptNo = 10, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 3, Name = "Abhijit", Basic = 12000, DeptNo = 20, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 4, Name = "Mona", Basic = 11000, DeptNo = 20, Gender = "F" });
            lstEmp.Add(new Employee { EmpNo = 5, Name = "Shweta", Basic = 12000, DeptNo = 20, Gender = "F" });
            lstEmp.Add(new Employee { EmpNo = 6, Name = "Sanjay", Basic = 11000, DeptNo = 30, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 7, Name = "Arpan", Basic = 10000, DeptNo = 30, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 8, Name = "Shraddha", Basic = 11000, DeptNo = 40, Gender = "F" });
        }
        static Employee GetAllEmployees(Employee emp)
        {
            return emp;
        }
        static void Main1()
        {
            AddRecs();
            //var emps = from emp in lstEmp select emp;

            //var emps = lstEmp.Select(new Func<Employee, Employee>(GetAllEmployees));
            //var emps1 = lstEmp.Select(GetAllEmployees);
            //var emps2 = lstEmp.Select(delegate (Employee emp)
            //{
            //    return emp;
            //});
            //this ia an lambda expression 
            var emps3 = lstEmp.Select(emp => emp);
            foreach (var item in emps3)
            {
                Console.WriteLine(item);
            }

        }
        static void Main2()
        {
            AddRecs();
            //both emps and emps3 are Ienumerables of employee numbers (int)
            //This is a LINQ query syntax that selects only the EmpNo
            var emps = from emp in lstEmp select emp.EmpNo;
            var emps3 = lstEmp.Select(emp => emp.EmpNo);
            foreach (var item in emps3)
            {
                Console.WriteLine(item);
            }

        }
        static void Main4()
        {
            AddRecs();
            //this is just a basic LINQ query
            //var emps = from emp in lstEmp
            //           where emp.Basic > 10000
            //           select emp;

            //this is a method reference(predicate method)
            var emps2 = lstEmp.Where(IsBasicGreaterThan10000);

            //this is a lambda expression
            //emps3a is IEnumerable<Employee>
            var emps3a = lstEmp.Where(emp => emp.Basic > 10000);

            //applying Select after Where
            var emps3b = lstEmp.Where(emp => emp.Basic > 10000).Select(emp => emp);

            //Still works, but less efficient, because it maps before filtering
            var emps3c = lstEmp.Select(emp => emp).Where(emp => emp.Basic > 10000);

            //Filters employees, then selects their Name emps4b is IEnumerable<string>
            var emps4b = lstEmp.Where(emp => emp.Basic > 10000).Select(emp => emp.Name);

            //After Select(emp => emp.Name), the sequence is IEnumerable<string> So you no longer have access to emp.Basic — because emp is a string now
            //var emps4c = lstEmp.Select(emp => emp.Name).Where(emp => emp.Basic > 10000); //error

            //emps5b is IEnumerable<decimal>
            var emps5b = lstEmp.Where(emp => emp.Basic > 10000).Select(emp => emp.Basic);

            //var emps5c = lstEmp.Select(emp => emp.Basic).Where(emp => emp.Basic > 10000); 
            //After Select(emp => emp.Basic), emp is a decimal, not an Employee You can't do emp.Basic > 10000 on a decimal
            var emps5d = lstEmp.Select(emp => emp.Basic).Where(emp => emp > 10000); //works, but avoid

            foreach (var item in emps2)
            {
                Console.WriteLine(item);
            }
        }
        static bool IsBasicGreaterThan10000(Employee emp)
        {
            return emp.Basic > 10000;
        }
        
        //deferred execution below
        static void Main()
        {
            AddRecs(); // Adds 8 employees to the lstEmp list

            // ❌ LINQ query is defined here — but NOT executed yet (deferred execution)
            var emps = from emp in lstEmp select emp;

            Console.WriteLine();

            lstEmp.RemoveAt(0); // Modify the underlying data (remove Vikram)

            // ✅ LINQ query executes here — iterates over current lstEmp (7 employees)
            foreach (var emp in emps)
            {
                Console.WriteLine(emp.Name + "," + emp.EmpNo);
            }
            Console.ReadLine(); // Pause to view the first output

            Console.WriteLine();

            // Modify the data again — add a new employee
            lstEmp.Add(new Employee { EmpNo = 9, Name = "New", Basic = 11000, DeptNo = 40, Gender = "F" });

            // ✅ LINQ query executes again — this time includes the newly added employee (8 employees)
            foreach (var emp in emps)
            {
                Console.WriteLine(emp.Name + "," + emp.EmpNo);
            }
            Console.ReadLine(); // Pause to view the second output
        }

    }
}
