using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class GameOverScreen : MonoBehaviour, IGameOverPresenter, ILevelLoadingTrigger , IScorePresenter
    {
        public event Action<string> OnTrigger;
        
        [SerializeField] private float showDuration;
        [SerializeField] private string finalScorePrefix;
        [SerializeField] private string levelName;
        [SerializeField] private string mainMenuName;
        [SerializeField] private CanvasGroup panelCanvasGroup;
        [SerializeField] private TextMeshProUGUI finalScoreText;
        [SerializeField] private GameObject highScoreParticles;
        [SerializeField] private Button retryButton;
        [SerializeField] private Button mainMenuButton;
        [SerializeField] private Button quitButton;

        public int Score
        {
            set => finalScoreText.text = finalScorePrefix + value;
        }

        private void Start()
        {
            quitButton.onClick.AddListener(Application.Quit);
            retryButton.onClick.AddListener(() => OnTrigger?.Invoke(levelName));
            mainMenuButton.onClick.AddListener(() => OnTrigger?.Invoke(mainMenuName));
        }

        public void PresentGameOver(bool wasHighScore)
        {
            if (wasHighScore)
            {
                highScoreParticles.SetActive(true);
            }
            
            Sequence show = DOTween.Sequence();
            show.Append(panelCanvasGroup.DOFade(1f, showDuration))
                .AppendCallback(() => panelCanvasGroup.blocksRaycasts = true).SetUpdate(true).Play();
        }
    }
}