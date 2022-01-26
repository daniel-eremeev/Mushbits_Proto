using UnityEngine;
using Utility.GameStateSystem;

namespace Game.Managers
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private Transform arena;
        [SerializeField] private GameObject[] levelPrefabs;

        [SerializeField] private int index = -1;

        private void Awake()
        {
            GameStateManager.OnGameStateChanged += HandleGameStateChanged;
            
            if (index == -1)
                index = Load();
            if (index >= levelPrefabs.Length)
                index = Random.Range(0, levelPrefabs.Length);
            
            Instantiate(levelPrefabs[index == -1 ? Random.Range(0, levelPrefabs.Length) : index], arena);
        }

        private void OnDestroy()
        {
            GameStateManager.OnGameStateChanged -= HandleGameStateChanged;
        }

        private void HandleGameStateChanged(GameState state)
        {
            if(state == GameState.Win)
                Save();
        }
        
        private void Save()
        {
            index++;
            PlayerPrefs.SetInt("Saved_Level_Index", index);
            PlayerPrefs.Save();
        }

        private int Load()
        {
            return PlayerPrefs.GetInt("Saved_Level_Index", 0);
        }
    }
}