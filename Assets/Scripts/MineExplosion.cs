﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineExplosion : MonoBehaviour {

    [SerializeField] private ParticleSystem m_ExplosionParticles;
    [SerializeField] private LayerMask m_EnemyMask;
    [SerializeField] private float m_ExplosionRadius = 5f;
    [SerializeField] private float m_ExplosionDamage = 20f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other) {

        if (other.CompareTag("Enemy")) {
            
            // Get objects in raduis of explosion
            Collider[] colliders = Physics.OverlapSphere(transform.position, m_ExplosionRadius, m_EnemyMask);

            // Go through them and damage
            foreach (var item in colliders) {

                EnemyController enemy = item.GetComponent<EnemyController>();

                if (enemy) {

                    enemy.TakeDamage(m_ExplosionDamage);

                }

            }

            // Playe particles and destroy
            m_ExplosionParticles.transform.parent = null;

            m_ExplosionParticles.Play();

            Destroy(m_ExplosionParticles.gameObject, m_ExplosionParticles.main.duration);

            Destroy(gameObject);



        }

    }

}