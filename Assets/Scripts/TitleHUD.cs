using UnityEngine;
using System.Collections;

public class TitleHUD : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnGUI() {
		GUIStyle titleStyle = new GUIStyle("label");
		titleStyle.fontSize = 40;
		titleStyle.normal.textColor = Color.black;
		GUI.Label (new Rect ((Screen.width / 2 - 150.0f), (Screen.height / 2 - 100.0f), 400.0f, 60.0f), "Spring Fighters", titleStyle);
		if (GUI.Button(new Rect((Screen.width/2 - 50.0f), (Screen.height/2 + 50.0f), 100, 30), "Play Game")) {
			Application.LoadLevel("Level3");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
