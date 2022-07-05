/*
 * author : Kirakosyan Nikita
 * e-mail : nikita.kirakosyan.work@gmail.com
 */
using UnityEngine;

namespace NikitaKirakosyan
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class Key : MonoBehaviour
    {
        private void Awake()
        {
            GetComponent<BoxCollider2D>().isTrigger = true;
        }

        public int CollectKey()
        {
            Destroy(gameObject);
            return 1;
        }
    }
}