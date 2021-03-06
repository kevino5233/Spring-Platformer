﻿using UnityEngine;
using System.Collections;

public class LevelEndHUD : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}

	void OnGUI () {
		string winner = PlayerPrefs.GetString ("winner");
		string winText = "ITS A DRAW";
		if (PlayerPrefs.GetString("winner") == "0")
		{
			winText = "PLAYER 1 WINS";
		}
		else if (PlayerPrefs.GetString("winner") == "1")
		{
			winText = "PLAYER 2 WINS";
		}
		
		GUIStyle winStyle = new GUIStyle("label");
		winStyle.fontSize = 40;
		winStyle.normal.textColor = Color.black;
		GUI.Label (new Rect ((Screen.width / 2 - 150.0f), (Screen.height / 2 - 80.0f), 400.0f, 60.0f), winText, winStyle);
		if (GUI.Button(new Rect((Screen.width/2 - 50.0f), (Screen.height/2 + 50.0f), 100, 30), "Play Again")) {
			Application.LoadLevel("Level3");
		}
		if (GUI.Button(new Rect((Screen.width/2 - 50.0f), (Screen.height/2 + 100.0f), 100, 30), "Next Level")) {
			Application.LoadLevel("Level3");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
