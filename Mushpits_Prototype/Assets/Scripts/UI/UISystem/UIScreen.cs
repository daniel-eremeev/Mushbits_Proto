using UnityEngine;
using Utility.GameStateSystem;

namespace UI.UISystem
{
    public class UIScreen : MonoBehaviour
    {
        [SerializeField] private GameState gameState;
        public GameState GameState => gameState;
    }
}
