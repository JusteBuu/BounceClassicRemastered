using UnityEngine;

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
        
        var controller = other.GetComponent<PlayerController>();
        
        if (controller != null)
        {
            _spriteRenderer.color = Color.grey;
            _isCollected = true;
            
            GameManager.Instance.CollectRing();
        }
    }
}