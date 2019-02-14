using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Defeat : MonoBehaviour {

    [SerializeField] private TextMeshProUGUI defeatText;

    private float maxFontSize = 80;
    private float fontIncrease = 0.2f;

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Enemy") {
            if(!defeatText.gameObject.activeSelf) {
                defeatText.gameObject.SetActive(true);
            }
        }
    }

    private void Update() {
        if(defeatText.gameObject.activeSelf) {
            if(defeatText.fontSize <= maxFontSize) {
                defeatText.fontSize += fontIncrease;
            } else {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

}
