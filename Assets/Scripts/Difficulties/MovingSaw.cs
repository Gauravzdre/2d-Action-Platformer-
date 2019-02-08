using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSaw : MonoBehaviour {

    public float speed;
    public Transform groundCheckTransform;
    bool isMoving;
    bool isMovingRight;

    void Start() {
        isMoving = true;
    }

	void Update () {
        if (isMoving) {
            transform.Translate(Vector2.right * speed * Time.deltaTime * (isMovingRight ? 1 : -1));

            RaycastHit2D ray = Physics2D.Raycast(groundCheckTransform.position, Vector2.down, 0.3f);
            Debug.DrawRay(groundCheckTransform.position, Vector3.down, Color.green);
            if (ray.collider == false) {
                if (isMovingRight) {
                    SwapSpriteLeft(true);
                    isMovingRight = false;
                }   
                else {
                    SwapSpriteLeft(false);
                    isMovingRight = true;
                }
            }
        }
    }

    public void SwapSpriteLeft(bool isRightFacing) {
        if (isRightFacing) transform.eulerAngles = new Vector2(0, -180);
        else transform.eulerAngles = new Vector2(0, 0);
    }
}
