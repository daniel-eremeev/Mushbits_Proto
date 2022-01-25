using Game.Enums;
using UnityEngine;

namespace Game
{
    public abstract class FactionObject : MonoBehaviour
    {
        [SerializeField] protected FactionType faction;
        public FactionType Faction => faction;
        
        protected Color GetFactionColor(FactionType type)
        {
            Color factionColor;
            switch (type)
            {
                case FactionType.Pink:
                    factionColor = Color.magenta;
                    break;
                case FactionType.Blue:
                    factionColor = Color.blue;
                    break;
                default:
                    factionColor = Color.yellow;
                    break;
            }
            return factionColor;
        }
        
        protected FactionType GetOpposingFaction(FactionType factionType)
        {
            FactionType opposingFaction;
            switch (factionType)
            {
                case FactionType.Pink:
                    opposingFaction = FactionType.Blue;
                    break;
                default:
                    opposingFaction = FactionType.Pink;
                    break;
            }
            return opposingFaction;
        }
    }
}
