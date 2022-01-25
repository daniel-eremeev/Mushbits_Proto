using UnityEngine;

namespace Game
{
    public class Goal : FactionObject
    {
        private void Awake()
        {
            GetComponentInChildren<MeshRenderer>().material.color = GetFactionColor(faction);
        }
    }
}
