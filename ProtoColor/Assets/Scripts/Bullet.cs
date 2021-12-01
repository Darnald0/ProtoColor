using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    [HideInInspector] public bool isLeft;
    public float bulletSpeed = 2.0f;
    private Colored col;

    void Start() {
        col = GetComponent<Colored>();
        StartCoroutine(RangeLimit());
    }
    void Update() {
        if (isLeft) {
            transform.Translate(Vector2.left * Time.deltaTime * bulletSpeed);
        } else {
            transform.Translate(Vector2.right * Time.deltaTime * bulletSpeed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.transform.GetComponent<Colored>()) {
            Colored.NewState(collision.transform.GetComponent<Colored>(), col.State);
        }
        Destroy(gameObject);
    }

    IEnumerator RangeLimit() {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
