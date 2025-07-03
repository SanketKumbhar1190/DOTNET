namespace externalmethods_Linq_anonymous
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 100, b = 200;

            //calling the extension method
            a.Display();
            b.Display();
            a.ExtMethodForBaseClass();
        }

    }

    //to create an ext method
    //create a static method in a static class
    public static class ExtMethodsClass
    {
        //the first parameter must the type for which you are
        //writing the extension method, preceded by the 'this' keyword
        public static void Display(this int i)
        {
            Console.WriteLine(i);
        }

        //if you add an ext method for the base class,
        //it is also available for the derived class
        public static void ExtMethodForBaseClass(this object o)
        {
            Console.WriteLine(o);
        }
    }
}
