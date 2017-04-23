using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineBlinking : MonoBehaviour {

    [SerializeField] private float m_Duration = 2f;
    [SerializeField] private Color m_StartColor;
    [SerializeField] private Color m_EndColor;


	
	// Update is called once per frame
	void Update () {

        float lerp = Mathf.PingPong(Time.time, m_Duration) / m_Duration;

        // Interpolate color from startColor to endColor and back
        GetComponent<Renderer>().material.color = Color.Lerp(m_StartColor, m_EndColor, lerp);

	}
}
