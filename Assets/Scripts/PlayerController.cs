using UnityEngine;
using System;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public int PlayerNumber;
	
	public int health;
	
	public float HorizontalMovementAxis
	{
		get
		{
			return Input.GetAxis(string.Format ("Horizontal[{0}]", this.PlayerNumber));
		}
	}

	public float VerticalMovementAxis
	{
		get
		{
			return Input.GetAxis (string.Format ("Vertical[{0}]", this.PlayerNumber));
		}
	}
	
//	public bool Jump
//	{
//		get
//		{
//			return Input.GetButtonDown(string.Format ("Jump[{0}]", this.PlayerNumber));
//		}
//	}

	public float ShootHorizontalAxis
	{
		get
		{
			return Input.GetAxis (string.Format ("HorizontalBullet[{0}]", this.PlayerNumber));
		}
	}

	public float ShootVerticalAxis
	{
		get
		{
			return Input.GetAxis (string.Format ("VerticalBullet[{0}]", this.PlayerNumber));
		}
	}
	
	public void TakeDamage(int damage){
		health -= damage;
		if (health <= 0)
		{
			GameObject.Find ("Camera").GetComponent<FollowPlayers> ().CalculateScoreAndEndLevel ("lose");
		}
	}
}