using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalGenerator : MonoBehaviour {
    public GameObject WallPrefab;

    float m_deltaTime = 15.0f;

	// Use this for initialization
	void Start () {
        GenWall();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void GenWall() {
        GameObject t_wall =  Instantiate(WallPrefab);
        t_wall.transform.position = new Vector3(0.0f, 0.8f, 35.0f);
        Invoke("GenWall", m_deltaTime);
    }
}
