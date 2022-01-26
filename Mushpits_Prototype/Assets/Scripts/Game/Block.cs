using System.Collections.Generic;
using Game.Enums;
using UnityEngine;

namespace Game
{
    public class Block : SelectableObject
    {
        [SerializeField] private BlockType defaultType;
        [SerializeField] private List<Block> neighbours = new List<Block>();
        
        public IEnumerable<Block> Neighbours => neighbours;
        public Unit UnitOnBlock { get; private set; }

        private BlockType type;

        private BlockType Type
        {
            set
            {
                type = value;
                colorPicker.UpdateTexture(type);
            }
        }

        #region Initialization

        public void Initialize()
        {
            FindNeighbours();
        }

        private void FindNeighbours()
        {
            if (GetNeighbour(Vector3.forward, out var forwardNeighbour))
                neighbours.Add(forwardNeighbour);
            if (GetNeighbour(-Vector3.forward, out var backNeighbour))
                neighbours.Add(backNeighbour);
            if (GetNeighbour(Vector3.right, out var rightNeighbour))
                neighbours.Add(rightNeighbour);
            if (GetNeighbour(-Vector3.right, out var leftNeighbour))
                neighbours.Add(leftNeighbour);
        }

        private bool GetNeighbour(Vector3 direction, out Block block)
        {
            Debug.DrawRay(transform.position, direction, Color.magenta, 10f);
            if (Physics.Raycast(transform.position, direction, out RaycastHit hit, 1f))
            {
                if (hit.collider.TryGetComponent(out block))
                    return true;
            }

            block = null;
            return false;
        }

        #endregion

        private void Start()
        {
            Type = defaultType;
            RemoveSelection();
        }

        public void ChangeFaction(FactionType unitFaction)
        {
            if(type == BlockType.Frozen)
                return;
            
            faction = GetOpposingFaction(unitFaction);
            RemoveSelection();
        }

        public void SetUnitOnBlock(Unit unit)
        {
            UnitOnBlock = unit;
        }
    }
}