using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;
    public float dampTime = 0.15f;
    private Vector3 velocity;

    private void Update() {
        if (target == null) return;

        var camera = this.GetComponent<Camera>();
        Vector3 point = camera.WorldToViewportPoint(target.position);
        Vector3 delta = target.position - camera.WorldToViewportPoint(new Vector3(0.5f,0.5f,point.z));
        Vector3 destination = transform.position + delta;
        transform.position = Vector3.SmoothDamp(this.transform.position, target.position, ref velocity, dampTime);
    }
}
