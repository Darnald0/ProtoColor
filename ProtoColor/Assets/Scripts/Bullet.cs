using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [HideInInspector] public bool isLeft;
    public float bulletSpeed = 2.0f;
    public PlayerController.state bulletState;

    private SpriteRenderer spriteRenderer;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        switch (bulletState)
        {
            case PlayerController.state.water:
                spriteRenderer.color = Color.blue;
                break;
            case PlayerController.state.wind:
                spriteRenderer.color = Color.green;
                break;
            case PlayerController.state.fire:
                spriteRenderer.color = Color.red;
                break;
            default:
                Debug.Log("No State");
                break;
        }
    }

    void Update()
    {
        if (isLeft)
        {
            transform.Translate(Vector2.left * Time.deltaTime * bulletSpeed);
        }
        else
        {
            transform.Translate(Vector2.right * Time.deltaTime * bulletSpeed);
        }
    }
}
