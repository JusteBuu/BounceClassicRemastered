using UnityEngine;

namespace Controllers
{
    public class ThornController : MonoBehaviour
    {
        [SerializeField] private Transform startPosition;
        [SerializeField] private Sprite popSprite;
        [SerializeField] private int damage = 1;
        [SerializeField] private float resetDelay = 3f;
    
        private PlayerController _player;
    
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