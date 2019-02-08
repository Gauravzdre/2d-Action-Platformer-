using UnityEngine;
using System;

public class EnemyHealth : MonoBehaviour {

    public float TotalHealth;
    Action<bool> isDead;    

    private void Start() {
        isDead += death;
    }

    public void death(bool isDead) {
        if (isDead)
            Destroy(this.gameObject);
    }

    public void TakeDemage(float demage) {
        TotalHealth -= demage;
        Debug.Log(TotalHealth);
        if (TotalHealth <= 0)
            isDead(true);
        else isDead(false);
    }
}
