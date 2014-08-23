using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	float speed = 20f;

	float fixedXPosition = 0f;

	float e = 2.72828f;

	float bounceMultiplier = 2.5f;

	public Vector3 targetPosition = Vector3.zero;


	// Use this for initialization
	void Start () {
		fixedXPosition = transform.position.x;
		targetPosition = transform.position;
	}

	bool arrived = true;
	
	// Update is called once per frame
	void Update () {
		
		Vector3 diff = targetPosition - transform.position;
		if(Vector3.Distance(targetPosition, transform.position) > 0.05f){
			rigidbody2D.velocity = diff*speed;
			rigidbody2D.AddForce(diff*speed);
		}else {
			if(arrived == false){
				rigidbody2D.velocity = Vector2.zero;
				arrived = true;
			}
		}
	}
	void FixedUpdate(){
		// #juice
		transform.localScale = new Vector3(
			1f/	Mathf.Sqrt(Mathf.Log(Mathf.Abs(rigidbody2D.velocity.y)+e))
			, 
			Mathf.Sqrt(Mathf.Log(Mathf.Abs(rigidbody2D.velocity.y)+e))
			, 1f);

	}

	void MoveTo(Vector3 location){
		arrived = false;
		location.x = fixedXPosition;
		targetPosition = location;
	}
	void OnCollisionEnter2d(Collision2D col){
		print (col.gameObject.tag);
	}
	
	void OnTriggerEnter2D(Collider2D col){
		string tag = col.gameObject.tag;
		if(tag == "Ball"){
			Transform ball = col.gameObject.transform.root;
			Vector2 v = ball.rigidbody2D.velocity;
			v.x = v.x*bounceMultiplier;
			print ("bouncing "+ball.name);
		}
	}
}
