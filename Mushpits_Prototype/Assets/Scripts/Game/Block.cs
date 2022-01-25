using Game.Enums;
using UnityEngine;

namespace Game
{
    public class Block : MonoBehaviour
    {
        [SerializeField] private FactionType faction;
        public FactionType Faction => faction;
        
        [SerializeField] private Unit unit;
        [SerializeField] private Goal goal;
    }
}
