using UnityEngine;
using System.Collections;

public class CustomJoint : MonoBehaviour {

	public GameObject bluPlayer;
	public GameObject redPlayer;
	public Vector3 bluStart;
	public Vector3 redStart;
	public GameObject[] jointPoints;

	public string jointType = "spring";
	// Use this for initialization
	void Start () {
		Vector3 unitVector = redStart - bluStart;
		unitVector = unitVector.normalized;
		float dist = Vector3.Distance (redStart, bluStart);
		float factor = dist / 10.0f;
		Debug.Log (unitVector);
//		this.bluPlayer.AddComponent<SpringJoint> ();
//		SpringJoint joint = this.bluPlayer.GetComponent<SpringJoint> ();
		this.jointPoints [0].transform.localPosition = bluStart + unitVector * (factor);
		Debug.Log (this.jointPoints [0].transform.localPosition);
//		joint.minDistance = 0.0f;
//		joint.maxDistance = 0.5f;
//		joint.spring = 10f;
//		joint.connectedBody = this.jointPoints [0].GetComponent<Rigidbody> ();
		for (int i = 0; i < 8; i++) {
			this.jointPoints [i].transform.localPosition = bluStart + unitVector * ((i+1.0f)*factor);
//			Debug.Log(this.jointPoints[i].transform.localPosition);
//			this.jointPoints[i].AddComponent<SpringJoint>();
//			SpringJoint tempJoint = this.jointPoints[i].GetComponent<SpringJoint>();
//			tempJoint.connectedBody = this.jointPoints[i+1].GetComponent<Rigidbody>();
		}
		this.jointPoints [8].transform.localPosition = bluStart + unitVector * (9*factor);
//		this.jointPoints[8].AddComponent<SpringJoint>();
//		joint = this.jointPoints[8].GetComponent<SpringJoint>();
//		joint.connectedBody = this.redPlayer.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
