using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bazooka : MonoBehaviour {

    [SerializeField] private GameObject missilePrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject player;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D playerRb2d;

    private Vector3 offset;

    private float timer = 0;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerRb2d = player.GetComponent<Rigidbody2D>();

        offset = new Vector3(0, -0.17f, 0);
    }

    private void Update() {
        transform.position = player.transform.position + offset;
        
        spriteRenderer.flipY = (transform.eulerAngles.z > 90) ? true : false;

        timer += Time.deltaTime;

        Aim();
        Shoot();
    }

    private void Shoot() {
        if(Input.GetMouseButtonDown(0) && timer > 0.5f) {
            Instantiate(missilePrefab, firePoint.position, Quaternion.identity);
            timer = 0;
        }
    }

    private void Aim() {
        var mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        var angle = Mathf.Atan2((mouseScreenPosition.y - transform.position.y), (mouseScreenPosition.x - transform.position.x));

        angle = (180 / Mathf.PI) * angle;

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
