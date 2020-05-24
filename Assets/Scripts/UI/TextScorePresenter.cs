using DG.Tweening;
using TMPro;
using UnityEngine;

namespace UI
{
    public class TextScorePresenter : MonoBehaviour, IScorePresenter
    {
        [SerializeField] private int scoreThreshold;
        [SerializeField] private float blinkDuration;
        [SerializeField] private Color blinkColor;
        [SerializeField] private TextMeshProUGUI scoreText;

        private Color _defaultColor;
        
        public int Score
        {
            set
            {
                scoreText.text = value.ToString();
                if (value % scoreThreshold == 0 && value > 0)
                {
                    Blink();
                }
            }
        }

        private void Start()
        {
            _defaultColor = scoreText.color;
        }

        private void Blink()
        {
            Sequence blink = DOTween.Sequence();
            blink.Append(scoreText.DOColor(blinkColor, blinkDuration / 2f));
            blink.Append(scoreText.DOColor(_defaultColor, blinkDuration / 2f));
            blink.Play();
        }
    }
}