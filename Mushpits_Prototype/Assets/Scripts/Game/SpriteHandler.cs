using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class SpriteHandler : MonoBehaviour
    {
        [SerializeField] private List<SpriteRenderer> spriteRenderers = new List<SpriteRenderer>();

        private void Awake()
        {
            if(spriteRenderers.Count == 0)
                spriteRenderers.AddRange(GetComponentsInChildren<SpriteRenderer>());
        }

        private void FlipSprites()
        {
            foreach (var spriteRenderer in spriteRenderers)
            {
                spriteRenderer.flipX = true;
            }
        }

        public void UpdateFacingDirection(Vector3 direction)
        {
            if (direction.x > transform.position.x && !spriteRenderers[0].flipX ||
                direction.x < transform.position.x && spriteRenderers[0].flipX)
            {
                FlipSprites();
            }
        }
    } 
}
