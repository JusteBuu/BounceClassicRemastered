using Controllers;
using UnityEngine;

namespace Collectables
{
    public class RingCollectible : MonoBehaviour
    {
        [Header("Ring Settings")]
        [SerializeField] private Sprite smallRingSprite; // Drag your small ring sprite here
        
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
                bool playerIsInflated = IsPlayerInflated(player);
                
                if (CanCollectRing(playerIsInflated))
                {
                    CollectRing();
                }
                else if (playerIsInflated && IsSmallRing())
                {
                    // Player is big but ring is small - block the player
                    BlockPlayer(other);
                }
            }
        }
        
        private bool IsPlayerInflated(PlayerController player)
        {
            // Check if player is using the inflated sprite
            SpriteRenderer playerSprite = player.GetComponent<SpriteRenderer>();
            
            if (playerSprite != null && playerSprite.sprite != null)
            {
                // Check for the specific inflated sprite name
                return playerSprite.sprite.name == "ball_small_120";
            }
            
            return false;
        }
        
        private bool IsSmallRing()
        {
            if (_spriteRenderer != null && _spriteRenderer.sprite != null)
            {
                // Method 1: Check if sprite matches the assigned small ring sprite
                if (smallRingSprite != null && _spriteRenderer.sprite == smallRingSprite)
                {
                    return true;
                }
                
                // Method 2: Check by sprite name
                if (_spriteRenderer.sprite.name == "ring_smallSmall")
                {
                    return true;
                }
            }
            return false;
        }
        
        private bool CanCollectRing(bool playerIsInflated)
        {
            if (!playerIsInflated)
            {
                // Small player can collect all rings
                return true;
            }
            else
            {
                // Big player can only collect big rings (not small rings)
                return !IsSmallRing();
            }
        }
        
        private void BlockPlayer(Collider2D playerCollider)
        {
            // Get the player's rigidbody to stop movement
            Rigidbody2D playerRb = playerCollider.GetComponent<Rigidbody2D>();
            
            if (playerRb != null)
            {
                // Stop the player's velocity
                playerRb.linearVelocity = Vector2.zero;
                
                // Push player back from the ring
                Vector2 pushDirection = (playerCollider.transform.position - transform.position).normalized;
                playerRb.AddForce(pushDirection * 8f, ForceMode2D.Impulse);
            }
            
            Debug.Log("Small ring blocks inflated player!");
        }
    
        private void CollectRing()
        {
            _isCollected = true;
            
            if (_spriteRenderer != null)
                _spriteRenderer.color = Color.grey;
        
            if (GameManager.Instance != null)
                GameManager.Instance.CollectRing();
                
            Debug.Log($"{(IsSmallRing() ? "Small" : "Big")} ring collected!");
        }
        
        // Visual debugging
        private void OnDrawGizmosSelected()
        {
            // Ring size visualization
            bool isSmall = IsSmallRing();
            Gizmos.color = isSmall ? Color.yellow : Color.blue;
            Gizmos.DrawWireSphere(transform.position, isSmall ? 0.5f : 1f);
        }
    }
}