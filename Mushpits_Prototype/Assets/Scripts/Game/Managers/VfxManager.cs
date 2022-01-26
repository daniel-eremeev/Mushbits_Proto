using System;
using Game.Enums;
using UnityEngine;

namespace Game.Managers
{
    public class VfxManager : MonoBehaviour
    {
        [SerializeField] private ParticleSystem blueExplosionVFX;
        [SerializeField] private ParticleSystem pinkExplosionVFX;

        public static Action<Vector3, FactionType> PlayExplosion;

        private void Awake()
        {
            PlayExplosion = HandlePlayVfx;
        }

        private void HandlePlayVfx(Vector3 position, FactionType factionType)
        {
            if(factionType == FactionType.Pink)
            {
                pinkExplosionVFX.transform.position = position;
                pinkExplosionVFX.Play(true);
            }
            else
            {
                blueExplosionVFX.transform.position = position;
                blueExplosionVFX.Play(true);
            }
        }
    }
}
