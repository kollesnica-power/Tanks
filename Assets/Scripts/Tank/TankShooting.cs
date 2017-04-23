using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankShooting : MonoBehaviour {

    [SerializeField] private List<Weapon> m_Weapons;
    [SerializeField] private Text m_WeaponTypeText;

    private int m_CurrentWeapon = 0;
   

	
	// Update is called once per frame
	void FixedUpdate () {

        if (Input.GetKey(KeyCode.X)) {

            // Firing
            m_Weapons[m_CurrentWeapon].Fire();

        } else if (Input.GetKeyDown(KeyCode.Q)) {

            // Move down weapon
            ChangeWeapon(-1);

        } else if (Input.GetKeyDown(KeyCode.W)) {

            // Move up weapon
            ChangeWeapon(1);

        }

    }

    private void ChangeWeapon(int direction) {

        m_CurrentWeapon += direction;

        // Cicling weapon
        if (m_CurrentWeapon >= m_Weapons.Count) {

            m_CurrentWeapon = 0;

        } else if (m_CurrentWeapon < 0) {

            m_CurrentWeapon = m_Weapons.Count - 1;

        }

        // Set GUI text
        m_WeaponTypeText.text = "Weapon : " + m_Weapons[m_CurrentWeapon].Type;

    }

}
