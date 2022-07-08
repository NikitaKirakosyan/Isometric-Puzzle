/*
 * author : Kirakosyan Nikita
 * e-mail : nikita.kirakosyan.work@gmail.com
 */
using System;

namespace NikitaKirakosyan.Managers
{
    public static class CurrencyManager
    {
        public static int Coins { get; private set; } = 0;
        public static int Crystals { get; private set; } = 0;

        public static void AddCoins(int value)
        {
            Coins += value;
        }

        public static void RemoveCoins(int value)
        {
            Coins -= value;
            Coins = Math.Clamp(Coins, 0, int.MaxValue);
        }
    }
}