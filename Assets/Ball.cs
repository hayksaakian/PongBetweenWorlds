using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	// Use this for initialization
	void Start () {
		RandomPush();
	}
	
	public Vector2 currentV = Vector2.zero;
	
	float tooMuchY = 7f;
	float tooMuchX = 30f;
	
	float minX = 1f;
	float minY = 0.1f;

	// Update is called once per frame
	void Update () {
		currentV = rigidbody2D.velocity;
		if(Mathf.Abs(currentV.y) > tooMuchY){
			currentV.y = Mathf.Sign (currentV.y)*tooMuchY;
		}
		
		if(Mathf.Abs(currentV.x) > tooMuchX){
			currentV.x = Mathf.Sign (currentV.x)*tooMuchX;
		}
		
		if(Mathf.Abs(currentV.y) < minY){
			currentV.y = Mathf.Sign (currentV.y)*minY*1.10f;
		}

		if(Mathf.Abs(currentV.x) < minX){
			currentV.x = Mathf.Sign (currentV.x)*minX*1.10f;
		}

		rigidbody2D.velocity = currentV;
//		if(Mathf.Abs(currentV.y) > tooMuchY){
//			print ("bouncing up and down!");
//			float excess = currentV.y - (tooMuchY*Mathf.Sign(currentV.y));
//			print (excess);
//			currentV.x = ((Mathf.Sqrt(Mathf.Abs(excess))*0.5f)*Mathf.Sign(currentV.x))+currentV.x;
//			currentV.y = currentV.y - (excess*0.5f);
//			rigidbody2D.velocity = currentV;
////			Debug.Break();
//		}
	}

//	void OnMouseDown(){
//		print ("clicked ball");
//		RandomPush();
//	}

	void RandomPush(){
		Vector2 force = new Vector2(5f, Random.value);
		rigidbody2D.velocity = force;
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
