using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : Weapon {

    protected override Ammo Spawn() {

        Transform spawnTransform = GameObject.Find("Player").transform.FindChild("FireTransform");

        if (spawnTransform) {

            GameObject bulletInstance = Instantiate(m_SpawnObject, spawnTransform.position, spawnTransform.rotation);

            Rigidbody bulletRigidbody = bulletInstance.GetComponent<Rigidbody>();

            // Adding velocity to shell i.e launch him
            if (bulletRigidbody) {
                bulletRigidbody.velocity = m_Speed * spawnTransform.forward;
            }

            return bulletInstance.GetComponent<Ammo>();

        }

        return null;

    }

}
