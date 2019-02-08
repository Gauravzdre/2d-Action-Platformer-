using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catcher : MonoBehaviour {

    public GameObject particleEffect;

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.transform.tag == "DropSaw") {
            StartCoroutine(PlayParticleEffect(collision.transform.position));
            Destroy(collision.transform.gameObject);
        }   
    }

    public IEnumerator PlayParticleEffect(Vector2 pos) {
        var go = Instantiate(particleEffect, pos, Quaternion.identity);
        yield return new WaitForSeconds(0.8f);
        Destroy(go);
    }
}
