using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	float speed = 20f;

	float fixedXPosition = 0f;

	public Vector3 targetPosition = Vector3.zero;

	// Use this for initialization
	void Start () {
		fixedXPosition = transform.position.x;
		targetPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
		Vector3 diff = targetPosition - transform.position;
		rigidbody2D.velocity = new Vector2(0f, diff.y*speed);
		rigidbody2D.AddForce(new Vector2(0f, diff.y*speed));
	}

	void MoveTo(Vector3 location){
		location.x = fixedXPosition;
		targetPosition = location;
	}
}
