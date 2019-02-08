using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {
    public float speed;
    public float jumpForce;

    float moveInput;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private bool isGrounded;
    private Animator anim;

    bool isFacingRight;

    private int extraJumps;
    public int maxJumpCount;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    public Button left;
    public Button right;

    private void Start() {
        extraJumps = maxJumpCount;
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        left.onClick.AddListener(() => {
            moveInput = -1;
        });
        right.onClick.AddListener(() => {
            moveInput = 1;
        });
        
    }

    private void LateUpdate() {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius ,whatIsGround);

        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (moveInput > 0 && isFacingRight) SwapSprite();
        else if (moveInput < 0 && !isFacingRight) SwapSprite();     
        if(moveInput!= 0 && isGrounded) {
            anim.SetBool("isMoving", true);
        }else {
            anim.SetBool("isMoving", false);
        }
    }

    private void Update() {
        if (isGrounded) {
            extraJumps = maxJumpCount;
            anim.SetBool("isJumping", false);
        }
        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0) {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
            anim.SetBool("isJumping", true);
        }
        else if(Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded == true) {
            rb.velocity = Vector2.up * jumpForce;
            anim.SetBool("isJumping", true);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            int attackCounter = 0;
            attackCounter++;
            Debug.Log("asd  -- " + attackCounter);
        }
    }

    public void SwapSprite() {
        isFacingRight = !isFacingRight;
        if (isFacingRight) this.gameObject.transform.localRotation = Quaternion.Euler(new Vector3(0, 180f, 0));
        else this.gameObject.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }

    public void Attack() {
        
    }
}

