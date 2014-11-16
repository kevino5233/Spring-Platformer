using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public int playerNumber;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void SetPlayerId (int playerNo)
	{
		this.playerNumber = playerNumber;
	}

	void OnTriggerEnter(Collider collider)
	{
		Debug.Log(collider.gameObject.name);
		if (collider.gameObject.tag == "Enemy")
		{
			if (this.playerNumber == 0)
			{
				GameObject.Find("Player0").GetComponent<Player>().SendMessage("UpdateScore", 1.0f);
			}
			else
			{
				GameObject.Find("Player1").GetComponent<Player>().SendMessage("UpdateScore", 1.0f);
			}
			Destroy(this.gameObject);
			collider.gameObject.GetComponent<GoatStabilizer>().Freeze();
		}
	}
}
