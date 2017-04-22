using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour {

    [SerializeField] [Range(1f, 30f)] private float m_Speed;
    [SerializeField] [Range(1f, 100f)] private float m_TurnSpeed;
    [SerializeField] Rigidbody m_Rigidbody;

    private static TankController instanse;

    public static TankController Instanse {
        get {
            return instanse;
        }
    }

    private void Awake() {

        instanse = this;

    }

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void FixedUpdate () {

        Move();
        Turn();

    }

    private void Move() {

        // Get input value
        float vInput = Input.GetAxis("Vertical");

        // Calculate movement
        Vector3 movement = transform.forward * vInput * m_Speed * Time.fixedDeltaTime;

        // Apply movement
        m_Rigidbody.MovePosition(m_Rigidbody.position + movement);

    }

    private void Turn() {

        // Get input value
        float hInput = Input.GetAxis("Horizontal");

        // Calculate rotation
        float turn = hInput * m_TurnSpeed * Time.fixedDeltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);

        // Apply movement
        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * turnRotation);

    }

}
