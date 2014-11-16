using UnityEngine;
using System.Collections;

public class SawScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider) 
	{
		string tag = collider.gameObject.tag;
		if (tag == "Player0" || tag == "Player1" || tag == "Joint")
		{
			GameObject.Find("JointObjects").GetComponent<CustomJoint>().DestroyJoint();
			PlayerPrefs.SetString("winner", "lose");
			Invoke("EndLevel",1);
		}
	}

	void EndLevel()
	{
		Application.LoadLevel("EndScreen");
	}
}
