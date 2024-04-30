namespace delegatesPractice
{
    
       
    public delegate void ArithmeticHandler(int firstNmuber,int secondNmuber);
        public class Operations
        {
            public void Addition(int firstNumber, int secondNumber)
            {
                Console.WriteLine("Addtion of {0} and {1} is {2}", firstNumber, secondNumber, firstNumber + secondNumber);

            }
            public void Subtraction(int firstNumber, int secondNumber)
            {
                Console.WriteLine("Subtraction of {0} and {1} is {2}", firstNumber, secondNumber, firstNumber - secondNumber);

            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                
                Operations obj = new Operations();

                ArithmeticHandler arithObj1, arithObj2, arithObj3;

                arithObj1 = new ArithmeticHandler(obj.Addition);
                arithObj2 = new ArithmeticHandler(obj.Subtraction);


                ArithmeticHandler arithObj = new ArithmeticHandler(obj.Addition);

                //Multicasting a delegate
                arithObj3 = arithObj1 + arithObj2;
                 
                arithObj(1,2);

                arithObj1(2, 3); // single casting

                arithObj2(3, 2); // single casting

                arithObj3(6, 4); // multi casting

                Console.ReadKey();
            }
        }
    }
  