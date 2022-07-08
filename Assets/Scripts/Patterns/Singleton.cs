/*
 * author : Kirakosyan Nikita
 * e-mail : nikita.kirakosyan.work@gmail.com
 */
using UnityEngine;

namespace NikitaKirakosyan.Patterns
{
    public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static object _syncRoot = new();

        private static T s_Instance = null;
        public static T Instance
        {
            get
            {
                if (s_Instance == null)
                {
                    lock (_syncRoot)
                    {
                        if (s_Instance == null)
                        {
                            s_Instance = FindObjectOfType<T>(true);
                        }
                    }
                }

                return s_Instance;
            }
        }
    }
}