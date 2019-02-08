using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saw : MonoBehaviour {

    [SerializeField] float sawDemage = 35f;

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Player") {
            Health.Instance.TakeDemage(sawDemage);
        }   
    }   
}
