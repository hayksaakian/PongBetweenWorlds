using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AI : PaddleController {

	Transform ball;
	
	// Use this for initialization
	void Start () {
		base.AlignBarriers();
		
		paddles = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));
		ball = GameObject.FindGameObjectWithTag("Ball").transform;
		
		base.SortPaddles();
		
	}

	// Update is called once per frame
	void Update () {
	
	}
}
