﻿using UnityEngine;
using System.Collections;
using Jolly;

public class Player : MonoBehaviour
{
	public float MovementForce;
	public float MaxSpeed;
	public float PullForce;
	public float PushForce;

	public GameObject GroundContactDelta;
	public GameObject BulletPrefab;
	public static float BulletVelocity = 50;

	private PlayerController PlayerController;
	private float fireTime;

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
		this.fireTime = Time.deltaTime;
	}

	void Update ()
	{
		this.IsOnGround = true;
		float h = this.PlayerController.ShootHorizontalAxis;
		float v = this.PlayerController.ShootVerticalAxis;
		if (Mathf.Abs(h)>=0.4 || Mathf.Abs(v)>=0.4)
		{
			if ((Time.time - this.fireTime) > 0.6)
			{
				Vector3 dir = new Vector3(h, 0, v);
				GameObject bullet = (GameObject)Instantiate(BulletPrefab);
				bullet.transform.localPosition = this.transform.localPosition + dir*5;
				bullet.GetComponent<Rigidbody>().velocity = dir * 50;
				bullet.GetComponent<Bullet>().playerNumber = this.PlayerController.PlayerNumber;
				if (this.PlayerController.PlayerNumber == 0)
				{
					bullet.GetComponent<MeshRenderer>().materials[0].color = Color.blue;
				}
				else
				{
					bullet.GetComponent<MeshRenderer>().materials[0].color = Color.red;
				}
				this.fireTime = Time.time;
			}
		}
		if (this.PlayerController.PushButton)
		{
			if (this.PlayerController.PlayerNumber == 0)
			{
//				GameObject jointPoint = GameObject.Find("JointObjects").GetComponent<CustomJoint>().jointPoints[4];
				GameObject jointPoint = GameObject.Find("Player1");
				Vector3 unitVector = this.gameObject.transform.localPosition - jointPoint.transform.localPosition;
				unitVector = unitVector.normalized;
				Vector3 forceVector = unitVector*this.PushForce;
				jointPoint.GetComponent<Rigidbody>().AddForce(forceVector);
			}
			else
			{
//				GameObject jointPoint = GameObject.Find("JointObjects").GetComponent<CustomJoint>().jointPoints[4];
				GameObject jointPoint = GameObject.Find("Player0");
				Vector3 unitVector = jointPoint.transform.localPosition - this.gameObject.transform.localPosition;
				unitVector = unitVector.normalized;
				Vector3 forceVector = unitVector*this.PushForce;
				jointPoint.GetComponent<Rigidbody>().AddForce(forceVector);
			}
		}
		else if (this.PlayerController.PullButton)
		{
			if (this.PlayerController.PlayerNumber == 0)
			{
//				GameObject jointPoint = GameObject.Find("JointObjects").GetComponent<CustomJoint>().jointPoints[4];
				GameObject jointPoint = GameObject.Find("Player1");
				Vector3 unitVector = this.gameObject.transform.localPosition - jointPoint.transform.localPosition;
				unitVector = unitVector.normalized;
				Vector3 forceVector = unitVector*this.PullForce;
				jointPoint.GetComponent<Rigidbody>().AddForce(forceVector);
			}
			else
			{
//				GameObject jointPoint = GameObject.Find("JointObjects").GetComponent<CustomJoint>().jointPoints[4];
				GameObject jointPoint = GameObject.Find("Player0");
				Vector3 unitVector = this.gameObject.transform.localPosition - jointPoint.transform.localPosition;
				unitVector = unitVector.normalized;
				Vector3 forceVector = unitVector*this.PullForce;
				jointPoint.GetComponent<Rigidbody>().AddForce(forceVector);
			}
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

	public void UpdateScore(int scoreChange)
	{
		this.Score = this.Score + scoreChange;
	}
	
	public void OnTriggerEnter(Collider collider){
		if (collider.gameObject.name == "EndLevel"){
			//go to next level
		}
	}
}
