using System;
using UnityEngine;

namespace Game.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private LayerMask mask;
        public static event Action<Block> OnSelect;

        private Camera mainCamera;
        private Block selectedBlock;
        
        private void Awake()
        {
            mainCamera = Camera.main;
            
            InputManager.OnClick += HandleClick;
            InputManager.OnRelease += HandleRelease;
        }
        

        private void OnDestroy()
        {
            InputManager.OnClick -= HandleClick;
            InputManager.OnRelease -= HandleRelease;
        }

        private void HandleClick()
        {
            if (Raycast(out RaycastHit hit) && hit.collider.TryGetComponent<Block>(out var block))
            {
                if (!UnitManager.IsUnitOnBlock(block))
                    return;

                InputManager.OnDrag += HandleDrag;
                selectedBlock = block;
                OnSelect?.Invoke(block);
            }
        }
        
        private void HandleDrag()
        {
            if (Raycast(out RaycastHit hit) && hit.collider.TryGetComponent<Block>(out var block))
            {
                if(block == selectedBlock)
                    return;
                
                selectedBlock = block;
                OnSelect?.Invoke(block);
            }
        }

        private void HandleRelease()
        {
            InputManager.OnDrag -= HandleDrag;
        }
        
        private bool Raycast(out RaycastHit hit)
        {
            var ray = mainCamera.ScreenPointToRay(Input.mousePosition + Vector3.forward * -10);
            
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, mask))
            {
                return true;
            }
            return false;
        }
    }
}
