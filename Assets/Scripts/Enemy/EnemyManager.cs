using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    [SerializeField] private List<EnemyController> m_EnemyPrefabs;
    [SerializeField] private float m_SpawnDelay = 3f;

    private List<EnemyController> m_Enemies;
    private float m_NextSpawn = 0f;
    

    // Use this for initialization
    void Start () {

        m_Enemies = new List<EnemyController>();

    }
	
	// Update is called once per frame
	void Update () {

        // If player alive
        if (TankController.Instanse.gameObject.activeSelf) {

            // If enemies less then 10 we spawn new one
            if (m_Enemies.Count < 10 && Time.time > m_NextSpawn) {

                m_NextSpawn = Time.time + m_SpawnDelay;
                SpawnEnemy();

            }

        } else {

            // If player is dead clear all enemies
            ClearAllEnemies();

        }

	}

    private void SpawnEnemy() {

        // Get random positon in circle with 40 radius
        Vector3 spawnPosition = Quaternion.AngleAxis(Random.Range(0f, 360f), Vector3.up) * Vector3.forward * 40f;

        // Get random type of enemy
        int selection = Random.Range(0, m_EnemyPrefabs.Count);

        spawnPosition.y = m_EnemyPrefabs[selection].gameObject.transform.position.y;

        m_Enemies.Add(Instantiate(m_EnemyPrefabs[selection], spawnPosition, Quaternion.identity) as EnemyController);

    }

    public void DeleteEnemy(EnemyController enemy) {

        m_Enemies.Remove(enemy);

    }

    private void ClearAllEnemies() {

        foreach (var item in m_Enemies) {

            if (item) {
                Destroy(item.gameObject); 
            }

        }

    }

}
