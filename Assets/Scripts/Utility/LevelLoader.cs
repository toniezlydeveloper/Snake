using UI;
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
            SceneManager.LoadScene(levelName);
        }
    }
}
