using UnityEngine;

public class EnemyPatrol : MonoBehaviour {

    public float speed;
    public Transform groundCheckTransform;
    bool isMoving;
    bool isMovingRight;

    public Transform righTransform;
    public Transform leftTransform;
    Animator anim;
    EnemyAttack attack;

    GameObject player;
    float timeToAttack = 1;
    public float timeBetweenAttack = 1;

    private void Start() {
        anim = GetComponent<Animator>();
        isMoving = true;
        attack = GetComponent<EnemyAttack>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update() {
        if (isMoving) {
            anim.SetBool("isWalking", true);
            transform.Translate(Vector2.right * speed * Time.deltaTime);

            RaycastHit2D ray = Physics2D.Raycast(groundCheckTransform.position, Vector2.down, 0.3f);
            Debug.DrawRay(groundCheckTransform.position, Vector3.down, Color.green);
            if (ray.collider == false) {
                if (isMovingRight) {
                    SwapSpriteLeft(true);
                    isMovingRight = false;
                }
                else {
                    SwapSpriteLeft(false);
                    isMovingRight = true;
                }
            }
        }

        float dist = Vector2.Distance(player.transform.position, this.transform.position);
        if (dist < 0.5f) {
            if (timeBetweenAttack <= 0) {
                anim.SetBool("isAttacking", true);
                isMoving = false;
                timeToAttack += timeBetweenAttack;
                attack.Attack();
                timeBetweenAttack = timeToAttack;
            }
            else {
                timeBetweenAttack -= Time.deltaTime;
            }
        }
        else {
            isMoving = true;
            anim.SetBool("isAttacking", false);
        }
    }

    public void SwapSpriteLeft(bool isRightFacing) {
        if (isRightFacing) transform.eulerAngles = new Vector2(0, -180);
        else transform.eulerAngles = new Vector2(0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            isMoving = false;
        }
        else isMoving = true;
    }
}
