using System.Collections.Generic;
using DG.Tweening;

namespace Game.Managers
{
    public static class ActionManager
    {
        private static Tween actionTween;
        private static Sequence actionSequence;

        public static void FollowPath(this Unit unit, List<Block> jumpPath)
        {
            if (unit == null)
                return;

            actionSequence = DOTween.Sequence();
            for (int x = 1; x < jumpPath.Count; x++)
            {
                var nextBlock = jumpPath[x];
                var previousBlock = jumpPath[x - 1];
                actionSequence.Append(unit.Jump(previousBlock, nextBlock.transform)
                    .OnComplete(unit.CheckGoal));
            }

            actionTween = actionSequence;
            actionTween.OnComplete(unit.UpdateCurrentBlock);
            actionTween.Play();
        }

        private static void CheckGoal(this Unit unit)
        {
            if (!unit.IsOnGoal()) 
                return;
            
            actionTween?.Kill();
            unit.Dispose();
        }
    }
}