using UnityEngine;

namespace Utility
{
    [ExecuteAlways]
    public class LookAt : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;

        private void Awake()
        {
            if(mainCamera == null)
                mainCamera = Camera.main;
        }

        private void Update()
        {
            if(mainCamera == null)
                return;
            transform.LookAt(mainCamera.transform);
        }
    }
}
