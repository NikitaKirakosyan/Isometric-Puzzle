/*
 * author : Kirakosyan Nikita
 * e-mail : nikita.kirakosyan.work@gmail.com
 */
using System.Linq;
using UnityEngine;

namespace NikitaKirakosyan.UI
{
    public abstract class Window<T> : MonoBehaviour where T : MonoBehaviour, IWindowOpen, IWindowClose
    {
        private static T s_Instance = null;

        public static T Instance
        {
            get
            {
                if (s_Instance == null)
                {
                    s_Instance = FindObjectOfType<T>(true);
                }

                return s_Instance;
            }
        }

        public static void CloseAllWindows()
        {
            var willClosedWindow = FindObjectsOfType<MonoBehaviour>().OfType<IWindowClose>().ToList();

            if (willClosedWindow == null || willClosedWindow.Count == 0)
            {
                return;
            }

            willClosedWindow.ForEach(window => window.Close());
        }

        public abstract void Open();

        public abstract void Close();
    }
}