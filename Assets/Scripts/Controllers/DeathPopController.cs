using UnityEngine;

namespace Controllers
{
    public class DeathPopController : MonoBehaviour
    {
        public GameObject ball;
        public Sprite popSprite;

        private SpriteRenderer _spriteRenderer;
        private Animator _animator;

        private void Start()
        {
            _spriteRenderer = ball.GetComponent<SpriteRenderer>();
            _animator = ball.GetComponent<Animator>();      
        }
    }
}
