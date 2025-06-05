using UnityEngine;

    public class PlayerController : MonoBehaviour
    {
        public int Health => currentHealth;

        //The SerializeField provide visibility in the inspector even though the field is private
        private PlayerControls _controls;
        
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private float moveForce;
        [SerializeField] private float jumpForce;
        [SerializeField] private Transform groundCheck;
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private float groundCheckRadius;
        [SerializeField] private float torqueForce;
        [SerializeField] private UIManager uiManager;

        private Vector2 _moveInput;
        private bool _isGrounded;

        public int maxHealth = 5;
        public int currentHealth;

        private void Awake()
        {
            _controls = new PlayerControls();
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
            currentHealth = maxHealth;
            
            rb = GetComponent<Rigidbody2D>();

            // Hook up jump action
            _controls.Player.Jump.performed += ctx => Jump();
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
            rb.AddForce(new Vector2(_moveInput.x * moveForce, 0f));
            rb.AddTorque(-_moveInput.x * torqueForce);
        }

        private void Jump()
        {
            if (_isGrounded)
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }

        private void CheckGround()
        {
            _isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        }

        public void ChangeHealth(int amount)
        {
            currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
            Debug.Log(currentHealth + "/" + maxHealth);
        
            // Update UI when health changes
            if (uiManager != null)
            {
                uiManager.UpdateLives(currentHealth);
            }
        }
    }

