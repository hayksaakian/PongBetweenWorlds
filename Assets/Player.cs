using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : PaddleController {

	// Use this for initialization
	void Start () {
		base.AlignBarriers();

		paddles = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));
		base.SortPaddles();

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.mousePresent && Input.GetMouseButton(0)){
			Vector3 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			SendInput(p);
//			SendInput(Camera.main.ScreenPointToRay (Input.mousePosition));
		}else if(Input.touchCount > 0){
			int fingerCount = 0;
			foreach (Touch touch in Input.touches) {
				if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled){
					Vector3 p = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 0f));
					SendInput(p);

					fingerCount++;
				}
				
			}
			if (fingerCount > 0){
				print("User has " + fingerCount + " finger(s) touching the screen");
			}
		}
//		Transform paddle;
//		Vector3 location;
//
//		paddle.SendMessage("MoveTo", location);

	}

}
