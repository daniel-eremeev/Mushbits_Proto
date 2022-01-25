using System.Collections.Generic;
using System.Linq;
using Game.Enums;
using UnityEngine;

namespace Game.Managers
{
    public class PathManager : MonoBehaviour
    {
        [SerializeField] private List<Block> blockPath = new List<Block>();
        [SerializeField] private List<Block> removePath = new List<Block>();

        private void Awake()
        {
            GameManager.OnSelect += HandleSelect;
            InputManager.OnRelease += HandleRelease;
        }

        private void OnDestroy()
        {
            GameManager.OnSelect -= HandleSelect;
            InputManager.OnRelease -= HandleRelease;
        }

        private void HandleSelect(Block block)
        {
            if ((blockPath.Count == 0 || block.Faction != UnitManager.GetUnitOnBlock(blockPath[0]).Faction &&
                block.Faction != FactionType.Yellow) && blockPath.Count != 0) 
                return;
            
            if (!blockPath.Contains(block))
            {
                if (blockPath.Count != 0 && !block.Neighbours.Any(neighbour => (neighbour == blockPath.Last())))
                    return;

                blockPath.Add(block);
                block.Select();
            }
            else
            {
                var blockIndex = blockPath.IndexOf(block);
                RemoveFrom(blockIndex + 1);
            }
        }

        private void HandleRelease()
        {
            if (blockPath.Count > 1)
            {
                UnitManager.GetUnitOnBlock(blockPath[0]).FollowPath(blockPath);
            }

            foreach (var block in blockPath)
            {
                block.RemoveSelection();
            }

            blockPath.Clear();
        }

        private void RemoveFrom(int index)
        {
            if (index == 0)
                return;

            for (int x = index; x < blockPath.Count; x++)
            {
                removePath.Add(blockPath[x]);
            }

            blockPath.RemoveRange(index, blockPath.Count - index);

            foreach (var block in removePath)
            {
                block.RemoveSelection();
            }

            removePath.Clear();
        }
    }
}