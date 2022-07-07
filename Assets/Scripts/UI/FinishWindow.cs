/*
 * author : Kirakosyan Nikita
 * e-mail : nikita.kirakosyan.work@gmail.com
 */
using UnityEngine;
using UnityEngine.UI;

namespace NikitaKirakosyan.UI
{
    public sealed class FinishWindow : Window<FinishWindow>, IWindowOpen, IWindowClose
    {
        [SerializeField] private Button _nextLevelButton = null;

        private void Awake()
        {
            _nextLevelButton.onClick.AddListener(SceneLoadingManager.Instance.LoadNextLevel);
        }

        public override void Open()
        {
            Instance.gameObject.SetActive(true);
        }

        public override void Close()
        {
            Instance.gameObject.SetActive(false);
        }
    }
}