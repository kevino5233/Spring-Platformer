using UnityEngine;
using System.Collections;

public class PlayerFollower : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = GameObject.FindGameObjectWithTag("Player").transform.position + new Vector3(0, 60, 0);
	}
}
