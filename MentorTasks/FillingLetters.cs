namespace MentorTasks
{

    public class FillingLetters
    {
        static void PrintLettersInBetween(char start, char end)
        {
            if (start + 1 == end)
            {
                Console.WriteLine("No Letters in Between");
                return;
            }
            for (char c = (char)(start + 1); c < end; c++)
            {
                Console.WriteLine(c);
            } 
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter the starting letter");
            char start = Convert.ToChar(Console.ReadLine() ?? "a");
            Console.WriteLine("Enter the Ending Letter");
          char end = Convert.ToChar(Console.ReadLine() ?? "a");
            Console.WriteLine($"letters between {start} and {end} are :");
            PrintLettersInBetween(start,end);
        }

       
    }
}
