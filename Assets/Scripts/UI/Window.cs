/*
 * author : Kirakosyan Nikita
 * e-mail : nikita.kirakosyan.work@gmail.com
 */
using System;
using System.Linq;
using Cysharp.Threading.Tasks;
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

        public static async UniTask<bool> CloseAllWindows()
        {
            var willClosedWindow = FindObjectsOfType<MonoBehaviour>().OfType<IWindowClose>().ToList();

            if (willClosedWindow == null || willClosedWindow.Count == 0)
            {
                return false;
            }

            while (!willClosedWindow.TrueForAll(window => window.Close().Status == UniTaskStatus.Succeeded))
            {
                try
                {
                    await UniTask.Yield(new System.Threading.CancellationToken(true));
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                    return false;
                }
            }

            return true;
        }

        public async UniTask<bool> Open()
        {
            gameObject.SetActive(true);

            while (!gameObject.activeSelf)
            {
                try
                {
                    await UniTask.Yield(new System.Threading.CancellationToken(true));
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                    return false;
                }
            }

            return true;
        }

        public async UniTask<bool> Close()
        {
            gameObject.SetActive(false);

            while (gameObject.activeSelf)
            {
                try
                {
                    await UniTask.Yield(new System.Threading.CancellationToken(true));
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                    return false;
                }
            }

            return true;
        }
    }
}