using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    Animator anim;
    public float demage;

    public void Start() {
        anim = GetComponent<Animator>();
    }

    public void Attack() {  
        Health.Instance.TakeDemage(demage);
    }
}
