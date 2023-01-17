using System;
using System.Collections;
using TDS.Infrastructure.Coroutine;
using UnityEngine.SceneManagement;

namespace TDS.Infrastructure
{
    public class SyncSceneLoadService : ISceneLoadService
    {
        private readonly ICoroutineRunner _coroutineRunner;

        public SyncSceneLoadService(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }
        
        public void Load(string sceneName, Action completeCallback)
        {
            SceneManager.LoadScene(sceneName);

            _coroutineRunner.StartCoroutine(WaitForFrames(1, completeCallback));
        }

        private IEnumerator WaitForFrames(int i, Action completeCallback)
        {
            yield return null;
            completeCallback?.Invoke();
        }
    }
}