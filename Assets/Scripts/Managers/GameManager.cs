/*
 * author : Kirakosyan Nikita
 * e-mail : nikita.kirakosyan.work@gmail.com
 */
using System;
using Cysharp.Threading.Tasks;
using NikitaKirakosyan.UI;

namespace NikitaKirakosyan.Managers
{
    public sealed class GameManager
    {
        public static readonly GameManager Instance = new GameManager();

        public static bool IsPause { get; private set; } = false;
        public static bool LevelCompleted { get; private set; } = false;

        public Action OnGameFinished { get; private set; } = null;

        private GameManager()
        {
            OnGameFinished += delegate { FinishWindow.Instance.Open().Forget(); };
        }
    }
}