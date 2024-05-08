namespace MentorTasks
{
    public class CompressString
    {
        public static void Main()
        {
            Console.WriteLine("enter string");
            string str = Console.ReadLine();

            string CompressedString = StringCompressor(str);
            Console.WriteLine($"Compressed String = {CompressedString}");
        }

        public static string StringCompressor(string str)
        {
            int count;
            int len = str.Length;
            string CompressedString = "";
            for (int i = 0;i<str.Length;)
            {
                char c = str[i];
                count = CountOccurrences(str, c,i);
                CompressedString = CompressedString + c + $"{count}";
                
                i += count;
               

            }
            return CompressedString;
        }
        public static int CountOccurrences(string str, char target, int startIndex)
        {
            int count = 0;
            for (int i = startIndex; i < str.Length; i++)
            {
                if (str[i] == target)
                {
                    count++;
                }
                else
                {
                    break;  
                }
            }
            return count;
        }
    }
}
