using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour {

    public Transform[] startingPositions;
    public GameObject[] startingRoomPrefabs;

    public float moveAmount;
    float direction;

    private float timeBetweenRooms;
    public float startTimeBtwRooms;

    public float minX;
    public float mixY;
    public float maxX;

    bool stopGeneration;

    private void Start() {
        int rand = Random.Range(0, startingPositions.Length);
        transform.position = startingPositions[rand].position;
        Instantiate(startingRoomPrefabs[0], transform.position, Quaternion.identity);

        direction = Random.Range(1, 6);
    }

    private void Update() {

        if (timeBetweenRooms <= 0 && !stopGeneration) {
            Move();
            timeBetweenRooms = startTimeBtwRooms;
        }
        else timeBetweenRooms -= Time.deltaTime;
    }

    public void Move() {
        if(direction == 1 || direction == 2) { //Right
            if (transform.position.x < maxX) {
                Vector2 newPosition = new Vector2(transform.position.x + moveAmount, transform.position.y);
                transform.position = newPosition;

                direction = Random.Range(1, 6);

                if (direction == 3) direction = 1;
                else if (direction == 4) direction = 5;
            }
            else direction = 5;
        }
        else if(direction == 3 || direction == 4) { //Left
            if (transform.position.x > minX) {
                Vector2 newPosition = new Vector2(transform.position.x - moveAmount, transform.position.y);
                transform.position = newPosition;

                direction = Random.Range(3, 6);
            }
            else direction = 5;
        }
        else if(direction == 5) { //down
            if (transform.position.y > mixY) {
                Vector2 newPosition = new Vector2(transform.position.x, transform.position.y - moveAmount);
                transform.position = newPosition;

                direction = Random.Range(1, 6);
            }
            else stopGeneration = true;
        }

        Instantiate(startingRoomPrefabs[0], transform.position, Quaternion.identity);
    }
}
