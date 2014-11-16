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
		GameObject.Find ("Camera").GetComponent<FollowPlayers> ().CalculateScoreAndEndLevel ("win");
	}
}
