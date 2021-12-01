using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed = 3.4f;
    public float jumpHeight = 6.5f;

    [SerializeField] private Camera mainCamera;
    [SerializeField] private Bullet bullet;
    [SerializeField] private Transform shootingPos;

    private bool facingRight = true;
    private float moveDirection = 0;
    private Rigidbody2D rb2D;
    private Colored col;

    void Start() {
        col = GetComponent<Colored>();
        rb2D = GetComponent<Rigidbody2D>();
        facingRight = transform.localScale.x > 0;

    }

    void Update() {
        if ((Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.D))) {
            moveDirection = Input.GetKey(KeyCode.Q) ? -1 : 1;
        } else {
            moveDirection = 0;
        }

        if (moveDirection != 0) {
            if (moveDirection > 0 && !facingRight) {
                facingRight = true;
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            if (moveDirection < 0 && facingRight) {
                facingRight = false;
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
        }

        if (Input.GetKeyDown(KeyCode.Z)) {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpHeight);
        }

        if (mainCamera) {
            mainCamera.transform.position = new Vector3(transform.position.x, mainCamera.transform.position.y, mainCamera.transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            Bullet bulletComp = Instantiate(bullet, shootingPos.position, Quaternion.identity).GetComponent<Bullet>();
            bulletComp.GetComponent<Colored>().State = col.State;
            if (!facingRight) {
                bulletComp.isLeft = true;
            } else {
                bulletComp.isLeft = false;
            }
        }
    }

    void FixedUpdate() {
        rb2D.velocity = new Vector2((moveDirection) * speed, rb2D.velocity.y);
    }
}
