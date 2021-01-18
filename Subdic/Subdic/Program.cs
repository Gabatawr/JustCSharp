using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Subdic
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] sybols = {
                ' ', '?', '!', ',', '.', 
                ':', ';', '"', '<', '>', '=', '*',
                '\t', '\n', '\r'
            };
            string[] words = File.ReadAllText("test.srt")
                                 .Split(sybols, StringSplitOptions.RemoveEmptyEntries); ;

            using StreamReader sr = new StreamReader("dic.csv");
            Dictionary<string, int> dic = new();
            while (!sr.EndOfStream) dic.Add(sr.ReadLine(), 0);
            sr.Close();

            foreach (string word in words)
            {
                if (!char.IsLetter(word[0]) || word.Length == 1) continue;

                string wl = word.ToLower();
                if (!dic.ContainsKey(wl)) dic.Add(wl, 0);
                dic[wl]++;
            }

            List<KeyValuePair<string, int>> views = dic.ToList();
            views.Sort((KeyValuePair<string, int> p1, KeyValuePair<string, int> p2) 
                => p2.Value.CompareTo(p1.Value));

            using StreamWriter sw = new StreamWriter("dic.csv");
            foreach (KeyValuePair<string, int> line in views)
            {
                Console.WriteLine($"{line.Value}\t{line.Key}");
                sw.WriteLine($"{line.Key}");
            }
            sw.Close();

            Console.ReadKey();
        }
    }
}
