using System;

#region Description
/*
 * Числовые значения символов нижнего регистра в коде ASCII
 * отличаются от значений символов верхнего регистра на величину 32.
 * Используя эту информацию, написать программу, которая считывает с клавиатуры
 * и конвертирует все символы нижнего регистра в символы верхнего регистра и наоборот.
 */
#endregion

namespace Meeting_1
{
    partial class Program
    {
        static void UpperCase(ref String str)
        {
            //str = str.ToUpper();

            char[] arr = new char[str.Length];
            for (var i = 0; i < arr.Length; i++)
            {
                if (96 < arr[i] && arr[i] < 123) arr[i] = (char)(str[i] - 32);
                else arr[i] = str[i];
            }

            str = Convert.ToString(arr);
        }

        static void LowerCase(ref String str)
        {
            //str = str.ToLower();

            char[] arr = new char[str.Length];
            for (var i = 0; i < arr.Length; i++)
            {
                if (64 < arr[i] && arr[i] < 91) arr[i] = (char)(str[i] - 32);
                else arr[i] = str[i];
            }

            str = Convert.ToString(arr);
        }
    }
}
