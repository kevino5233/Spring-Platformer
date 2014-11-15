using UnityEngine;
using System.Collections;

public class RodMovement : MonoBehaviour {

	public GameObject destination;
	public float errorMargin;

	private Transform target;
	private Transform start;
	private bool toTarget;
	// Use this for initialization
	void Start () {
		target = destination.transform;
		start = transform;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 theForce;
		if(toTarget){
			theForce = target.position - transform.position;
			rigidbody.AddForce(theForce);
			if(Vector3.SqrMagnitude(theForce) < errorMargin){
				toTarget = false;
			}
		}
		else{
			theForce = start.position - transform.position;
			rigidbody.AddForce(theForce);
			if(Vector3.SqrMagnitude(theForce) < errorMargin){
				toTarget = true;
			}
		}
	}
}
