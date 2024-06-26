using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Infrastructure.Services
{
    public class SceneLoader : ISceneLoader
    {
        private ICoroutineRunner coroutineRunner;

        public SceneLoader(ICoroutineRunner coroutineRunner)
        {
            this.coroutineRunner = coroutineRunner;
        }

        public void Load(string sceneName, Action onLoaded = null)
        {
            coroutineRunner.StartCoroutine(LoadAsync(sceneName, onLoaded));
        }

        private IEnumerator LoadAsync(string sceneName, Action onLoaded = null)
        {
            if (SceneManager.GetActiveScene().name == sceneName)
            {
                yield return null;
                onLoaded?.Invoke();
                yield break;
            }

            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);

            while (!asyncOperation.isDone) yield return null;

            onLoaded?.Invoke();
        }
    }
}
