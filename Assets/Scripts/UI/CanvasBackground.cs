/*
 * author : Kirakosyan Nikita
 * e-mail : nikita.kirakosyan.work@gmail.com
 */
using UnityEngine;

namespace NikitaKirakosyan.UI
{
    [RequireComponent(typeof(Canvas))]
    public sealed class CanvasBackground : MonoBehaviour
    {
        private Canvas _canvas = null;

        private void Awake()
        {
            _canvas = GetComponent<Canvas>();
            _canvas.renderMode = RenderMode.ScreenSpaceCamera;
            _canvas.worldCamera = FindObjectOfType<Camera>();
            _canvas.planeDistance = 10;
        }
    }
}