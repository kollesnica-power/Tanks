using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankStats : MonoBehaviour, Damageble {

    [SerializeField] private float m_StartHealth = 100f;
    [SerializeField] private float m_Defense = 100f;
    [SerializeField] private Slider m_HealthSlider;

    private float m_CurrentHealth;



    void OnEnable() {

        // Setting up health
        m_CurrentHealth = m_StartHealth;
        SetHealthUI();

        // Return tank to start point
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;

    }

    public void TakeDamage (float amount) {

        // Calculate damage
        m_CurrentHealth -= amount * (100 / (100 + m_Defense));

        SetHealthUI();

        // Check is dead
        if (m_CurrentHealth <= 0f) {

            gameObject.SetActive(false);
            GameManager.Instance.GameOver();

        }

    }

    private void SetHealthUI() {

        // Set health UI
        m_HealthSlider.value = m_CurrentHealth;

    }

}
