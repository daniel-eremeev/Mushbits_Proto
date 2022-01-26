using DG.Tweening;
using UI.UISystem;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI.UIScreens
{
    public class EndScreen : UIScreen
    {
        [SerializeField] private RectTransform titleTransform;
        [SerializeField] private RectTransform buttonTransform;
        [SerializeField] private Image fadeImage;

        [Header("Off-Screen Position")]
        [SerializeField] private Vector2 titlePositionHidden;
        [SerializeField] private Vector2 buttonPositionHidden;
        [SerializeField] private Color fadeColorHidden;
        
        [Header("On-Screen Positions")]
        [SerializeField] private Vector2 titlePosition;
        [SerializeField] private Vector2 buttonPosition;
        [SerializeField] private Color fadeColor;
        [SerializeField] private Ease ease;
        [SerializeField] private float duration;

        private Tween tween;
        
        private void OnEnable()
        {
            ResetPositions();
            
            Sequence sequence = DOTween.Sequence();
            sequence.Append(titleTransform.DOAnchorPos(titlePosition, duration).SetEase(ease));
            sequence.Insert(0, buttonTransform.DOAnchorPos(buttonPosition, duration).SetEase(ease));
            sequence.Insert(0, fadeImage.DOColor(fadeColor, duration).SetEase(ease));
            tween = sequence;
            tween.Play();
        }

        private void OnDestroy()
        {
            tween?.Kill();
        }

        private void ResetPositions()
        {
            titleTransform.anchoredPosition = titlePositionHidden;
            buttonTransform.anchoredPosition = buttonPositionHidden;
            fadeImage.color = fadeColorHidden;
        }

        public void OnContinueButtonClick()
        {
            SceneManager.LoadScene(0);
        }
    }
}
