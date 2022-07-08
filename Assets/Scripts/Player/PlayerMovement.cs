/*
 * author : Kirakosyan Nikita
 * e-mail : nikita.kirakosyan.work@gmail.com
 */
using Cysharp.Threading.Tasks;
using NikitaKirakosyan.Managers;
using UnityEngine;

namespace NikitaKirakosyan.Player
{
    public sealed class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 10.0f;
        public bool CanMove { get; private set; } = true;

        [Header("Movement Shift")]
        [SerializeField] private float _deltaX = 0.555f;
        [SerializeField] private float _deltaY = 0.32f;
        private Vector3 _leftShift = Vector3.zero;
        private Vector3 _upShift = Vector3.zero;
        private Vector3 _rightShift = Vector3.zero;
        private Vector3 _downShift = Vector3.zero;

        [Header("Player Settings")]
        [SerializeField] private Vector3 _deltaPlayerPosition = new Vector3(0, 0.64f, 0);
        public Vector3 PlayerPosition => new Vector3(transform.position.x, transform.position.y - _deltaPlayerPosition.y, transform.position.z);

        private void Awake()
        {
            _leftShift = new Vector3(-_deltaX, -_deltaY);
            _upShift = new Vector3(-_deltaX, _deltaY);
            _rightShift = new Vector3(_deltaX, _deltaY);
            _downShift = new Vector3(_deltaX, -_deltaY);
        }

        private void Update()
        {
            if (!CanMove || GameManager.LevelCompleted)
            {
                return;
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Move(_leftShift);
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Move(_upShift);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Move(_rightShift);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Move(_downShift);
            }
        }

        private void Move(Vector3 movementShift)
        {
            Transform destinationT = null;
            Vector3 position = PlayerPosition + movementShift;

            while (GameField.Instance.Cells.Find(cell => cell.position == position))
            {
                destinationT = GameField.Instance.Cells.Find(cell => cell.position == position);
                position += movementShift;
            }

            if (destinationT != null)
            {
                SmoothMoveTo(destinationT.position).Forget();
            }
        }

        private async UniTaskVoid SmoothMoveTo(Vector3 destination)
        {
            CanMove = false;
            var position = PlayerPosition;

            while (PlayerPosition != destination)
            {
                position = Vector3.MoveTowards(position, destination, _moveSpeed * Time.deltaTime);
                transform.position = position + _deltaPlayerPosition;

                await UniTask.Yield();
            }

            CanMove = true;
        }
    }
}