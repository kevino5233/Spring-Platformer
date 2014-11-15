using UnityEngine;
using System.Collections;

public class CustomJoint : MonoBehaviour {

	public GameObject bluPlayer;
	public GameObject redPlayer;
	public GameObject[] jointPoints;

	public string jointType = "spring";
	// Use this for initialization
	void Start () {
		Vector3 unitVector = this.redPlayer.transform.localPosition - this.bluPlayer.transform.localPosition;
		unitVector = unitVector.normalized;
		this.bluPlayer.AddComponent<SpringJoint> ();
		SpringJoint joint = this.bluPlayer.GetComponent<SpringJoint> ();
		this.jointPoints [0].transform.localPosition = this.bluPlayer.transform.localPosition + unitVector * 1;
		joint.connectedBody = this.jointPoints [0].GetComponent<Rigidbody> ();
		for (int i = 0; i < 7; i++) {
			this.jointPoints [i].transform.localPosition = this.bluPlayer.transform.localPosition + unitVector * 1;
			this.jointPoints[i].transform.localPosition = new Vector3();
			this.jointPoints[i].AddComponent<SpringJoint>();
			SpringJoint tempJoint = this.jointPoints[i].GetComponent<SpringJoint>();
			tempJoint.connectedBody = this.jointPoints[i+1].GetComponent<Rigidbody>();
		}
		this.jointPoints[8].AddComponent<SpringJoint>();
		joint = this.jointPoints[8].GetComponent<SpringJoint>();
		joint.connectedBody = this.redPlayer.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
