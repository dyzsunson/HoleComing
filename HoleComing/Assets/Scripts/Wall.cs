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
    int m_hit_num = 0;
    int[] m_wall_map;

    int m_width = 40;
    int m_height = 30;
    float m_size = 0.05f;

	// Use this for initialization
	void Start () {
        TextAsset mapText = Resources.Load("wall", typeof(TextAsset)) as TextAsset;

        string[] mapStrings = mapText.text.Split(new char[] { ' ', '\t', '\r', '\n' },
            System.StringSplitOptions.RemoveEmptyEntries);

        m_wall_map = new int[mapStrings.Length];

        for (int i = 0; i < mapStrings.Length; i++) {
            m_wall_map[i] = int.Parse(mapStrings[i]);
        }

        m_total_checkPoint = 0;
        for (int i = 0; i < m_height; i++) {
            for (int j = 0; j < m_width; j++) {
                GameObject obj;
                if (m_wall_map[i * m_width + j] == 0)
                    obj = Instantiate(WallCube);
                else {
                    obj = Instantiate(BlankCube);
                    m_total_checkPoint++;
                }
                obj.transform.SetParent(this.transform);
                obj.transform.localScale = m_size * Vector3.one;
                obj.transform.localPosition = new Vector3(m_size * (j - m_width / 2 + 1), m_size * (-i + m_height), 0);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(Time.deltaTime * m_speed * new Vector3(0.0f, 0.0f, -1.0f));

        if (this.transform.position.z < m_destroy_z)
            Destroy(this.gameObject);

        if (m_isChecked == false && this.transform.position.z < m_check_z) {
            SceneController.context.ChangeScore(m_total_checkPoint, m_checked_num, m_hit_num);
            m_isChecked = true;
        }
	}

    public void OnePointChecked(WallCheckPoint _checkPoint) {
        if (_checkPoint.IsGood)
            m_checked_num++;
        else
            m_hit_num++;
    }
}
