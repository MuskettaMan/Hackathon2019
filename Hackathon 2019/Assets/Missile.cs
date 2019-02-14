using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour {

    public static float damage = 50f;

    private float force = 500;
    private Rigidbody2D rb2d;


    [SerializeField] private GameObject explosion;
    private Transform bazooka;

    private void Awake() {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Start() {
        bazooka = GameObject.FindGameObjectWithTag("Bazooka").transform;

        transform.rotation = bazooka.transform.rotation;

        rb2d.AddForce(bazooka.transform.right * force);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag != "Explosion") {
            Destroy(gameObject);
        }
        
    }

    private void OnDestroy() {
        Instantiate(explosion, transform.position, Quaternion.identity);
    }

}
