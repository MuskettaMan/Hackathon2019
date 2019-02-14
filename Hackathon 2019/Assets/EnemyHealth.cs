using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    private float health;
    private SpriteRenderer spriteRenderer;

    [SerializeField] private Color damageColor;
    private Color defaultColor;

    private void Awake() {
        health = Random.Range(200, 300);
        spriteRenderer = GetComponent<SpriteRenderer>();

        defaultColor = spriteRenderer.color;
    }

    private void Update() {
        if(health <= 0) {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Explosion") {
            StartCoroutine(TakeDamage());
            
        }
    }

    IEnumerator TakeDamage() {
        health -= Missile.damage;
        spriteRenderer.color = damageColor;
        yield return new WaitForSeconds(.1f);
        spriteRenderer.color = defaultColor;
        yield return new WaitForSeconds(.1f);
        spriteRenderer.color = damageColor;
        yield return new WaitForSeconds(.1f);
        spriteRenderer.color = defaultColor;
        yield return new WaitForSeconds(.1f);
        spriteRenderer.color = damageColor;
        yield return new WaitForSeconds(.1f);
        spriteRenderer.color = defaultColor;
    }

}
