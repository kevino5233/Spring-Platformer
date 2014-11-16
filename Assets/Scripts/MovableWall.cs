using UnityEngine;
using System.Collections;

public class MovableWall : MonoBehaviour {
	public static float TimeForPause = 2;
	bool paused;
	float PauseTime;
	// Use this for initialization
	void Start () {
		paused = false;
		PauseTime = Time.time;
	}
	
	// Update is called once per frame
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

	void Pause()
	{
		Debug.Log ("Here");
		iTween.Pause (this.gameObject);
		this.paused = true;
		this.PauseTime = Time.time;
	}
}
