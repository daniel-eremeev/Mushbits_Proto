using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class LevelContainer : MonoBehaviour
    {
        private readonly List<Block> blocks = new List<Block>();

        private void Awake()
        {
            blocks.AddRange(GetComponentsInChildren<Block>());
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
