using UnityEngine;
using System.Collections;

public class CustomJoint : MonoBehaviour {

	public GameObject Player0;
	public GameObject Player1;
	public GameObject[] jointPoints;
	bool Done;

	public string jointType;
	// Use this for initialization
	void Start () {
		Done = false;
		Vector3 unitVector = this.Player1.transform.localPosition - this.Player0.transform.localPosition;
		unitVector = unitVector.normalized;
		float dist = Vector3.Distance (this.Player1.transform.localPosition, this.Player0.transform.localPosition);
		float factor = dist / 10.0f;
		for (int i = 0; i < 9; i++) {
			this.jointPoints [i].transform.localPosition = this.Player0.transform.localPosition + unitVector * ((i+1.0f)*factor);
		}
		if (jointType == "spring")
		{
			this.CreateSpring ();
		}
		else if (jointType == "rod")
		{
			this.CreateFixedRod();
		}
	}

	void ChangeJointType(string JointName)
	{
		if (jointType == JointName)
		{
			return;
		}
		Destroy (this.Player0.GetComponent<Joint> ());
		for (int i = 0; i < 9; i++)
		{
			Destroy(this.jointPoints[i].GetComponent<Joint>());
		}
		if (JointName == "spring")
		{
			this.CreateSpring();
		}
		else if (JointName == "rod")
		{
			this.CreateFixedRod();
		}
	}

	void CreateFixedRod()
	{
		this.jointType = "rod";
		this.Player0.AddComponent<FixedJoint> ();
		FixedJoint joint = this.Player0.GetComponent<FixedJoint> ();
		joint.connectedBody = this.jointPoints [0].GetComponent<Rigidbody> ();
		for (int i = 0; i < 8; i++) {
			this.jointPoints[i].AddComponent<FixedJoint>();
			FixedJoint tempJoint = this.jointPoints[i].GetComponent<FixedJoint>();
			tempJoint.connectedBody = this.jointPoints[i+1].GetComponent<Rigidbody>();
		}
		this.jointPoints[8].AddComponent<FixedJoint>();
		joint = this.jointPoints[8].GetComponent<FixedJoint>();
		joint.connectedBody = this.Player1.GetComponent<Rigidbody>();
	}

	void CreateSpring()
	{
		this.jointType = "spring";
		this.Player0.AddComponent<SpringJoint> ();
		SpringJoint joint = this.Player0.GetComponent<SpringJoint> ();
		joint.spring = 50;
		joint.damper = 0.0f;
		joint.minDistance = 0.0f;
		joint.maxDistance = 0.5f;
		joint.anchor = Vector3.zero;
		joint.connectedBody = this.jointPoints [0].GetComponent<Rigidbody> ();
		for (int i = 0; i < 8; i++) {
			this.jointPoints[i].AddComponent<SpringJoint>();
			SpringJoint tempJoint = this.jointPoints[i].GetComponent<SpringJoint>();
			tempJoint.spring = 50;
			tempJoint.damper = 0.0f;
			tempJoint.minDistance = 0.0f;
			tempJoint.maxDistance = 0.5f;
			tempJoint.anchor = Vector3.zero;
			tempJoint.connectedBody = this.jointPoints[i+1].GetComponent<Rigidbody>();
		}
		this.jointPoints[8].AddComponent<SpringJoint>();
		joint = this.jointPoints[8].GetComponent<SpringJoint>();
		joint.spring = 50;
		joint.damper = 0.0f;
		joint.minDistance = 0.0f;
		joint.maxDistance = 0.5f;
		joint.anchor = Vector3.zero;
		joint.connectedBody = this.Player1.GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update () {
	}
}
