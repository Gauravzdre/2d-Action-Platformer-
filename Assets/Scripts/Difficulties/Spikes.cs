using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {

    public float spikeDemage;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            Health.Instance.TakeDemage(spikeDemage);
            //  Debug.Log("asd");
        }
    }
}
