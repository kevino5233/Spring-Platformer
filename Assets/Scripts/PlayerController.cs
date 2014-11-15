﻿using UnityEngine;
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
	
	public bool Jump
	{
		get
		{
			return Input.GetButtonDown(string.Format ("Jump[{0}]", this.PlayerNumber));
		}
	}
	
	public void takeDamage(){
		health -= 1;
		Debug.Log(PlayerNumber + ": " + health);
	}
}