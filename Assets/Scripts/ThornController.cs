using UnityEngine;

    public class ThornController : MonoBehaviour
    {
        public Transform startPosition;
        public Sprite popSprite;
        public GameObject ball;
        
        private SpriteRenderer _spriteRenderer;
        private Sprite _originalSprite;
        private Rigidbody2D _ballRigidbody;
        
        private void Start()
        {
            _spriteRenderer = ball.GetComponent<SpriteRenderer>();
            _originalSprite = _spriteRenderer.sprite;
            _ballRigidbody = ball.GetComponent<Rigidbody2D>(); 
        }

        public void OnCollisionEnter2D(Collision2D collision)
        {
            PlayerController controller = collision.gameObject.GetComponent<PlayerController>();

            if (controller != null)
            {
                controller.ChangeHealth(-1);
                Pop();
                Invoke(nameof(ResetBallPosition), 3);
            }
        }

        private void FreezeBall()
        {
            _ballRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
        }

        private void Pop()
        {
            _spriteRenderer.sprite = popSprite;
            ball.transform.rotation = Quaternion.Euler(0, 0, 0);
            FreezeBall();
        }

        private void ResetBallPosition()
        {
            ball.transform.position = startPosition.position;
            _spriteRenderer.sprite = _originalSprite;
            _ballRigidbody.constraints = RigidbodyConstraints2D.None;
        }
    }


