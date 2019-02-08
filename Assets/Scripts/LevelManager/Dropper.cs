using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour {

    public Transform DropPostion;
    public GameObject Prefab;

    float startTimeBetweenDrop = 2f;
    float timeBetweenDrop = 2f;

    private void Update() {
        if (timeBetweenDrop <= 0) {
            timeBetweenDrop = startTimeBetweenDrop;
            Instantiate(Prefab, DropPostion.position, Quaternion.identity);
        }
        else {
            timeBetweenDrop -= Time.deltaTime;
        }
    }
}
