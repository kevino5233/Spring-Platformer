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
<<<<<<< HEAD
		Debug.Log(collider.gameObject.name);
		if (collider.gameObject.tag == "Enemy")
=======
		if (collider.gameObject.tag == "Wall")
		{
			Destroy(this.gameObject);
		}
		else if (collider.gameObject.tag == "WallMov")
		{
			collider.gameObject.GetComponent<MovableWall>().SendMessage("Pause");
			Destroy(this.gameObject);
		}
		else if (collider.gameObject.tag == "Enemy")
>>>>>>> 839f60bc4e1933072e6acaeae98c7ef8678740b1
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
