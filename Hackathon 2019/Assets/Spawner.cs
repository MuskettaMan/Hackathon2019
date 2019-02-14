using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    [SerializeField] private GameObject enemyPrefab;

    private float timer = 0;
    private float spawnThreshold = 3;

    private void Update() {
        timer += Time.deltaTime;

        spawnThreshold -= Time.deltaTime / 100;

        spawnThreshold = (spawnThreshold < 1.5f) ? 1.5f : spawnThreshold;

        Debug.Log(spawnThreshold);

        if(timer > spawnThreshold) {
            var clone = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            timer = 0;
        }
    }

}
