using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCheckPoint : MonoBehaviour {
    bool m_isChecked = false;
    Wall m_wall;

	// Use this for initialization
	void Start () {
        m_wall = this.transform.parent.GetComponent<Wall>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other) {
        if (m_isChecked == false && other.gameObject.layer == LayerMask.NameToLayer("Player")) {
            m_isChecked = true;
            m_wall.OnePointChecked(this);
        }
    }
}
