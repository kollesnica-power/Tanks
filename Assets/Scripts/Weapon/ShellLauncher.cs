using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellLauncher : Weapon {

    protected override Ammo Spawn() {

        Transform spawnTransform = GameObject.Find("Player").transform.FindChild("FireTransform");

        if (spawnTransform) {

            GameObject shellInstance = Instantiate(m_SpawnObject, spawnTransform.position, spawnTransform.rotation);

            Rigidbody shellRigidbody = shellInstance.GetComponent<Rigidbody>();

            // Adding velocity to shell i.e launch him
            if (shellRigidbody) {
                shellRigidbody.velocity = m_Speed * spawnTransform.forward;
            }

            return shellInstance.GetComponent<Ammo>();

        }

        return null;

    }

}
