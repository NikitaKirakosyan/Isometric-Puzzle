/*
 * author : Kirakosyan Nikita
 * e-mail : nikita.kirakosyan.work@gmail.com
 */
using System.Collections.Generic;
using NikitaKirakosyan.Patterns;
using UnityEngine;

namespace NikitaKirakosyan
{
    public sealed class GameField : Singleton<GameField>
    {
        public List<Transform> Cells = new List<Transform>(32);

        private void Awake()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Cells.Add(transform.GetChild(i));
            }
        }
    }
}