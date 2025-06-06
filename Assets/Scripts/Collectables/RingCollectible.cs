using Controllers;
using UnityEngine;

namespace Collectables
{
    public class RingCollectible : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;
        private bool _isCollected = false;
    
        private void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }
    
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (_isCollected) return;
        
            var player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                CollectRing();
            }
        }
    
        private void CollectRing()
        {
            _isCollected = true;
            
            if (_spriteRenderer != null)
                _spriteRenderer.color = Color.grey;
        
            if (GameManager.Instance != null)
                GameManager.Instance.CollectRing();
        }
    }
}