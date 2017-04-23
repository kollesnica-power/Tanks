using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour {

    [SerializeField] protected GameObject m_SpawnObject;
    [SerializeField] protected float m_Damage;
    [SerializeField] protected float m_Speed;
    [SerializeField] protected float m_FireDelay;
    [SerializeField] protected string type;

    private Ammo m_Ammo;

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
            m_Ammo = Spawn();

            // Setting damage to ammo
            SetDamage();

        }

    }

    private void SetDamage() {

        if (m_Ammo) {
            m_Ammo.Damage = m_Damage;
        }

    }

    // Here we need to instantiate ammo and return his instance
    protected abstract Ammo Spawn();

}
