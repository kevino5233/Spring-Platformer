﻿using UnityEngine;
using System.Collections;

public class MainScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void EndGame() {
		string winPlayer = "1";
		PlayerPrefs.SetString ("winner", winPlayer);
		Application.LoadLevel ("EndScreen");
	}
}
