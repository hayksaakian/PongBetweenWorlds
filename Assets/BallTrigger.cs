using UnityEngine;
using System.Collections;

public class BallTrigger : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D col){
		if(col.tag != "Teleporter"){
			transform.root.SendMessage("Burst", 6);
		}
	}
}
