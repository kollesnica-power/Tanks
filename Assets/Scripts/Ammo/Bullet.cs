using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Ammo {

    [SerializeField] private float m_Range;

    private Vector3 m_StartPosition; 

	// Use this for initialization
	void Start () {

        m_StartPosition = transform.position;


    }
	
	// Update is called once per frame
	void Update () {

        // Limit range of the bullet
        if (Vector3.Distance(m_StartPosition, transform.position) > m_Range) {

            Destroy(gameObject);

        }

	}

    private void OnTriggerEnter(Collider other) {

        if (other.CompareTag("Enemy")) {

            DoDamage(other.gameObject.GetComponent<EnemyController>());

        }

    }

    // Doing damage and destroy bullet
    private void DoDamage(EnemyController enemyController) {

        if (enemyController) {

            enemyController.TakeDamage(Damage);

            Destroy(gameObject);

        }

    }
}
