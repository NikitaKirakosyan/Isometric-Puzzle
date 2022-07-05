/*
 * author : Kirakosyan Nikita
 * e-mail : nikita.kirakosyan.work@gmail.com
 */
using NikitaKirakosyan.Patterns;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NikitaKirakosyan
{
    public sealed class SceneLoadingManager : Singleton<SceneLoadingManager>
    {
        public void RestartLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void LoadNextLevel()
        {
            int sceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

            if (sceneIndex > SceneManager.sceneCountInBuildSettings - 1)
            {
                RestartLevel();
            }
            else
            {
                SceneManager.LoadScene(sceneIndex);
            }
        }
    }
}