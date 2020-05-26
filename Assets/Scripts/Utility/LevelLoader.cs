using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utility
{
    public class LevelLoader : MonoBehaviour
    {
        private void Start()
        {
            foreach (ILevelLoadingTrigger trigger in GetComponents<ILevelLoadingTrigger>())
            {
                trigger.OnTrigger += LoadLevelAndResetTimeScale;
            }
        }

        private void LoadLevelAndResetTimeScale(string levelName)
        {
            TimeController.ResetTimeScale();
            StartCoroutine(LoadLevel(levelName));
        }

        private IEnumerator LoadLevel(string levelName)
        {
            AsyncOperation loadingOperation = SceneManager.LoadSceneAsync(levelName);
            loadingOperation.allowSceneActivation = false;
            
            yield return new WaitForSeconds(0.125f);
            
            while (loadingOperation.progress < 0.9f)
            {
                yield return null;
            }

            loadingOperation.allowSceneActivation = true;
        }
    }
}
