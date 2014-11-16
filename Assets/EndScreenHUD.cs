using UnityEngine;
using System.Collections;

public class EndScreenHUD : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}

	void OnGUI () {
		string winner = PlayerPrefs.GetString ("winner");
		winner = "1";
		GUI.Label (new Rect ((Screen.width / 2 - 50.0f), (Screen.height / 2 - 100.0f), 100.0f, 60.0f), "Player "+winner+" Wins");
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
