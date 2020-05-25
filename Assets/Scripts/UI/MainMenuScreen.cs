using System;
using UnityEngine;
using UnityEngine.UI;
using Utility;

namespace UI
{
    public class MainMenuScreen : MonoBehaviour, ILevelLoadingTrigger
    {
        public event Action<string> OnTrigger;
        
        [SerializeField] private string levelName;
        [SerializeField] private Button playButton;
        [SerializeField] private Button quitButton;

        private void Start()
        {
            quitButton.onClick.AddListener(Application.Quit);
            playButton.onClick.AddListener(() => OnTrigger?.Invoke(levelName));
        }
    }
}