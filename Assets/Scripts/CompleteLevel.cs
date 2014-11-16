using UnityEngine;
using System.Collections;

public class CompleteLevel : MonoBehaviour {
	bool Player0End,Player1End;
	// Use this for initialization
	void Start () {
		Player0End = false;
		Player1End = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.name == "Player0")
		{
			Player0End = true;
		}
		if (collider.gameObject.name == "Player1")
		{
			Player1End = true;
		}
		if (Player0End && Player1End)
		{
			this.EndGame();
		}
	}

	void EndGame() {
		string winplayer = "draw";
		if (GameObject.Find("Player0").GetComponent<PlayerController>().health > GameObject.Find("Player1").GetComponent<PlayerController>().health)
		{
			winplayer = "0";
		}
		else if (GameObject.Find("Player0").GetComponent<PlayerController>().health < GameObject.Find("Player1").GetComponent<PlayerController>().health)
		{
			winplayer = "1";
		}
		string winPlayer = "1";
		PlayerPrefs.SetString ("winner", winPlayer);
		Application.LoadLevel ("EndScreen");
	}
}
