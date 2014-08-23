using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour {

	public Transform nextTeleporter;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col){
		print ("teleporting");
		Vector3 nextPos = col.transform.position;
		float yDelta = nextTeleporter.position.y - transform.position.y;
		nextPos.y = nextPos.y + yDelta;
		col.gameObject.SendMessageUpwards("TryTeleportTo", nextPos);
	}
}
