/*
 * author : Kirakosyan Nikita
 * e-mail : nikita.kirakosyan.work@gmail.com
 */
using UnityEngine;
using UnityEngine.UI;

namespace NikitaKirakosyan.UI
{
    public sealed class LoadingWindow : Window<LoadingWindow>, IWindowOpen, IWindowClose
    {
        [SerializeField] private Slider _progressBar = null;
        public Slider ProgressBar => _progressBar;

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