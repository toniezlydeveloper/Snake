using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public class LevelLoader : MonoBehaviour
    {
        private void Start()
        {
            GetComponent<ILevelLoadingTrigger>().OnTrigger += LoadLevel;
        }

        private void LoadLevel(string levelName)
        {
            SceneManager.LoadScene(levelName);
        }
    }
}
