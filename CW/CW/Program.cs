using System;

namespace CW
{
    class Program
    {
        static void Main(string[] args)
        {
            Group group = new Group();

            foreach (var student in group) Console.WriteLine(student.ToString());
            Console.WriteLine();

            group.Sort(new Group.CmpName());
            foreach (var student in group) Console.WriteLine(student.ToString());
            Console.WriteLine();

            group.Sort(new Group.CmpCard());
            foreach (var student in group) Console.WriteLine(student.ToString());
            Console.Read();
        }
    }
}
