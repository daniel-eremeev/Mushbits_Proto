using System.Collections.Generic;
using Game.Enums;
using UnityEngine;

namespace Game
{
    public class Block : FactionObject
    {
        [SerializeField] private bool isLocked;
        
        [SerializeField] private List<Block> neighbours = new List<Block>();
        public IEnumerable<Block> Neighbours => neighbours;

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
            if (Physics.Raycast(transform.position, direction, out RaycastHit hit, 1f))
            {
                if (hit.collider.TryGetComponent(out block))
                    return true;
            }

            block = null;
            return false;
        }

        #endregion

        private void Awake()
        {
            GetComponentInChildren<MeshRenderer>().material.color = GetFactionColor(faction);
        }

        public void Select()
        {
            GetComponentInChildren<MeshRenderer>().material.color = Color.green;
        }
        
        public void RemoveSelection()
        {
            GetComponentInChildren<MeshRenderer>().material.color = GetFactionColor(faction);
        }

        public void ChangeFaction(FactionType unitFaction)
        {
            if(isLocked)
                return;
            
            faction = GetOpposingFaction(unitFaction);
            RemoveSelection();
        }
    }
}