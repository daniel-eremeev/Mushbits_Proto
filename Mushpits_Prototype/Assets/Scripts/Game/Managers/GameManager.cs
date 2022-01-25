using System;
using Game.Enums;
using UnityEngine;

namespace Game.Managers
{
    public class GameManager : MonoBehaviour
    {
        public static event Action<Block> OnSelect;
        public static event Action OnDeselect;
        
        private Camera mainCamera;
        private Block selectedBlock;
        
        private void Awake()
        {
            mainCamera = Camera.main;
            
            InputManager.OnClick += HandleClick;
            InputManager.OnDrag += HandleDrag;
            InputManager.OnRelease += HandleRelease;
        }

        private void OnDestroy()
        {
            InputManager.OnClick -= HandleClick;
            InputManager.OnDrag -= HandleDrag;
            InputManager.OnRelease -= HandleRelease;
        }

        private void HandleClick()
        {
            if (Raycast(out RaycastHit hit) && hit.collider.TryGetComponent<Block>(out var block))
            {
                Debug.Log(block.Faction);
                if (block.Faction != FactionType.Yellow)
                {
                    selectedBlock = block;
                    OnSelect?.Invoke(block);
                }
            }
        }
        
        private void HandleDrag()
        {
            if (Raycast(out RaycastHit hit) && hit.collider.TryGetComponent<Block>(out var block))
            {
                if(block == selectedBlock)
                    return;
                
                if (block.Faction != FactionType.Yellow)
                {
                    selectedBlock = block;
                    OnSelect?.Invoke(block);
                }
            }
        }
        
        private void HandleRelease()
        {
            /*Debug.Log("Has Released!");*/
        }

        private bool Raycast(out RaycastHit hit)
        {
            var ray = mainCamera.ScreenPointToRay(Input.mousePosition + Vector3.forward * -10);
            
            if (Physics.Raycast(ray, out hit))
            {
                return true;
            }
            return false;
        }
    }
}
