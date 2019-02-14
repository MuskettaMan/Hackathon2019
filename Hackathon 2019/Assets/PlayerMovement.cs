using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody2D rb2d;

    private void Awake() {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        var move = new Vector2(Input.GetAxis("Horizontal"), rb2d.velocity.y);

        rb2d.velocity = move;
    }

}
