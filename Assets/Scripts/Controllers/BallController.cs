using UnityEngine;

namespace Controllers
{
    public class BallController : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private Animator animator;
    
        private Sprite _originalSprite;
    
        private void Awake()
        {
            if (spriteRenderer == null)
                spriteRenderer = GetComponent<SpriteRenderer>();
            if (animator == null)
                animator = GetComponent<Animator>();
            
            if (spriteRenderer != null)
                _originalSprite = spriteRenderer.sprite;
        }
    
        public void ChangeSprite(Sprite newSprite)
        {
            if (spriteRenderer != null && newSprite != null)
                spriteRenderer.sprite = newSprite;
        }
    
        public void RestoreOriginalSprite()
        {
            if (spriteRenderer != null && _originalSprite != null)
                spriteRenderer.sprite = _originalSprite;
        }
    
        public void ResetRotation()
        {
            transform.rotation = Quaternion.identity;
        }
    
        public void SetColor(Color color)
        {
            if (spriteRenderer != null)
                spriteRenderer.color = color;
        }
    }
}