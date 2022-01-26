using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class LevelContainer : MonoBehaviour
    {
        private readonly List<Block> blocks = new List<Block>();
        
        public static Vector3 LevelSize;

        private void Awake()
        {
            blocks.AddRange(GetComponentsInChildren<Block>());
            LevelSize = CalculateCenterPosition();
        }

        private Vector3 CalculateCenterPosition()
        {
            Vector3 position = Vector3.zero;
            foreach (var block in blocks)
            {
                position += block.transform.position;
            }
            position /= blocks.Count;
            return position;
        }

        private void Start()
        {
            InitializeBlocks();
        }

        private void InitializeBlocks()
        {
            foreach (var block in blocks)
            {
                block.Initialize();
            }
        }
    }
}
