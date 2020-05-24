using DG.Tweening;
using TMPro;
using UnityEngine;

namespace UI
{
    public class GameOverPresenter : MonoBehaviour, IGameOverPresenter
    {
        [SerializeField] private float showDuration;
        [SerializeField] private string finalScorePrefix;
        [SerializeField] private CanvasGroup panelCanvasGroup;
        [SerializeField] private TextMeshProUGUI finalScoreText;
        [SerializeField] private GameObject highScoreParticles;

        public int FinalScore
        {
            set => finalScoreText.text = finalScorePrefix + value;
        }
        
        public void PresentGameOver(bool wasHighScore)
        {
            if (wasHighScore)
            {
                highScoreParticles.SetActive(true);
            }
            
            Sequence show = DOTween.Sequence();
            show.Append(panelCanvasGroup.DOFade(1f, showDuration)).SetUpdate(true).Play();
        }
    }
}