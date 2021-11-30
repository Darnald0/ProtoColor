using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum state { water, wind, fire};

    public float speed = 3.4f;
    public float jumpHeight = 6.5f;

    [SerializeField] private state currentState;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform shootingPos;

    private bool facingRight = true;
    private float moveDirection = 0;
    private Rigidbody2D rb2D;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        facingRight = transform.localScale.x > 0;

    }

    void Update()
    {
        if ((Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.D)))
        {
            moveDirection = Input.GetKey(KeyCode.Q) ? -1 : 1;
        }
        else
        {
            moveDirection = 0;  
        }

        if (moveDirection != 0)
        {
            if (moveDirection > 0 && !facingRight)
            {
                facingRight = true;
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            if (moveDirection < 0 && facingRight)
            {
                facingRight = false;
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpHeight);
        }

        if (mainCamera)
        {
            mainCamera.transform.position = new Vector3(transform.position.x, mainCamera.transform.position.y, mainCamera.transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            bullet = Instantiate(bullet, shootingPos.position, Quaternion.identity);
            Bullet bulletComp = bullet.GetComponent<Bullet>();
            bulletComp.bulletState = currentState;
            if (!facingRight)
            {
                bulletComp.isLeft = true;
            } else
            {
                bulletComp.isLeft = false;
            }
        }
    }

    void FixedUpdate()
    {
        rb2D.velocity = new Vector2((moveDirection) * speed, rb2D.velocity.y);
    }
}
