/*
 * author : Kirakosyan Nikita
 * e-mail : nikita.kirakosyan.work@gmail.com
 */
using UnityEngine;

namespace NikitaKirakosyan
{
    public sealed class CameraController : MonoBehaviour
    {
        public Transform target = null;

        public float followSpeed = 10.0f;

        public Vector3 offset = Vector3.zero;
        [SerializeField] private bool _autoOffset = true;

        private void Awake()
        {
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