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

        public int FinalScore
        {
            set => finalScoreText.text = finalScorePrefix + value;
        }
        
        public void PresentGameOver()
        {
            Sequence show = DOTween.Sequence();
            show.Append(panelCanvasGroup.DOFade(1f, showDuration));
            show.Play();
        }
    }
}