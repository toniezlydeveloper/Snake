using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PauseScreen : MonoBehaviour, ILevelLoadingTrigger, IPausePresenter
    {
        public event Action<string> OnTrigger;

        [SerializeField] private string mainMenuName;
        [SerializeField] private float fadeDuration;
        [SerializeField] private CanvasGroup panelCanvasGroup;
        [SerializeField] private Button mainMenuButton;
        [SerializeField] private Button quitButton;

        private void Start()
        {
            quitButton.onClick.AddListener(Application.Quit);
            mainMenuButton.onClick.AddListener(() => OnTrigger?.Invoke(mainMenuName));
        }

        public void Toggle(bool newState)
        {
            Sequence fade = DOTween.Sequence();
            fade.Append(panelCanvasGroup.DOFade(newState ? 1f : 0f, fadeDuration))
                .AppendCallback(() => panelCanvasGroup.blocksRaycasts = newState).SetUpdate(true).Play();
        }
    }
}