using UnityEngine;

namespace Controllers
{
    public class SpikyController : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] private float moveSpeed = 2f;
        [SerializeField] private float moveDistance = 3f;
        [SerializeField] private bool startMovingUp = true;
    
        [Header("Damage")]
        [SerializeField] private int damage = 1;
    
        private Vector3 _startPos;
        private Vector3 _targetPos;
        private bool _movingUp;
    
        private void Start()
        {
            Transform myTransform = GetComponent<Transform>();
            _startPos = myTransform.position;
        
            _movingUp = startMovingUp;
        
            CalculateTargetPosition();
        }
    
        private void Update()
        {
            MoveUpAndDown();
        }
    
        private void MoveUpAndDown()
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPos, moveSpeed * Time.deltaTime);
        
            if (Vector3.Distance(transform.position, _targetPos) < 0.1f)
            {
                _movingUp = !_movingUp;
                CalculateTargetPosition();
            }
        }
    
        private void CalculateTargetPosition()
        {
            if (_movingUp)
            {
                _targetPos = _startPos + Vector3.up * moveDistance;
            }
            else
            {
                _targetPos = _startPos + Vector3.down * moveDistance;
            }
        }
    
        private void OnCollisionEnter2D(Collision2D collision)
        {
            var player = collision.gameObject.GetComponent<PlayerController>();
        
            if (player != null)
            {
                player.ChangeHealth(-damage);
            }
        }
    
        private void OnDrawGizmosSelected()
        {
            Vector3 basePos = Application.isPlaying ? _startPos : transform.position;
        
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(basePos + Vector3.down * moveDistance, basePos + Vector3.up * moveDistance);
        
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(basePos + Vector3.up * moveDistance, 0.2f);
            Gizmos.DrawWireSphere(basePos + Vector3.down * moveDistance, 0.2f);
        
            if (Application.isPlaying)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawWireSphere(_targetPos, 0.3f);
            }
        }
    }
}