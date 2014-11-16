using UnityEngine;
using System.Collections;

public class GoatStabilizer : MonoBehaviour {

	Vector3 frozenPos = Vector3.zero;

	bool frozen = false;
	int framesFrozenMax = 120;
	int framesFrozenElapsed = 120;

	void Update () {
		Vector3 angle = this.rigidbody.transform.eulerAngles;
		angle.x = 90;
		this.rigidbody.transform.eulerAngles = angle;
		if (frozen && framesFrozenElapsed++ < framesFrozenMax){
			this.rigidbody.transform.position = frozenPos;
		}
	}
	
	public void Freeze(){
		frozen = true;
		framesFrozenElapsed = 0;
		frozenPos = this.rigidbody.transform.position;
	}
}
