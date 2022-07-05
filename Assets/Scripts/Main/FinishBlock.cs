/*
 * author : Kirakosyan Nikita
 * e-mail : nikita.kirakosyan.work@gmail.com
 */
using NikitaKirakosyan.Patterns;
using UnityEngine;

namespace NikitaKirakosyan
{
    [RequireComponent(typeof(CircleCollider2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class FinishBlock : Singleton<FinishBlock>
    {
        public int RequiredKeyCount => _requiredKeyCount;
        [SerializeField, Min(1)] private int _requiredKeyCount = 1;

        [Header("Renderer Settings")]
        [SerializeField] private Sprite _closedSprite = null;
        [SerializeField] private Sprite _openedSprite = null;

        public bool Opened { get; private set; } = false;

        public SpriteRenderer SpriteRenderer { get; private set; } = null;

        private void Awake()
        {
            GetComponent<CircleCollider2D>().isTrigger = true;
            SpriteRenderer = GetComponent<SpriteRenderer>();
        }

        public bool TryOpen(int collectedKeyCount)
        {
            Opened = collectedKeyCount == _requiredKeyCount;
            SpriteRenderer.sprite = Opened ? _openedSprite : _closedSprite;

            return Opened;
        }
    }
}