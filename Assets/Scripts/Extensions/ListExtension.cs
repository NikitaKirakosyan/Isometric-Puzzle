/*
 * author : Kirakosyan Nikita
 * e-mail : nikita.kirakosyan.work@gmail.com
 */
using System;
using System.Collections.Generic;

namespace NikitaKirakosyan
{
    public static class ListExtension
    {
        public static T GetRandomElementOrDefault<T>(this List<T> list)
        {
            if (list == null || list.Count == 0)
            {
                return default;
            }
            else
            {
                Random random = new Random();
                return list[random.Next(0, list.Count)];
            }
        }
    }
}