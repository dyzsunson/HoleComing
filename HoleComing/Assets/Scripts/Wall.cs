using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {
    public GameObject WallCube;
    public GameObject BlankCube;

    float m_speed = 2.0f;
    float m_destroy_z = -20.0f;
    float m_check_z = -0.5f;

    bool m_isChecked = false;
    int m_total_checkPoint;
    int m_checked_num = 0;
    int[] m_wall_map;

	// Use this for initialization
	void Start () {
        TextAsset mapText = Resources.Load("wall", typeof(TextAsset)) as TextAsset;

        string[] mapStrings = mapText.text.Split(new char[] { ' ', '\t', '\r', '\n' },
            System.StringSplitOptions.RemoveEmptyEntries);

        m_wall_map = new int[mapStrings.Length];

        for (int i = 0; i < mapStrings.Length; i++) {
            m_wall_map[i] = int.Parse(mapStrings[i]);
        }


        for (int i = 0; i < 15; i++) {
            for (int j = 0; j < 30; j++) {
                GameObject obj;
                if (m_wall_map[i * 30 + j] == 0)
                    obj = Instantiate(WallCube);
                else
                    obj = Instantiate(BlankCube);
                obj.transform.SetParent(this.transform);
                obj.transform.localPosition = new Vector3(0.1f * (j - 14f), 0.1f * (-i + 7f), 0);
            }
        }

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
