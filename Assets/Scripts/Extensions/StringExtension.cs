/*
 * author : Kirakosyan Nikita
 * e-mail : nikita.kirakosyan.work@gmail.com
 */
using System.Collections.Generic;
using System.Linq;

namespace NikitaKirakosyan
{
    public static class StringExtension
    {
        public static string RemoveAllDigits(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return default;
            }

            List<char> coinLetters = str.ToCharArray().ToList();
            coinLetters.RemoveAll(letter => char.IsDigit(letter));

            return new string(coinLetters.ToArray());
        }

        public static string RemoveAllLetters(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return default;
            }

            List<char> coinLetters = str.ToCharArray().ToList();
            coinLetters.RemoveAll(letter => !char.IsDigit(letter));

            return new string(coinLetters.ToArray());
        }
    }
}