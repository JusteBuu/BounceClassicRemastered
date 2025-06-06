using UnityEngine;

namespace Controllers
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private Vector3 offset;
        [SerializeField] private bool lockY = true;
        [SerializeField] private bool lockZ = true;
    
        private void Start()
        {
            if (target != null)
            {
                CalculateOffset();
            }
        }
    
        private void CalculateOffset()
        {
            offset = transform.position - target.position;
        }
    
        private void LateUpdate()
        {
            if (target != null)
            {
                Vector3 targetPosition = target.position + offset;
            
                if (lockY)
                    targetPosition.y = transform.position.y;
                if (lockZ)
                    targetPosition.z = transform.position.z;
                
                transform.position = targetPosition;
            }
        }
    }
}