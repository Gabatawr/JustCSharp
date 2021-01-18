using System;

namespace RefEx
{
    class Program
    {
        class Class
        {
            public int IntProp = 11;
        }

        static void Main(string[] args)
        {
            //-----------------------------------------------------------------
            Class a = new Class() { IntProp = 99 };
            Console.WriteLine(a.IntProp);
            //-----------------------------------------------------------------
            ref int ap = ref a.IntProp;
            ap = 88;
            Console.WriteLine(a.IntProp);
            //-----------------------------------------------------------------
            unsafe
            {
                int* bp = stackalloc int[8];
                bp[0] = 7;
                Console.WriteLine(bp[0]);
                //-------------------------------------------------------------
                fixed (int* cp = &a.IntProp)
                {
                    *cp = 33;
                }
                Console.WriteLine(a.IntProp);
                //-------------------------------------------------------------
                for (int i = 0; i < 8; i++)
                {
                    Console.WriteLine((long)(bp + i));
                }
                //-------------------------------------------------------------
                bp[3] = 8;
                Console.WriteLine(*(bp + 3));
            }

            //-----------------------------------------------------------------
            Console.ReadLine();
        }
    }
}
