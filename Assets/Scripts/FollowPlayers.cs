using UnityEngine;
using System.Collections;
using Jolly;

public class FollowPlayers : MonoBehaviour
{
	public GameObject[] Players;
	public float FollowLerpFactor = 5.0f;

	private Vector3 CameraOffset;
	private Vector3 TargetCameraPosition;

	void Start ()
	{
		this.CameraOffset = this.camera.transform.position;
	}

	void OnPreRender ()
	{
		float lerpFactor = Time.deltaTime * this.FollowLerpFactor;
		this.camera.transform.position = Vector3.Lerp(this.camera.transform.position, this.TargetCameraPosition, lerpFactor);
	}

	void Update ()
	{
		this.TargetCameraPosition = (HeroesAverageLocation().SetY (0) + this.CameraOffset);
	}
	
	private Vector3 HeroesAverageLocation()
	{
		Vector3 average = Vector3.zero;
		foreach (GameObject go in this.Players)
		{
			average += go.transform.position;
		}
		average /= this.Players.Length;
		return average;
	}

	public void CalculateScoreAndEndLevel(string winner)
	{
		float p0score = 0;
		float p1score = 0;
		p0score = GameObject.Find ("Player0").GetComponent<PlayerController> ().health + GameObject.Find ("Player0").GetComponent<Player> ().Score;
		p1score = GameObject.Find ("Player1").GetComponent<PlayerController> ().health + GameObject.Find ("Player1").GetComponent<Player> ().Score;
		PlayerPrefs.SetFloat ("P0Score", p0score);
		PlayerPrefs.SetFloat ("P1Score", p1score);
		if (winner == "win")
		{
			if (p0score>p1score)
			{
				winner = "0";
			}
			else if (p1score>p0score)
			{
				winner = "1";
			}
			else
			{
				winner = "draw";
			}
			PlayerPrefs.SetString ("winner", winner);
			Invoke ("EndLevel", 1);
		} else {
			PlayerPrefs.SetString("winner", "lose");
			Invoke ("NextLevel", 1);
		}
	}
	
	void NextLevel(){
		Application.LoadLevel("LevelEndScreen");
	}

	void EndLevel()
	{
		Application.LoadLevel ("EndScreen");
	}
}
