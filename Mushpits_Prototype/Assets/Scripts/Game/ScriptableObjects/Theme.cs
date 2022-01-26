using Game.Enums;
using UnityEngine;

namespace Game.ScriptableObjects
{
    [CreateAssetMenu(order = 0, fileName = "Theme", menuName = "Theme")]
    public class Theme : ScriptableObject
    {
        [SerializeField] private Color[] factionColors;
        [SerializeField] private Texture[] blockTextures;

        public Color GetFactionColor(FactionType type)
        {
            return type switch
            {
                FactionType.Pink => factionColors[1],
                FactionType.Blue => factionColors[2],
                _ => factionColors[0]
            };
        }
        
        public Texture GetBlockTexture(BlockType type)
        {
            return type switch
            {
                BlockType.Frozen => blockTextures[1],
                BlockType.Puzzle => blockTextures[2],
                _ => blockTextures[0]
            };
        }
    }
}
