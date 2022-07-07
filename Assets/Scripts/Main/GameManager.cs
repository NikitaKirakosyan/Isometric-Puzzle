/*
 * author : Kirakosyan Nikita
 * e-mail : nikita.kirakosyan.work@gmail.com
 */
using System;
using NikitaKirakosyan.Patterns;
using NikitaKirakosyan.UI;
using UnityEngine;

namespace NikitaKirakosyan
{
    public sealed class GameManager : Singleton<GameManager>
    {
        public static bool IsPause { get; private set; } = false;
        public static bool LevelCompleted { get; private set; } = false;

        public Action OnGameFinished { get; private set; } = null;

        private void OnEnable()
        {
            OnGameFinished += FinishWindow.Instance.Open;
        }

        private void OnDisable()
        {
            if (Application.isFocused)
            {
                OnGameFinished -= FinishWindow.Instance.Open;
            }
        }
    }
}