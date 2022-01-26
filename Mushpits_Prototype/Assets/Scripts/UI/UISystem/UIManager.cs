using System.Collections.Generic;
using UnityEngine;
using Utility.GameStateSystem;

namespace UI.UISystem
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameState defaultState;
        private readonly List<UIScreen> screenList = new List<UIScreen>();

        private void Awake()
        {
            screenList.AddRange(GetComponentsInChildren<UIScreen>(true));
            GameStateManager.OnGameStateChanged += HandleGameStateChanged;

            GameStateManager.CurrentState = defaultState;
        }

        private void OnDestroy()
        {
            GameStateManager.OnGameStateChanged -= HandleGameStateChanged;
        }

        private void HandleGameStateChanged(GameState state)
        {
            foreach (var screen in screenList)
            {
                screen.gameObject.SetActive(screen.GameState == state);
            }
        }
    }
}
