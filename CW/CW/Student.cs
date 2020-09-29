using System;
using System.CodeDom;
using System.Collections;

namespace CW
{
    class StudentCard : IComparable
    {
        public string Series { get; set; }
        public string Number { get; set; }

        public int CompareTo(object obj)
        {
            int cmpSeries = String.Compare(this.Series, (obj as StudentCard)?.Series, StringComparison.Ordinal);
            if (cmpSeries == 0)
                 return String.Compare(this.Number, (obj as StudentCard)?.Number, StringComparison.Ordinal);
            else return cmpSeries;
        }

        public override string ToString() 
        {
            return $"s{Series}n{Number}";
        }
    }
    class Student
    {
        public string Name { get; set; }
        public StudentCard Card { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}\tCard: {Card}";
        }
    }

    class Group : IEnumerable
    {
        public Student[] Students =
        {
            new Student()
            {
                Name = "Conan",
                Card = new StudentCard()
                {
                    Series = "BB",
                    Number = "123456"
                }
            },

            new Student()
            {
                Name = "Aza",
                Card = new StudentCard()
                {
                    Series = "AA",
                    Number = "123456"
                }
            },

            new Student()
            {
                Name = "Bob",
                Card = new StudentCard()
                {
                    Series = "BB",
                    Number = "654321"
                }
            }
        };

        public IEnumerator GetEnumerator()
        {
            return Students.GetEnumerator();
        }

        public void Sort(IComparer comparer)
        {
            Array.Sort(Students, comparer);
        }
        public class CmpName : IComparer
        {
            public int Compare(object x, object y)
            {
                return String.Compare((x as Student)?.Name, (y as Student)?.Name, StringComparison.OrdinalIgnoreCase);
            }
        }
        public class CmpCard : IComparer
        {
            public int Compare(object x, object y)
            {
                return (x as Student).Card.CompareTo((y as Student).Card);
            }
        }
    }
}