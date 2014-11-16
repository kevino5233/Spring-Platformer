using UnityEngine;
using System;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public int PlayerNumber;
	public int health;

	public bool pushOn;
	public bool pullOn;
	public float pushOnTime;
	public float pullOnTime;

	void Start()
	{
		pushOn = false;
		pullOn = false;
		pushOnTime = 0;
		pullOnTime = 0;
	}
	
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

	public bool PushButton
	{
		get
		{
			bool down = Input.GetButton(string.Format("Push[{0}]", this.PlayerNumber));
			if (down)
			{
				if (!pushOn)
				{
					pushOn = true;
					pushOnTime = Time.time;
					return true;
				}
				else if ((Time.time - pushOnTime < 2))
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			if (Input.GetButtonUp(string.Format("Push[{0}]", this.PlayerNumber)))
			{
				pushOn = false;
				pushOnTime = 0;
			}
			return false;
		}
	}

	public bool PullButton
	{
		get
		{
			return Input.GetButton(string.Format("Pull[{0}]", this.PlayerNumber));
		}
	}
	
	public void TakeDamage(int damage){
		if (health > 0)
		{
			health -= damage;
		}
		if (health <= 0)
		{
			GameObject.Find ("Camera").GetComponent<FollowPlayers> ().CalculateScoreAndEndLevel ("lose");
		}
	}
}