using UnityEngine;

namespace Controllers
{
    public class SpikyController : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] private float moveSpeed = 2f;
        [SerializeField] private bool startMovingUp = true;
        [SerializeField] private float movementRange = 3f; // How far up/down to move
    
        [Header("Damage & Pop")]
        [SerializeField] private Transform startPosition;
        [SerializeField] private Sprite popSprite;
        [SerializeField] private int damage = 1;
        [SerializeField] private float resetDelay = 3f;
    
        private Vector3 startPos;
        private Vector3 topPosition;
        private Vector3 bottomPosition;
        private Vector3 targetPosition;
        private bool movingUp;
        private PlayerController _player;
    
        private void Start()
        {
            startPos = transform.position;
            
            topPosition = startPos + Vector3.up * movementRange;
            bottomPosition = startPos + Vector3.down * movementRange;
            
            movingUp = startMovingUp;
            targetPosition = movingUp ? topPosition : bottomPosition;
        }
    
        private void Update()
        {
            MoveTowardsTarget();
        }
        
        private void MoveTowardsTarget()
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                movingUp = !movingUp;
                targetPosition = movingUp ? topPosition : bottomPosition;
            }
        }
    
        private void OnCollisionEnter2D(Collision2D collision)
        {
            _player = collision.gameObject.GetComponent<PlayerController>();
        
            if (_player != null)
            {
                _player.ChangeHealth(-damage);
                _player.ChangeSprite(popSprite);
                _player.FreezePhysics();
            
                Invoke(nameof(ResetPlayer), resetDelay);
            }
        }
    
        private void ResetPlayer()
        {
            if (_player != null && startPosition != null)
            {
                _player.ResetToPosition(startPosition.position);
            }
        }
    }
}
