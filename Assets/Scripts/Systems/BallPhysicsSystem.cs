using UnityEngine;

namespace Systems
{
    public class BallPhysicsSystem : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private Transform resetPosition;
    
        private void Awake()
        {
            if (rb == null)
                rb = GetComponent<Rigidbody2D>();
        }
    
        public void FreezeAll()
        {
            if (rb != null)
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    
        private void UnfreezeAll()
        {
            if (rb != null)
                rb.constraints = RigidbodyConstraints2D.None;
        }
    
        private void ResetToPosition(Vector3 position)
        {
            transform.position = position;
            UnfreezeAll();
        }
    
        public void SetResetPosition(Transform newResetPosition)
        {
            resetPosition = newResetPosition;
        }
    
        public void ResetToSavedPosition()
        {
            if (resetPosition != null)
                ResetToPosition(resetPosition.position);
        }
    }
}