/*
 * author : Kirakosyan Nikita
 * e-mail : nikita.kirakosyan.work@gmail.com
 */
using NikitaKirakosyan.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NikitaKirakosyan.UI
{
    public sealed class FinishWindow : Window<FinishWindow>, IWindowOpen, IWindowClose
    {
        [SerializeField] private TextMeshProUGUI _collectedCoinsText = null;
        [SerializeField] private TextMeshProUGUI _collectedCrystalsText = null;

        [SerializeField] private Button _nextLevelButton = null;

        private void Awake()
        {
            RemoveOverText();

            _nextLevelButton.onClick.AddListener(SceneLoadingManager.Instance.LoadNextLevel);
        }

        private void OnEnable()
        {
            RefreshUI();
        }

        private void RemoveOverText()
        {
            _collectedCoinsText.text = _collectedCoinsText.text.RemoveAllDigits();
            _collectedCrystalsText.text = _collectedCrystalsText.text.RemoveAllDigits();
        }

        private void RefreshUI()
        {
            _collectedCoinsText.text += $" {CurrencyManager.Coins}";
            _collectedCrystalsText.text = $" {CurrencyManager.Crystals}";
        }
    }
}