using UnityEngine;

namespace Game
{
    public class CameraController : MonoBehaviour
    {
        private void Start()
        {
            transform.position = LevelContainer.LevelSize;
        }
    }
}
