using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinePlanter : Weapon {

    protected override void Spawn() {

        Transform spawnTransform = GameObject.Find("Player").transform;

        if (spawnTransform) {

            Vector3 spawnPoint = new Vector3(spawnTransform.position.x, m_SpawnObject.transform.position.y, spawnTransform.position.z);
            Instantiate(m_SpawnObject, spawnPoint, Quaternion.identity); 

        }

    }

}
