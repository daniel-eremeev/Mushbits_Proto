using System;
using UnityEngine;

namespace Game.Managers
{
    public class VfxManager : MonoBehaviour
    {
        [SerializeField] private ParticleSystem explosionVfx;

        public static Action<Vector3> PlayExplosion;

        private void Awake()
        {
            PlayExplosion = HandlePlayVfx;
        }

        private void HandlePlayVfx(Vector3 position)
        {
            explosionVfx.transform.position = position;
            explosionVfx.Play(true);
        }
    }
}
