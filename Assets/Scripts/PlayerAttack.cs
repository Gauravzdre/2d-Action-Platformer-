using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    float timeBetweenAttack;
    public float startTimBetweenAttack;

    public Transform attackPos;
    public float attackRadius;
    public LayerMask whatIsEnemy;
    public float attackDemage;

    public Animator anim;

    private void Start() {
        anim = GetComponent<Animator>();
    }

    private void Update() {
        if (timeBetweenAttack <= 0) {
            if (Input.GetKey(KeyCode.E)) {
                Attack();
            }
            timeBetweenAttack = startTimBetweenAttack;
        }else {
            anim.SetBool("isAttacking", false);
            timeBetweenAttack -= Time.deltaTime;    
        }
    }

    private void Attack() {
        anim.SetBool("isAttacking", true);
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPos.position, attackRadius, whatIsEnemy);
        foreach(var enemy in enemies) {
            DealDemage(enemy, attackDemage);
        }
    }

    private void DealDemage(Collider2D enemy, float demage) {
        var health = enemy.gameObject.GetComponent<EnemyHealth>();
        health.TakeDemage(demage);
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRadius);
    }
}
