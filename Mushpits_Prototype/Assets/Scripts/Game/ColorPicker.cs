using Game.Enums;
using Game.Managers;
using UnityEngine;

namespace Game
{
    public class ColorPicker : MonoBehaviour
    {
        [SerializeField] private MeshRenderer meshRenderer;

        private void Awake()
        {
            if (meshRenderer == null)
                meshRenderer = GetComponentInChildren<MeshRenderer>();
        }

        public void UpdateColor(FactionType type)
        {
            if(meshRenderer == null)
                return;
            meshRenderer.material.color = ThemeManager.Theme.GetFactionColor(type);
        } 

        public void UpdateTexture(BlockType type)
        {
            if(meshRenderer == null)
                return;
            meshRenderer.material.mainTexture = ThemeManager.Theme.GetBlockTexture(type);
        }
    }
}
