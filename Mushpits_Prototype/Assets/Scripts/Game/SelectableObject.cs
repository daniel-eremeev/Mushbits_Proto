using DG.Tweening;
using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(ColorPicker))]
    public class SelectableObject : FactionObject
    {
        protected ColorPicker colorPicker;
        
        [SerializeField] private Transform selectionCircle;
        [SerializeField] private Transform selectionBox;
        private Tween selectionTween;

        private void Awake()
        {
            colorPicker = GetComponent<ColorPicker>();
        }

        private void OnDestroy()
        {
            selectionTween?.Kill();
        }

        public void Select()
        {
            selectionTween?.Kill();
            selectionTween = PlaySelect();
            selectionTween.Play();
        }
        
        public void RemoveSelection()
        {
            colorPicker.UpdateColor(faction);
            
            selectionTween?.Kill();
            selectionTween = PlayDeSelect();
            selectionTween.Play();
        }

        private Tween PlaySelect()
        {
            Sequence sequence = DOTween.Sequence();
            /*sequence.Append(selectionCircle.DOMoveY(0.75f, 0.25f).SetEase(Ease.OutCubic));*/
            sequence.Append(selectionCircle.DOScale(Vector3.one, 0.25f).SetEase(Ease.OutCubic));
            sequence.Insert(0, selectionBox.DOScale(Vector3.one, 0.25f).SetEase(Ease.OutCubic));
            return sequence;
        }
        
        private Tween PlayDeSelect()
        {
            Sequence sequence = DOTween.Sequence();
            /*sequence.Append(selectionCircle.DOMoveY(0, 0.15f).SetEase(Ease.OutCubic));*/
            sequence.Append(selectionCircle.DOScale(Vector3.zero, 0.15f).SetEase(Ease.OutCubic));
            sequence.Insert(0, selectionBox.DOScale(Vector3.zero, 0.15f).SetEase(Ease.OutCubic));
            return sequence;
        }
    }
}
