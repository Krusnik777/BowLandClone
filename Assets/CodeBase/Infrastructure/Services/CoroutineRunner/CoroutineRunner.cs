using System.Collections;
using UnityEngine;

namespace CodeBase.Services.CoroutineRunner
{
    public class CoroutineRunner : ICoroutineRunner
    {
        private MonoCoroutineRunner monoCoroutineRunner;

        public CoroutineRunner()
        {
            GameObject coroutineRunnerGameObject = new GameObject("CoroutineRunner");
            monoCoroutineRunner = coroutineRunnerGameObject.AddComponent<MonoCoroutineRunner>();

            GameObject.DontDestroyOnLoad(coroutineRunnerGameObject);
        }

        public Coroutine StartCoroutine(IEnumerator coroutine)
        {
            return monoCoroutineRunner.StartCoroutine(coroutine);
        }
    }
}
