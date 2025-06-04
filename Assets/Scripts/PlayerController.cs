using UnityEngine;

    public class PlayerController : MonoBehaviour
    {
        public int health
        {
            get { return currentHealth; }
        }
        
        //The SerializeField provide visibility in the inspector even though the field is private
        public PlayerControls controls;
        
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private float moveForce;
        [SerializeField] private float jumpForce;
        [SerializeField] private Transform groundCheck;
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private float groundCheckRadius;
        [SerializeField] private float torqueForce; 

        private Vector2 moveInput;
        private bool isGrounded;

        public int maxHealth = 5;
        public int currentHealth;

        private void Awake()
        {
            controls = new PlayerControls();
        }

        private void OnEnable()
        {
            controls.Enable();
        }

        private void OnDisable()
        {
            controls.Disable();
        }

        private void Start()
        {
            currentHealth = maxHealth;
            
            rb = GetComponent<Rigidbody2D>();

            // Hook up jump action
            controls.Player.Jump.performed += ctx => Jump();
        }

        private void Update()
        {
            moveInput = controls.Player.Move.ReadValue<Vector2>();
        }

        private void FixedUpdate()
        {
            Move();
            CheckGround();
        }

        private void Move()
        {
            rb.AddForce(new Vector2(moveInput.x * moveForce, 0f));
            rb.AddTorque(-moveInput.x * torqueForce);
        }

        private void Jump()
        {
            if (isGrounded)
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }

        private void CheckGround()
        {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        }

        public void ChangeHealth(int amount)
        {
                //This instruction makes sure that currentHealth cannot be set to a value that is over the maxHealth value or below 0
                currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
                Debug.Log(currentHealth + "/" + maxHealth);
        }
    }

