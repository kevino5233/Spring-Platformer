﻿using UnityEngine;
using System.Collections;
using Jolly;

public class Player : MonoBehaviour
{
	public float MovementForce;
	public float MaxSpeed;
	public float JumpForce;

	public GameObject GroundContactDelta;

	private PlayerController PlayerController;

	public bool IsOnGround { get; private set; }

	public Color HUDColor;

	public int Score { get; private set; }
	
	public int health{
		get
		{
			return this.PlayerController.health;
		}
	}
	
	public Player ()
	{
		this.Score = 0;
	}

	void Start ()
	{
		this.PlayerController = this.GetComponent<PlayerController>();

		JollyDebug.Watch (this, "IsOnGround", delegate ()
		{
			return this.IsOnGround;
		});
	}

	void Update ()
	{
		this.IsOnGround = true;
		float h = this.PlayerController.ShootHorizontalAxis;
		float v = this.PlayerController.ShootVerticalAxis;
//		Debug.Log (h);
//		Debug.Log (v);
		if (h!=0.0 || v!=0.0)
		{
			Debug.Log (h);
			Debug.Log (v);
		}
	}

	void FixedUpdate ()
	{
		float h = this.PlayerController.HorizontalMovementAxis;
		float v = this.PlayerController.VerticalMovementAxis;

		this.rigidbody.AddForce (new Vector3(h * this.MovementForce, 0.0f, v * this.MovementForce));

		float maxSpeedX = Mathf.Abs (this.MaxSpeed * h);
		if (Mathf.Abs(this.rigidbody.velocity.x) > maxSpeedX)
		{
			this.rigidbody.velocity = new Vector3(Mathf.Sign (this.rigidbody.velocity.x) * maxSpeedX, this.rigidbody.velocity.y, this.rigidbody.velocity.z);
		}

		float maxSpeedZ = Mathf.Abs (this.MaxSpeed * v);
		if (Mathf.Abs(this.rigidbody.velocity.z) > maxSpeedZ)
		{
			this.rigidbody.velocity = new Vector3(this.rigidbody.velocity.x, this.rigidbody.velocity.y, Mathf.Sign (this.rigidbody.velocity.z) * maxSpeedZ);
    	}
	}
}
