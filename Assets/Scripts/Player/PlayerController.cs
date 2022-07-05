/*
 * author : Kirakosyan Nikita
 * e-mail : nikita.kirakosyan.work@gmail.com
 */
using UnityEngine;

namespace NikitaKirakosyan.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(CircleCollider2D))]
    public sealed class PlayerController : MonoBehaviour
    {
        private int _collectedKeyCount = 0;

        private void Awake()
        {
            GetComponent<CircleCollider2D>().isTrigger = true;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Key triggeredKey = collision.GetComponent<Key>();
            if (triggeredKey != null)
            {
                _collectedKeyCount += triggeredKey.CollectKey();
                FinishBlock.Instance.TryOpen(_collectedKeyCount);

                return;
            }

            FinishBlock triggeredFinishBlock = collision.GetComponent<FinishBlock>();
            if (triggeredFinishBlock.Opened)
            {
                GameManager.Instance.OnGameFinished?.Invoke();

                return;
            }
        }
    }
}