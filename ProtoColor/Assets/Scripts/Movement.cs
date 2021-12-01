using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    public bool canMove = true;
    public float speed = 3f;
    [SerializeField] private Transform firstPoint;
    [SerializeField] private Transform secondPoint;
    [SerializeField] private bool intoFirstPoint;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (canMove) {
            if (intoFirstPoint) {
                if (transform.position.x < firstPoint.position.x - 0.1f) {
                    transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
                } else if (transform.position.x > firstPoint.position.x + 0.1f) {
                    transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
                } else {
                    intoFirstPoint = false;
                }
            } else {
                if (transform.position.x < secondPoint.position.x - 0.1f) {
                    transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
                } else if (transform.position.x > secondPoint.position.x + 0.1f) {
                    transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
                } else {
                    intoFirstPoint = true;
                }
            }
        }
    }
}
