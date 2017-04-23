using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : Ammo {

    [SerializeField] private ParticleSystem m_ExplosionParticles;
    [SerializeField] private LayerMask m_EnemyMask;
    [SerializeField] private float m_ExplosionRadius = 5f;
    [SerializeField] private float m_ExplosionDelay = 1f;
    [SerializeField] private GameObject m_BlinkingPart;

    private float m_StartTime;

	// Use this for initialization
	void Awake () {

        m_StartTime = Time.time;

	}

    private void Update() {

        // Blinking
        if (IsCharged()) {

            float lerp = Mathf.PingPong(Time.time, 2f) / 2f;

            // Interpolate color from startColor to endColor and back
            m_BlinkingPart.GetComponent<Renderer>().material.color = Color.Lerp(Color.black, Color.red, lerp); 

        }

    }

    private void OnTriggerEnter(Collider other) {

        if (IsCharged() && (other.CompareTag("Enemy") || other.CompareTag("Player"))) {

            Explode();

        }

    }

    private void Explode() {

        // Get objects in raduis of explosion
        Collider[] colliders = Physics.OverlapSphere(transform.position, m_ExplosionRadius, m_EnemyMask);

        // Go through them and damage
        foreach (var item in colliders) {

            Damageble enemy = item.gameObject.GetComponent<Damageble>();

            if (enemy != null) {

                enemy.TakeDamage(Damage);

            }

        }

        // Play particles and destroy
        m_ExplosionParticles.transform.parent = null;

        m_ExplosionParticles.Play();

        Destroy(m_ExplosionParticles.gameObject, m_ExplosionParticles.main.duration);

        Destroy(gameObject);

    }

    // Check delay because we can explode ourself instantly
    private bool IsCharged() {

        return Time.time - m_StartTime > m_ExplosionDelay;

    }

}
