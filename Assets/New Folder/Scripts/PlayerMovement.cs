using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float fallThreshold = -10f;
    private Rigidbody2D body;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;
    private float horizontalInput;
    private bool isFalling = false;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // if (body.velocity.x > 0.1f)
        // {
        //     spriteRenderer.flipX = false;
        // }
        // else if (body.velocity.x < -0.1f)
        // {
        //     spriteRenderer.flipX = true;
        // }
        horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        if (horizontalInput > 0.01f)
            spriteRenderer.flipX = false;
        else if (horizontalInput < -0.01f)
            spriteRenderer.flipX = true;
      

        if (Input.GetButtonDown("Jump") && isGrounded())
            Jump();
    }

    private void FixedUpdate()
    {
        CheckFall();
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed + 4);
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast (boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    public bool canAttack()
    {
        return horizontalInput == 0;
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void CheckFall()
    {
        if (transform.position.y < fallThreshold && !isFalling)
        {
            isFalling = true;
            RestartLevel();
        }
        else if (transform.position.y < fallThreshold)
        {
            isFalling = false;
        }
    }
}
