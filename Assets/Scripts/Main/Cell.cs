/*
 * author : Kirakosyan Nikita
 * e-mail : nikita.kirakosyan.work@gmail.com
 */
using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Linq;

namespace NikitaKirakosyan
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Cell : MonoBehaviour
    {
        public SpriteRenderer SpriteRenderer { get; private set; } = null;

        private bool _refreshed = false;

        private void Awake()
        {
            if (!_refreshed)
            {
                RefreshSortingOrder();
            }
        }

        public void RefreshSortingOrder()
        {
            SpriteRenderer = GetComponent<SpriteRenderer>();
            SpriteRenderer.sortingOrder = (int)(transform.position.y / 0.32f * -1);

            _refreshed = true;
        }

        [MenuItem("Assets/Refresh All Cells", priority = 0)]
        public static void RefreshAllCells()
        {
            List<Cell> allCells = FindObjectsOfType<Cell>(true).ToList();
            allCells.ForEach(cell => cell.RefreshSortingOrder());
        }
    }
}