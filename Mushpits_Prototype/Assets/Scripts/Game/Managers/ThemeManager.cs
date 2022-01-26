using Game.ScriptableObjects;
using UnityEngine;

namespace Game.Managers
{
    public static class ThemeManager
    {
        private static Theme theme;
        public static Theme Theme => theme;

        [RuntimeInitializeOnLoadMethod]
        private static void Init()
        {
            theme = Resources.Load<Theme>("Theme");
        }
    }
}
