using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Infrastructure
{
    public class SceneLoader
    {
        private readonly ICoroutineRunner _coroutineRunner;

        public SceneLoader(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }

        public void Load(string name, Action onSceneLoaded = null) =>
            _coroutineRunner.StartCoroutine(LoadScene(name, onSceneLoaded));

        private static IEnumerator LoadScene(string name, Action onSceneLoaded = null)
        {
            if (SceneManager.GetActiveScene().name == name)
            {
                onSceneLoaded?.Invoke();
                yield break;
            }

            AsyncOperation waitToLoad = SceneManager.LoadSceneAsync(name);

            while (waitToLoad.isDone == false)
                yield return null;

            onSceneLoaded?.Invoke();
        }
    }
}