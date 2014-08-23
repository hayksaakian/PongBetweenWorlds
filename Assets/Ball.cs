using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	// Use this for initialization
	void Start () {
		RandomPush();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		print ("clicked ball");
		RandomPush();
	}

	void RandomPush(){
		Vector2 force = new Vector2(Random.value, Random.value);
		rigidbody2D.AddForce(100f*force);
	}

	float teleportCooldown = 0.5f;
	float lastTeleportTime = 0f;

	void TryTeleportTo(Vector3 position){
		if(Time.time > lastTeleportTime+teleportCooldown){
			BroadcastMessage("TeleportTo", position);
		}
	}

	void TeleportTo(Vector3 position){
		transform.position = position;
		lastTeleportTime = Time.time;		
	}
}
