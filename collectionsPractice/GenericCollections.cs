using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsPractice
{
    public class ListExample<T>
    {
        private T firstNumber;

        public T FirstNumber
        {
            get { return firstNumber; }
            set { firstNumber = value; }
        }
        private T secondNumber;

        public T SecondNumber
        {
            get { return secondNumber; }
            set { secondNumber = value; }
        }
        public  void Run()
        {
            List<T> numbers = new List<T>();
            numbers.Add(FirstNumber);
            numbers.Add(SecondNumber);
            T firstitem = numbers[0];
            Console.WriteLine($"First number: {firstitem}");
        }
    }

    public class DictionaryExample<T1,T2>
    {
         
          private T1 name;

        public T1 Name
        {
            get { return name; }
            set { name = value; }
        }
        private T2 age;

        public T2 Age
        {
            get { return age; }
            set {age = value; }
        }
        public  void Run()
        { 
        Dictionary<T1,T2> ages = new Dictionary<T1,T2>();

            ages.Add(Name,age);
            
            Console.WriteLine($"firstone's age: {age}");
        }
    }

    public class HashSetExample<t>
    {
        private t name;

        public t Name
        {
            get { return name; }
            set { name = value; }
        }
        public  void Run()
        {
            HashSet<t> names = new HashSet<t>();
            names.Add(Name);
           
            Console.WriteLine($"Number of names: {names.Count}");
        }
    }


    public class QueueExample<t>
    {
        private t number1;
        public t Number1
        {
            get { return number1; }
            set { number1 = value; }
        }
        private t number2;
        public t Number2
        {
            get { return number2; }
            set { number2 = value; }
        }
        public  void Run()
        {
            Queue<t> queue = new Queue<t>();
            queue.Enqueue(number1);
            queue.Enqueue(number2);
            t firstItem = queue.Dequeue();
            Console.WriteLine($"First item: {firstItem}");
        }
    }
        public class StackExample
        {
            public void Run<t>()
            {
                Stack<t> stack = new Stack<t>();

            int intValue = 10;
            stack.Push((t)(object)intValue);
            t topItem = stack.Pop();
                Console.WriteLine($"Top item: {topItem}");
            }
        }



    class Program
    {
        static void Main(string[] args)
        {

           // List
           ListExample<int> list = new ListExample<int>();
            list.FirstNumber = 1;
            list.SecondNumber = 2;
            list.Run();


           // Dictionary
           DictionaryExample<string, int> dictionaryExample = new DictionaryExample<string, int>();
            dictionaryExample.Name = "john";
            dictionaryExample.Age = 30;
            dictionaryExample.Run();


           // HashSet
          HashSetExample<string> names = new HashSetExample<string>();
            names.Name = "john";
            names.Run();


            //Queue
            QueueExample<int> queue = new QueueExample<int>();
            queue.Number1 = 1;
            queue.Number2 = 2;
            queue.Run();

           // Stack
           StackExample stacks = new StackExample();
           
            stacks.Run<int>();
           


        }
    }
}



