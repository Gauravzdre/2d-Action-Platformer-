using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions {

    public static void Rotate(this Transform transform, float speed) {

        transform.Rotate(speed * Time.deltaTime);
    }
}
