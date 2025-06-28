using System;
using System.Collections.Generic; // Required for IComparable<T> and IComparer<T>

namespace Arrays
{
    internal class Comaparable_comparer
    {
        static void Main(string[] args)
        {
            Emp[] arr = new Emp[5];
            arr[0] = new Emp { EmpNo = 5, Name = "Alice", Basic = 1000, DeptNo = 10 };
            arr[1] = new Emp { EmpNo = 1, Name = "Charlie", Basic = 200, DeptNo = 20 };
            arr[2] = new Emp { EmpNo = 2, Name = "Bob", Basic = 3000, DeptNo = 20 };
            arr[3] = new Emp { EmpNo = 4, Name = "Priya", Basic = 1500, DeptNo = 10 };
            arr[4] = new Emp { EmpNo = 3, Name = "Zoe", Basic = 30000, DeptNo = 30 };

            Console.WriteLine("Original Array:");
            foreach (Emp emp in arr)
            {
                Console.WriteLine(emp);
            }
            Console.WriteLine("\n--------------------\n");

            // --- Sorting by Basic (using IComparable<Emp> in Emp class - the default sort) ---
            Console.WriteLine("Sorted Array (by Basic - default IComparable<Emp>):");
            Array.Sort(arr); // This uses the CompareTo method defined in the Emp class
            foreach (Emp emp in arr)
            {
                Console.WriteLine(emp);
            }
            Console.WriteLine("\n--------------------\n");

            // --- Implementing and Using IComparer<Emp> for sorting by Name ---
            Console.WriteLine("Sorted Array (by Name - using EmpNameComparer):");
            // To sort by Name, we create an instance of EmpNameComparer and pass it to Array.Sort
            Array.Sort(arr, new EmpNameComparer());
            foreach (Emp emp in arr)
            {
                Console.WriteLine(emp);
            }
            Console.WriteLine("\n--------------------\n");

            // --- Implementing and Using IComparer<Emp> for sorting by EmpNo ---
            Console.WriteLine("Sorted Array (by EmpNo - using EmpNoComparer):");
            Array.Sort(arr, new EmpNoComparer());
            foreach (Emp emp in arr)
            {
                Console.WriteLine(emp);
            }
        }
    }

    // Emp class defines its 'natural' or default sort order (by Basic)
    public class Emp : IComparable<Emp>
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }
        public decimal Basic { get; set; }
        public short DeptNo { get; set; }

        // This defines the default sorting behavior for Emp objects
        public int CompareTo(Emp? other)
        {
            if (other == null) return 1; // Current object is greater than null
            return this.Basic.CompareTo(other.Basic); // Sorts by Basic property
        }

        public override string ToString()
        {
            // Adding current year to show it's current
            return $"Empno={EmpNo}, Name={Name}, Basic={Basic:C}, DeptNo={DeptNo} (as of {DateTime.Now.Year})";
        }
    }

    // --- New Classes Implementing IComparer<Emp> ---

    // This class provides a way to compare two Emp objects by their Name property
    public class EmpNameComparer : IComparer<Emp>
    {
        public int Compare(Emp? x, Emp? y)
        {
            // Handle null cases gracefully (conventionally null comes before non-null)
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;

            // Use string.Compare for alphabetical sorting of names
            return string.Compare(x.Name, y.Name);
        }
    }

    // This class provides a way to compare two Emp objects by their EmpNo property
    public class EmpNoComparer : IComparer<Emp>
    {
        public int Compare(Emp? x, Emp? y)
        {
            // Handle null cases gracefully
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;

            // Use int.CompareTo for numerical sorting of EmpNo
            return x.EmpNo.CompareTo(y.EmpNo);
        }
    }
}