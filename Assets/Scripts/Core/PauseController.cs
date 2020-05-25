using UI;
using UnityEngine;
using UnityEngine.UI;
using Utility;

namespace Core
{
    public class PauseController : MonoBehaviour
    {
        [SerializeField] private KeyCode pauseToggleKey;
        [SerializeField] private Button resumeButton;

        private bool _isGamePaused;
        private IPausePresenter _pausePresenter;

        private void Start()
        {
            _pausePresenter = GetComponent<IPausePresenter>();
            resumeButton.onClick.AddListener(() => TogglePause(false));
        }

        private void Update()
        {
            if (Input.GetKeyDown(pauseToggleKey))
            {
                TogglePause(!_isGamePaused);
            }
        }

        private void TogglePause(bool newState)
        {
            if (_isGamePaused == newState)
            {
                return;
            }
            
            _isGamePaused = newState;

            if (_isGamePaused)
            {
                TimeController.MultiplyTimeScale(0f);
            }
            else
            {
                TimeController.RestorePreviousTimeScale();
            }
            
            _pausePresenter.Toggle(_isGamePaused);
        }
    }
}