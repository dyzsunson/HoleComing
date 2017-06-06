using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {
    float m_speed = 2.0f;
    float m_destroy_z = -20.0f;
    float m_check_z = -0.5f;

    bool m_isChecked = false;
    int m_total_checkPoint;
    int m_checked_num = 0;

	// Use this for initialization
	void Start () {
        m_total_checkPoint = this.GetComponentsInChildren<WallCheckPoint>().Length;
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(Time.deltaTime * m_speed * new Vector3(0.0f, 0.0f, -1.0f));

        if (this.transform.position.z < m_destroy_z)
            Destroy(this.gameObject);

        if (m_isChecked == false && this.transform.position.z < m_check_z) {
            SceneController.context.ChangeScore(100 * m_checked_num / m_total_checkPoint);
            m_isChecked = true;
        }
	}

    public void OnePointChecked(WallCheckPoint checkPoint) {
        print("check" + checkPoint.name);
        m_checked_num++;
    }
}
