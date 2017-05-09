using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {
    float m_speed = 2.0f;
    float m_destroy_z = -20.0f;
	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(Time.deltaTime * m_speed * new Vector3(0.0f, 0.0f, -1.0f));

        if (this.transform.position.z < m_destroy_z)
            Destroy(this.gameObject);

        if (this.transform.position.z < 0.0f) {
            this.renderer.
        }
	}
}
