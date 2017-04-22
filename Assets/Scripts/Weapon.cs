using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour {

    [SerializeField] protected GameObject m_SpawnObject;
    [SerializeField] protected float m_Damage;
    [SerializeField] protected float m_FireDelay;
    [SerializeField] protected string type;

    public string Type {
        get {
            return type;
        }
    }

    [NonSerialized]
    private float m_NextFire;

   
    // Creating new ammo(mine, shell etc.) 
    public virtual void Fire() { 

        if (Time.time > m_NextFire) {

            m_NextFire = Time.time + m_FireDelay;

            // Call overriden method and spawn certain ammo
            Spawn();

        }

    }

    protected abstract void Spawn();

}
