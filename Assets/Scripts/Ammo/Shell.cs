using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : Ammo {

    [SerializeField] private ParticleSystem m_ExplosionParticles;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other) {

        if (other.CompareTag("Enemy")) {

            Explose(other.gameObject.GetComponent<EnemyController>());

        }

    }

    private void Explose(EnemyController enemy) {

        if (enemy) {

            // Doing damage
            enemy.TakeDamage(Damage);

        }

        // Playe particles and destroy
        m_ExplosionParticles.transform.parent = null;

        m_ExplosionParticles.Play();

        Destroy(m_ExplosionParticles.gameObject, m_ExplosionParticles.main.duration);

        Destroy(gameObject);

    }

    void OnBecameInvisible() {
        Destroy(gameObject);
    }

}
