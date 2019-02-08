using System;   
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    private static Health instance;

    public static Health Instance {
        get {
            instance = GameObject.FindObjectOfType<Health>();
            return instance;
        }
    }

    public static event Action onDeath;

    [SerializeField] float maxHealth = 70f;
    Action<bool> isDead;

    public Text text;

    private void Start() {
        isDead += OnDeath;
    }

    public void OnDeath(bool isDead) {
        if (isDead)
            onDeath.Invoke();
    }

    public void TakeDemage(float demage) {
        maxHealth -= demage;
        Debug.Log(maxHealth);
        text.text = "Health: " + maxHealth.ToString();
        if (maxHealth <= 0) isDead(true);
        else isDead(false);
    }
}
