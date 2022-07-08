/*
 * author : Kirakosyan Nikita
 * e-mail : nikita.kirakosyan.work@gmail.com
 */
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using NikitaKirakosyan.Patterns;
using NikitaKirakosyan.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NikitaKirakosyan.Managers
{
    public sealed class SceneLoadingManager : Singleton<SceneLoadingManager>
    {
        public AsyncOperation SceneLoadingAsync { get; private set; } = null;
        private Camera _mainCamera = null;

        private void Awake()
        {
            _mainCamera = FindObjectOfType<Camera>();

            LoadLastLevel();
        }

        private void Update()
        {
            if (SceneLoadingAsync != null)
            {
                LoadingWindow.Instance.ProgressBar.value = SceneLoadingAsync.progress;
            }
        }

        public void RestartLevel()
        {
            LoadLevelAsync(SceneManager.GetActiveScene().buildIndex);
        }

        public void LoadNextLevel()
        {
            int sceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

            if (sceneIndex >= SceneManager.sceneCountInBuildSettings)
            {
                RestartLevel();
            }
            else
            {
                LoadLevelAsync(sceneIndex);
            }
        }

        public void LoadLastLevel()
        {
            LoadLevelAsync(SceneManager.GetActiveScene().buildIndex + 1, false);
        }

        private async void LoadLevelAsync(int sceneIndex, bool undloadScene = true)
        {
            if (undloadScene)
            {
                await SceneManager.UnloadSceneAsync(SceneManager.GetSceneAt(1));
            }

            SceneLoadingAsync = SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Additive);
            SceneLoadingAsync.completed += delegate { OnSceneLoadingCompleted(); };

            await LoadingWindow.CloseAllWindows();
            await LoadingWindow.Instance.Open();
        }

        private void DestroyAnotherCameras()
        {
            List<Camera> allCameras = FindObjectsOfType<Camera>().ToList();
            allCameras.Remove(_mainCamera);
            allCameras.ForEach(camera => Destroy(camera.gameObject));
        }

        private void SetActiveNextScene()
        {
            Scene nextActiveScene = SceneManager.GetSceneAt(1);
            SceneManager.SetActiveScene(nextActiveScene);
        }

        private void OnSceneLoadingCompleted()
        {
            LoadingWindow.Instance.Close().Forget();

            DestroyAnotherCameras();
            SetActiveNextScene();

            SceneLoadingAsync.completed -= delegate { OnSceneLoadingCompleted(); };
            SceneLoadingAsync = null;
        }
    }
}