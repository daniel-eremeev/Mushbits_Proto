using UI.UISystem;
using Utility.GameStateSystem;

namespace UI.UIScreens
{
    public class MenuScreen : UIScreen
    {
        public void OnPlayButtonClick()
        {
            GameStateManager.CurrentState = GameState.Game;
        }
    }
}
