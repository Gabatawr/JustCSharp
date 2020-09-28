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
            for (var i = 0; i < str.Length; i++) 
                if (96 < str[i] && str[i] < 123) 
                    str = str.Replace(str[i], (char)(str[i] - 32));
        }

        static void LowerCase(ref String str)
        {
            for (var i = 0; i < str.Length; i++)
                if (64 < str[i] && str[i] < 91)
                    str = str.Replace(str[i], (char)(str[i] + 32));
        }
    }
}
