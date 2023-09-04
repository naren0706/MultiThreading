﻿using System.Net;

namespace MultiThreading
{
    internal class TaskParllelLibrary
    {
        public void TaskParllelOperation()
        {
            string[] words = CreateWordArray(@"https://gutenberg.org/files/54700/54700-0.txt");
            Parallel.Invoke(
            () =>
            {
                Console.WriteLine("Frist task");
                GetLongestWords(words);
                Console.WriteLine("----1 task----");

            }, () =>
            {
                Console.WriteLine("Second task");
                GetFirstWords(words); 
                Console.WriteLine("----2 task----");


            }, () =>
            {
                Console.WriteLine("third task");
                GetLongestWordsWithLength(words);
                Console.WriteLine("----3 task----");


            }
            );
        }

        private string[] CreateWordArray(string v)
        {
            string data  = new WebClient().DownloadString(v);
            return data.Split(new char[] { ' ', ',', '-', '_', '/', '.' },StringSplitOptions.RemoveEmptyEntries);
        }

        private void GetFirstWords(string[] words)
        {
            var result = words.Take(10);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        private void GetLongestWords(string[] words)
        {
            Array.Sort(words);
            Console.WriteLine(words[words.Length-1]);
        }

        private void GetLongestWordsWithLength(string[] words)
        {
            var result = words.Where(x=> x.Length > 6).Take(10).ToList();
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}