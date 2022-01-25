using DG.Tweening;
using Game.Managers;
using UnityEngine;

namespace Game
{
    public class Unit : FactionObject
    {
        [SerializeField] private Block currentBlock;
        public Block CurrentBlock => currentBlock;

        private void Awake()
        {
            this.Register();

            GetComponentInChildren<MeshRenderer>().material.color = GetFactionColor(faction);
        }

        private void Start()
        {
            UpdateCurrentBlock();
        }

        private void OnDisable()
        {
            this.UnRegister();
        }

        public void UpdateCurrentBlock()
        {
            if (Physics.Raycast(transform.position + Vector3.up / 2, -Vector3.up, out RaycastHit hit, 1f))
            {
                if (hit.collider.TryGetComponent<Block>(out var block))
                    currentBlock = block;
            }
        }

        public void Dispose()
        {
            UpdateCurrentBlock();
            currentBlock.ChangeFaction(faction);
            VfxManager.PlayExplosion(transform.position);
            gameObject.SetActive(false);
        }

        public Tween Jump(Block previousBlock, Transform nextBlock)
        {
            Sequence sequence = DOTween.Sequence();
            sequence.Append(DOVirtual.DelayedCall(0f, () => previousBlock.ChangeFaction(faction)));
            sequence.Append(transform.DOJump(nextBlock.transform.position, .75f, 1, 0.25f).SetEase(Ease.Linear));
            sequence.Append(transform.DOMoveY(transform.position.y - 0.25f, 0.05f).SetEase(Ease.OutQuad));
            sequence.Insert(0.25f, nextBlock.DOMoveY(nextBlock.position.y - 0.25f, 0.05f).SetEase(Ease.OutQuad));
            sequence.Insert(0.30f, nextBlock.DOMoveY(nextBlock.position.y, 0.1f));
            sequence.Insert(0.30f, transform.DOMoveY(transform.position.y, 0.1f));
            return sequence;
        }

        public bool IsOnGoal()
        {
            Debug.DrawRay(transform.position + Vector3.up, -Vector3.up, Color.green, 10f);
            if (Physics.Raycast(transform.position + Vector3.up, -Vector3.up, out RaycastHit hit))
            {
                if (hit.collider.TryGetComponent<Goal>(out var goal) && goal.Faction == faction)
                {
                    goal.gameObject.SetActive(false);
                    return true;
                }
            }

            return false;
        }
    }
}