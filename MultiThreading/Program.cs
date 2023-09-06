using System.Resources;

namespace MultiThreading
{
    class Program 
    {
        public static void Main(string[] args)
        {
            TaskParllelLibrary obj = new TaskParllelLibrary();
            string[] words = obj.CreateWordArray(@"https://gutenberg.org/files/54700/54700-0.txt");
            DateTime start = DateTime.Now;
            obj.GetLongestWords(words);
            obj.GetLongestWordsWithLength(words);
            obj.GetFirstWords(words);
            DateTime end = DateTime.Now;
            Console.WriteLine("Time taken from to complete the task Without using thread is {0}",start-end);
            DateTime start1 = DateTime.Now;
            obj.TaskParllelOperation();
            DateTime end1 = DateTime.Now;
            Console.WriteLine("Time taken from to complete the task using thread is {0}", start1 - end1);
        }
    }
}