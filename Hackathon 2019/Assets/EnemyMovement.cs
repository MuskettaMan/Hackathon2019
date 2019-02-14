using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    float speed;

    private Rigidbody2D rb2d;

    private void Awake() {
        rb2d = GetComponent<Rigidbody2D>();

        speed = Random.Range(30, 40);
    }

    private void Update() {
        rb2d.velocity = new Vector2(speed, rb2d.velocity.y) * Time.deltaTime;
    }

}
