namespace MentorTasks
{

    public class MyClass
    {
        public int Number { get; set; }
    }
    public class RefAndValueTypes
    {
        public static void ReferenceTypeByValue(MyClass obj)
        {
           // obj = new MyClass();
            obj.Number = 20;
        }
        public static void ValueTypeByReference(ref int a)
        {
            a = 20;

        }

        public static void ReferenceTypeByReference(ref MyClass obj)
        {
            obj.Number = 20;
        }
        public static void ValueTypeByValue(int a)
        {
            a = 20;
        }
        public static void Main()
        {
            int x = 10;
            ValueTypeByValue(x);
            Console.WriteLine(x);  // Output: 10


            MyClass obj = new MyClass();
            obj.Number = 10;
            ReferenceTypeByReference(ref obj);
            Console.WriteLine(obj.Number);  // Output: 20

            int y = 10;
            ValueTypeByReference(ref y);
            Console.WriteLine(y);  // Output: 20



            MyClass obj1 = new MyClass();
            obj1.Number = 10;
            ReferenceTypeByValue(obj1);
            Console.WriteLine(obj1.Number);  // Output: 10


        }



    }





}


