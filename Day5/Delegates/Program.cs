namespace Delegates_Lambdas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int, int> o1 = MakeDouble;
            Console.WriteLine(o1(3));

            //here the last argument is an return type
            Func<int, int, int> o2 = (a, b) => a + b;
            Console.WriteLine(o2(10, 5));

            Func<int, bool> o3 = a =>
            {
                if (a % 2 == 0)
                    return true;
                else
                    return false;

            };
            Console.WriteLine(o3(10));

            // predicate always returns in boolean types
            Predicate<int> o4 = a => a % 2 == 0;
            Console.WriteLine(o4(10));

            //{ EmpNo = 1, Basic = 11100 } this an obj initializer list
            Employee emp = new Employee { EmpNo = 1, Basic = 11100 };
            Predicate<Employee> o5 = emp => emp.Basic > 10000;
            Console.WriteLine(o5(emp));
        }


        static int MakeDouble(int a)
        {
            return a * 2;
        }
    }
    public class Employee
    {
        public int EmpNo { get; set; }
        public decimal Basic { get; set; }

        public Employee()
        {
            this.EmpNo = 1;
        }
    }
}
