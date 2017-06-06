using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneController : MonoBehaviour {
    public static SceneController context;
    public Text Score_Text;

    private void Awake() {
        context = this;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeScore(int score) {
        Score_Text.text = score.ToString();
    }
}
