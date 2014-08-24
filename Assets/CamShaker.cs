using UnityEngine;
using System.Collections;

public class CamShaker : MonoBehaviour {
	void OnCollisionEnter2D(Collision2D coll) {
		if(coll.collider.gameObject.tag == "Ball"){
			Camera.main.SendMessage("Shake", coll);
		}
	}

}
