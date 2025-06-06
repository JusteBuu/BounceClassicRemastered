using UnityEngine;

namespace Systems
{
    public class MovementSystem : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private float moveForce = 10f;
        [SerializeField] private float jumpForce = 15f;
        [SerializeField] private float torqueForce = 5f;
    
        private void Awake()
        {
            if (rb == null)
                rb = GetComponent<Rigidbody2D>();
        }
    
        public void Move(Vector2 input)
        {
            if (rb != null)
            {
                rb.AddForce(new Vector2(input.x * moveForce, 0f));
                rb.AddTorque(-input.x * torqueForce);
            }
        }
    
        public void Jump()
        {
            if (rb != null)
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }
    }
}