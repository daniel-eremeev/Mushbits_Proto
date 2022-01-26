using System;

namespace Utility.GameStateSystem
{
    public static class GameStateManager
    {
        private static GameState currentState;

        public static GameState CurrentState
        {
            get => currentState;
            set
            {
                currentState = value;
                OnGameStateChanged?.Invoke(currentState);
            }
        }

        public static event Action<GameState> OnGameStateChanged;
    }
}
