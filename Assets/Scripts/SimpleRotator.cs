using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRotator : MonoBehaviour {

    [SerializeField] float Speed;

    private void Update() {
        //transform.localRotation = Quaternion.Euler(new Vector3(0,0,(Speed * Time.deltaTime)));
        transform.Rotate(new Vector3(0, 0, Speed * Time.deltaTime));
    }
}
