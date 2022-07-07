/*
 * author : Kirakosyan Nikita
 * e-mail : nikita.kirakosyan.work@gmail.com
 */
using NikitaKirakosyan.Patterns;
using NikitaKirakosyan.Player;
using UnityEngine;

namespace NikitaKirakosyan
{
    public sealed class CameraController : Singleton<CameraController>
    {
        public Transform target = null;

        public float followSpeed = 2.0f;

        public Vector3 offset = Vector3.zero;
        [SerializeField] private bool _autoOffset = true;

        private void Awake()
        {
            if (target == null)
            {
                target = FindObjectOfType<PlayerMovement>().transform;
            }

            if (_autoOffset)
            {
                offset = transform.position - target.position;
            }
        }

        private void Update()
        {
            FollowForTarget();
        }

        private void FollowForTarget()
        {
            Vector3 destination = offset + target.position;
            transform.position = Vector3.MoveTowards(transform.position, destination, followSpeed * Time.deltaTime);
        }
    }
}