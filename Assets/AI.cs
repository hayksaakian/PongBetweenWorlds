using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AI : PaddleController {

	Transform ball;
	float defaultXPosition = 0f;
	public float ai_difficulty = 0.5f; // on a scale of 0 to 1;

	// how often should the AI reconsider it's moves?
	float lagTime = 0f;
	float cooldown = 0f;
	
	// Use this for initialization
	void Start () {
		base.AlignBarriers();
		
		paddles = new List<GameObject>(GameObject.FindGameObjectsWithTag("AI"));
		ball = GameObject.FindGameObjectWithTag("Ball").transform;
		if(paddles.Count > 0){
			defaultXPosition = paddles[0].transform.position.x;
		}

		base.SortPaddles();


		ApplyDifficulty();
	}


	// Update is called once per frame
	void Update () {
		// remove this from here once I finish tweaking
		ApplyDifficulty();
		if(cooldown <= 0){
			base.SendInput(new Vector3(defaultXPosition,ball.position.y,0f));
			cooldown = lagTime;
		}else{
			cooldown -= Time.deltaTime;
		}
	}

	void ApplyDifficulty(){
		lagTime = (1.0f - ai_difficulty)*0.5f;
		// ranges from 1.05 seconds lag to about 1.5 seconds


	}
}
