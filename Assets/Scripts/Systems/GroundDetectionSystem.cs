using UnityEngine;

namespace Systems
{
    public class GroundDetectionSystem : MonoBehaviour
    {
        [SerializeField] private Transform groundCheck;
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private float groundCheckRadius = 0.35f;
    
        public bool IsGrounded { get; private set; }
    
        public void CheckGround()
        {
            if (groundCheck)
            {
                IsGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
            }
        }
    
        public void SetGroundCheckRadius(float newRadius)
        {
            groundCheckRadius = newRadius;
        }
    
        private void OnDrawGizmosSelected()
        {
            if (groundCheck != null)
            {
                Gizmos.color = IsGrounded ? Color.green : Color.red;
                Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
            }
        }
    }
}