using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private int _health = 100;
    private Animator _animator;
    private Rigidbody2D _rigidbody2D;
    
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    
    private bool isGrounded;
    private bool isDead;

  
    public KeyCode moveLeftKey = KeyCode.A;    
    public KeyCode moveRightKey = KeyCode.D;   
    public KeyCode jumpKey = KeyCode.Space;    
    public KeyCode attackKey = KeyCode.J;      
    public KeyCode deathKey = KeyCode.K;       
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Reset the movement
        float move = 0f;
        if(!isDead){
            // Handle Left Movement
            if (Input.GetKey(moveLeftKey))
            {
                move = -1f;  // Move left
                _animator.SetBool("Running", true);
                transform.localScale = new Vector3(-1, 1, 1);  // Flip the character
            }
            // Handle Right Movement
            else if (Input.GetKey(moveRightKey))
            {
                move = 1f;   // Move right
                _animator.SetBool("Running", true);
                transform.localScale = new Vector3(1, 1, 1);   // Flip back to the right
            }
            else
            {
                _animator.SetBool("Running", false);  // Stop running animation
            }
            // Apply the movement to the Rigidbody2D
                _rigidbody2D.linearVelocity = new Vector2(move * moveSpeed, _rigidbody2D.linearVelocity.y);

            // Handle Jump
            if (Input.GetKeyDown(jumpKey) /* && isGrounded*/)
            {
                _animator.SetTrigger("Jump");
                _animator.SetBool("Running", false);
                _rigidbody2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                _animator.SetTrigger("Jump");
            }

            // Handle Attack
            if (Input.GetKeyDown(attackKey))
            {
                _animator.SetTrigger("Attack");
            }
            // Handle Death (for testing purposes)
            if (Input.GetKeyDown(deathKey))
            {
                _animator.SetTrigger("Death");
                _rigidbody2D.linearVelocity = Vector2.zero;
                isDead = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}
