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

    public void ChangeScore(int _total, int _check, int _hit) {
        Score_Text.text = "" + _total + " " + _check + " " + _hit;
    }
}
