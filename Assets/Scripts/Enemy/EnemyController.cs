using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour, Damageble {

    [SerializeField] private Slider m_HealthSlider;

    [Header("Stats")][Space]

    [SerializeField] private float m_Damage = 20f;
    [SerializeField] private float m_MoveSpeed = 5f;
    [SerializeField] private float m_StartHealth = 30f;
    [SerializeField] private float m_Defense = 50f;
    [SerializeField] private float m_AttackPause = 1f;

    private EnemyManager m_EnemyManager;
    private TankStats m_TankStats;

    private float m_CurrentHealth;
    private float m_NextAttack = 0f;

    // Use this for initialization
    void Start () {

        m_TankStats = TankController.Instanse.GetComponent<TankStats>();
        m_EnemyManager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();

        m_CurrentHealth = m_HealthSlider.maxValue = m_StartHealth;

    }
	
	// Update is called once per frame
	void Update () {

        if (TankController.Instanse) {

            // Mooving enemy to player
            Vector3 destination = new Vector3(TankController.Instanse.transform.position.x , transform.position.y, TankController.Instanse.transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, destination, m_MoveSpeed * Time.deltaTime); 
        }

	}

    private void OnTriggerStay(Collider other) {

        
        if (other.CompareTag("Player")) {

            if (Time.time > m_NextAttack) {

                m_NextAttack = Time.time + m_AttackPause;

                // Damaging player
                if (m_TankStats) {
                    m_TankStats.TakeDamage(m_Damage);
                } 

            }

        }

    }

    public void TakeDamage(float amount) {

        // Calculate damage
        m_CurrentHealth -= amount * (100 / (100 + m_Defense));

        // Set health UI
        m_HealthSlider.value = m_CurrentHealth;

        // Check is dead
        if (m_CurrentHealth <= 0f) {

            Death();

        }

    }

    private void Death() {

        // Delete from array of enemy
        if (m_EnemyManager) {
            m_EnemyManager.DeleteEnemy(this); 
        }

        // Adding score
        GameManager.Instance.AddScore(100);

        Destroy(gameObject);

    }

}
