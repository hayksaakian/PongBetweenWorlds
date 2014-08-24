using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	float speed = 20f;

	float fixedXPosition = 0f;

//	float e = 2.72828f;

//	float bounceMultiplier = 2.5f;
	
	public Vector3 targetPosition = Vector3.zero;
//	Vector3 lastPosition = Vector3.zero;

	ParticleSystem debrisEmitter;

	// Use this for initialization
	void Start () {
		fixedXPosition = transform.position.x;
		targetPosition = transform.position;
//		lastPosition = transform.position;
		debrisEmitter = GetComponentInChildren<ParticleSystem>();
	}

//	bool arrived = true;
	
	// Update is called once per frame
	void Update () {
		
		Vector3 diff = targetPosition - transform.position;
		distance = Vector3.Distance(targetPosition, transform.position);
		if(distance > 0.05f){
			rigidbody2D.velocity = diff*speed;
			rigidbody2D.AddForce(diff*speed);
		}else {
//			if(arrived == false){
				rigidbody2D.velocity = Vector2.zero;
				targetPosition = transform.position;
//				arrived = true;
//			}
		}
		
//		realDiff = lastPosition - transform.position;
//		realSpeed = Vector3.Distance(lastPosition, transform.position)/Time.deltaTime;
//		if(realSpeed < 0.5f){
//			realSpeed = 0f;
//			rigidbody2D.velocity = Vector2.zero;
//			targetPosition = transform.position;
//		}
//		lastPosition = transform.position;

		//		distance = Vector3.Distance(targetPosition, transform.position);
//		if(distance < 0.5f && realSpeed < 0.1f){
//			rigidbody2D.velocity = Vector2.zero;
//			targetPosition = transform.position;
//		}

		
		// #juice
		float newSize = 1f/(1f+(Mathf.Log10(distance+1f)));
		
		
		transform.localScale = new Vector3(newSize, newSize, 1f);

	}
	public float distance;
	public Vector3 realDiff;
	public float realSpeed = 0f;

//	float maxSize = 1.5f;
//	float minSize = 0.5f;

	void FixedUpdate(){

	}

	void MoveTo(Vector3 location){
//		arrived = false;
		location.x = fixedXPosition;
		targetPosition = location;
	}
	void OnCollisionEnter2d(Collision2D col){
		print ("Paddle hit: "+col.gameObject.tag);
	}
	
	void OnTriggerEnter2D(Collider2D col){
		string tag = col.gameObject.tag;
		if(tag == "Ball"){
			Transform ball = col.gameObject.transform.root;

			debrisEmitter.Emit(10);
//			debrisEmitter.

			print ("bouncing "+ball.name);
		}
	}
}
