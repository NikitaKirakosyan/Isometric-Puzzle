/*
 * author : Kirakosyan Nikita
 * e-mail : nikita.kirakosyan.work@gmail.com
 */
using System;

namespace NikitaKirakosyan
{
    public static class ArrayExtension
    {
        public static T GetRandomElementOrDefault<T>(this T[] array)
        {
            if (array == null || array.Length == 0)
            {
                return default;
            }
            else
            {
                Random random = new Random();
                return array[random.Next(0, array.Length)];
            }
        }
    }
}