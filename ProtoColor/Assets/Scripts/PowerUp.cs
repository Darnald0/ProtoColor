using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {
    private Colored col;
    void Start() {
        col = GetComponent<Colored>();
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.transform.GetComponent<Colored>()) {
            Colored.ChangeState(collision.transform.GetComponent<Colored>(), col.State);
        }
        Debug.Log("dosrijgiozsrj");
    }
}
