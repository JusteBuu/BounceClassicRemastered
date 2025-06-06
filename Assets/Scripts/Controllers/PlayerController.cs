using UnityEngine;

namespace Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Health")] [SerializeField] private int maxHealth = 5;
        private int _currentHealth;

        [Header("Movement")] [SerializeField] private float moveForce = 10f;
        [SerializeField] private float jumpForce = 10f;
        [SerializeField] private float torqueForce = 5f;

        [Header("Ground Detection")] [SerializeField]
        private LayerMask groundLayer;

        [SerializeField] private float groundCheckRadius = 0.55f;
        
        [Header("References")] [SerializeField]
        private UIManager uiManager;

        // Components
        private Rigidbody2D _rb;
        private SpriteRenderer _spriteRenderer;
        private PlayerControls _controls;

        // State
        private Vector2 _moveInput;
        private bool _isGrounded;
        private Sprite _originalSprite;

        // Properties
        public int Health => _currentHealth;
        public int MaxHealth => maxHealth;
        public bool IsAtMaxHealth => _currentHealth >= maxHealth;

        private void Awake()
        {
            _controls = new PlayerControls();
            _rb = GetComponent<Rigidbody2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();

            if (_spriteRenderer != null)
                _originalSprite = _spriteRenderer.sprite;
        }

        private void OnEnable()
        {
            _controls.Enable();
        }

        private void OnDisable()
        {
            _controls.Disable();
        }

        private void Start()
        {
            _currentHealth = maxHealth;
            _controls.Player.Jump.performed += ctx => Jump();

            if (uiManager != null)
                uiManager.UpdateLives(_currentHealth);
        }

        private void Update()
        {
            _moveInput = _controls.Player.Move.ReadValue<Vector2>();
        }

        private void FixedUpdate()
        {
            Move();
            CheckGround();
        }

        private void Move()
        {
            if (_rb != null)
            {
                _rb.AddForce(new Vector2(_moveInput.x * moveForce, 0f));
                _rb.AddTorque(-_moveInput.x * torqueForce);
            }
        }

        private void Jump()
        {
            if (_isGrounded && _rb != null)
            {
                _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }

        private void CheckGround()
        {
            _isGrounded = Physics2D.OverlapCircle(transform.position, groundCheckRadius, groundLayer);
        }

        public void ChangeHealth(int amount)
        {
            var newHealth = Mathf.Clamp(_currentHealth + amount, 0, maxHealth);
            if (newHealth != _currentHealth)
            {
                _currentHealth = newHealth;
                Debug.Log($"Health: {_currentHealth}/{maxHealth}");

                if (uiManager != null)
                    uiManager.UpdateLives(_currentHealth);
            }
        }

        public void SetGroundCheckRadius(float newRadius)
        {
            groundCheckRadius = newRadius;
        }

        public void ChangeSprite(Sprite newSprite)
        {
            if (_spriteRenderer != null && newSprite != null)
                _spriteRenderer.sprite = newSprite;
        }

        private void RestoreOriginalSprite()
        {
            if (_spriteRenderer != null && _originalSprite != null)
                _spriteRenderer.sprite = _originalSprite;
        }

        public void FreezePhysics()
        {
            if (_rb != null)
                _rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }

        private void UnfreezePhysics()
        {
            if (_rb != null)
                _rb.constraints = RigidbodyConstraints2D.None;
        }

        public void ResetToPosition(Vector3 position)
        {
            transform.position = position;
            transform.rotation = Quaternion.identity;
            UnfreezePhysics();
            RestoreOriginalSprite();
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = _isGrounded ? Color.green : Color.red;
            Gizmos.DrawWireSphere(transform.position, groundCheckRadius);
        }
    }
}