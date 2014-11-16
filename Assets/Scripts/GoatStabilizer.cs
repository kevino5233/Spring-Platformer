using UnityEngine;
using System.Collections;

public class GoatStabilizer : MonoBehaviour {
	public static float TimeForPause = 1.5f;
	Vector3 frozenPos = Vector3.zero;

	public bool paused;
	float PauseTime;

	void Start() {
		paused = false;
		PauseTime = Time.time;
	}
	void Update () {
		if (paused)
		{
			if ((Time.time - this.PauseTime) > TimeForPause)
			{
				iTween.Resume(this.gameObject);
				this.PauseTime = Time.time;
				this.paused = false;
			}
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.name == "Player0")
		{
			collision.gameObject.GetComponent<PlayerController>().TakeDamage(2);
		}
		else if (collision.gameObject.name == "Player1")
		{
			collision.gameObject.GetComponent<PlayerController>().TakeDamage(2);
		}
	}
	
	public void Freeze(){
		iTween.Pause (this.gameObject);
		this.paused = true;
		this.PauseTime = Time.time;
	}
}
