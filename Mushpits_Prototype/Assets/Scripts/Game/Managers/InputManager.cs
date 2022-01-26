using System;
using UnityEngine;
using Utility.GameStateSystem;

namespace Game.Managers
{
    public class InputManager : MonoBehaviour
    {
        public static event Action OnClick;
        public static event Action OnDrag;
        public static event Action OnRelease;

        private bool isHolding;

        private void Update()
        {
            if(GameStateManager.CurrentState != GameState.Game)
                return;
            
            if (Input.GetMouseButtonDown(0) && !isHolding)
            {
                OnClick?.Invoke();
                isHolding = true;
            }
            
            if (Input.GetMouseButton(0) && isHolding)
            {
                OnDrag?.Invoke();
            }
            
            if (Input.GetMouseButtonUp(0) && isHolding)
            {
                OnRelease?.Invoke();
                isHolding = false;
            }
        }
    }
}
