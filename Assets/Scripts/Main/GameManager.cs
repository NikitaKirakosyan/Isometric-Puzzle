/*
 * author : Kirakosyan Nikita
 * e-mail : nikita.kirakosyan.work@gmail.com
 */
using System;
using NikitaKirakosyan.Patterns;
using UnityEngine;

namespace NikitaKirakosyan
{
    public sealed class GameManager : Singleton<GameManager>
    {
        public static bool IsPause { get; private set; } = false;
        public static bool LevelCompleted { get; private set; } = false;

        [SerializeField] private GameObject _finishWindow = null;

        public Action OnGameFinished { get; private set; } = null;

        private void Awake()
        {
            SetWindowState(false);
        }

        private void OnEnable()
        {
            OnGameFinished += delegate { SetWindowState(true); };
        }

        private void OnDisable()
        {
            OnGameFinished -= delegate { SetWindowState(true); };
        }

        private void SetWindowState(bool value)
        {
            _finishWindow.SetActive(value);
            LevelCompleted = _finishWindow.activeSelf;
        }
    }
}