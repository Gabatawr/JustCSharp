using System;

namespace Gab
{
    namespace ArrayExtension
    {
        public static class ArrayExtension
        {
            public static T[] Mix<T>(this T[] array)
            {
                Random rand = new Random(DateTime.Now.Millisecond);

                for (int i = 0, r; i < array.Length; i++)
                {
                    r = rand.Next(array.Length);

                    T temp = array[r];
                    array[r] = array[i];
                    array[i] = temp;
                }
                return array;
            }
        }
    }
}