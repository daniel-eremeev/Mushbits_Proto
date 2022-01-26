using Game.Enums;
using UnityEngine;

namespace Game
{
    public abstract class FactionObject : MonoBehaviour
    {
        [SerializeField] protected FactionType faction;
        public FactionType Faction => faction;

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
