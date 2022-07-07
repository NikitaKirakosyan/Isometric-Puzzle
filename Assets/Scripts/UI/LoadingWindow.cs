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
    }
}