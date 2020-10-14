using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.InteropServices;
using Gab.OperationTimer;

namespace CW
{
    class Program
    {
        public delegate void De();
        public static event De Ev;

        static void Main(string[] args)
        {

            Student[] arr =
            {
                new Student
                {
                    Name = "Zelda",
                    Card = new StudentCard
                    {
                        Series = "AA",
                        Number = "000000"
                    }
                },
                new Student
                {
                    Name = "Ivan",
                    Card = new StudentCard
                    {
                        Series = "BB",
                        Number = "111111"
                    }
                },
                new Student
                {
                    Name = "Igor",
                    Card = new StudentCard
                    {
                        Series = "AA",
                        Number = "222222"
                    }
                },
            };

            foreach (var student in arr)
                Ev += student.EvTest;

            Ev.Invoke();

            Ev = Ev.Sort(new Student.CmpName());
            Console.WriteLine();

            Ev.Invoke();

            //-------------
            #region old

            //=====================================================================

            //Student[] arr =
            //{
            //    new Student
            //    {
            //        Name = "Olga",
            //        Card = new StudentCard
            //        {
            //            Series = "AA",
            //            Number = "000000"
            //        }
            //    },
            //    new Student
            //    {
            //        Name = "Ivan",
            //        Card = new StudentCard
            //        {
            //            Series = "BB",
            //            Number = "111111"
            //        }
            //    },
            //    new Student
            //    {
            //        Name = "Igor",
            //        Card = new StudentCard
            //        {
            //            Series = "AA",
            //            Number = "222222"
            //        }
            //    },
            //};

            //=====================================================================

            //public delegate dynamic Calc(dynamic a, dynamic b);

            //public static dynamic Sum(dynamic a, dynamic b) => a + b;
            //public static dynamic Sub(dynamic a, dynamic b) => a - b;
            //public static dynamic Div(dynamic a, dynamic b) => a / b;
            //public static dynamic Mult(dynamic a, dynamic b) => a * b;

            //Calc calc = null;

            //calc += Sum;
            //calc += Sub;
            //calc += Div;
            //calc += Mult;

            //Console.WriteLine(calc.GetInvocationList()[3].DynamicInvoke(5, 5.5));

            //=====================================================================

            //class Point2D<T>
            //{
            //    public T X { get; set; }
            //    public T Y { get; set; }

            //    public Point2D(T X, T Y)
            //    {
            //        this.X = X;
            //        this.Y = Y;
            //    }
            //    public override string ToString()
            //    {
            //        return $"X = {X}, Y = {Y}";
            //    }
            //}
            //class Point3D : Point2D<int>
            //{
            //    public int Z { get; set; }

            //    public Point3D(int X, int Y, int Z) : base(X, Y)
            //    {
            //        this.Z = Z;
            //    }
            //    public override string ToString()
            //    {
            //        return base.ToString() + $", Z = {Z}";
            //    }
            //}

            //Point3D p = new Point3D(1, 2, 3);
            //Console.WriteLine(p);

            //=====================================================================

            //using (new OperationTimer("ArrayList"))
            //{
            //    ArrayList ALint = new ArrayList();
            //    for (int i = 0; i < 100000000; i++)
            //    {
            //        ALint.Add(i);
            //    }
            //    ALint = null;
            //}

            //using (new OperationTimer("List"))
            //{
            //    List<int> Lint = new List<int>();
            //    for (int i = 0; i < 100000000; i++)
            //    {
            //        Lint.Add(i);
            //    }
            //    Lint = null;
            //}

            //=====================================================================

            //Hashtable ht = new Hashtable();

            //void AddRating(string name, int rating)
            //{
            //    foreach (Student student in ht.Keys)
            //        if (student.Name == name)
            //            (ht[student] as ArrayList)?.Add(rating);
            //}
            //void PrintStudent()
            //{
            //    foreach (var key in ht.Keys)
            //    {
            //        Console.Write(key + ": ");
            //        foreach (int rating in (ArrayList)ht[key])
            //            Console.Write(rating + " ");

            //        Console.WriteLine();
            //    }
            //}

            //ht.Add(new Student
            //{
            //    Name = "Olga",
            //    Card = new StudentCard
            //    {
            //        Series = "AA",
            //        Number = "000000"
            //    }
            //}, new ArrayList());
            //ht.Add(new Student
            //{
            //    Name = "Ivan",
            //    Card = new StudentCard
            //    {
            //        Series = "BB",
            //        Number = "111111"
            //    }
            //}, new ArrayList());


            //AddRating("Ivan", 12);
            //AddRating("Ivan", 10);
            //AddRating("Ivan", 11);

            //AddRating("Olga", 9);
            //AddRating("Olga", 10);

            //PrintStudent();

            //=====================================================================

            //Group group = new Group();

            //foreach (var student in group) Console.WriteLine(student.ToString());
            //Console.WriteLine();

            //group.Sort(new Group.CmpName());
            //foreach (var student in group) Console.WriteLine(student.ToString());
            //Console.WriteLine();

            //group.Sort(new Group.CmpCard());
            //foreach (var student in group) Console.WriteLine(student.ToString());
            //Console.Read();

            #endregion
            Console.Read();
        }
    }
}
