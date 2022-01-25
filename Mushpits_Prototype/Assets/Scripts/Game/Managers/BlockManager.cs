using System.Collections.Generic;
using UnityEngine;

namespace Game.Managers
{
    public class BlockManager : MonoBehaviour
    {
        [SerializeField] private List<Block> blockPath = new List<Block>();

        private void Awake()
        {
            GameManager.OnSelect += HandleSelect;
            GameManager.OnDeselect += HandleDeselect;
        }

        private void HandleSelect(Block block)
        {
            if(blockPath.Contains(block))
            {
                var blockPositionInList = blockPath.IndexOf(block);
                blockPath.RemoveRange(blockPositionInList, blockPath.Count - 1);
            }
            else
            {
                if (blockPath.Count != 0 && blockPath[0].Faction == block.Faction && !blockPath.Contains(block) ||
                    blockPath.Count == 0)
                    blockPath.Add(block);
            }
        }
        
        private void HandleDeselect()
        {
            blockPath.Clear();
        }
    }
}