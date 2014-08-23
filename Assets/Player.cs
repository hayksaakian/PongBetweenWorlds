using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {
	
	List<GameObject> horizontalBarriers;
	List<GameObject> paddles;
	
	List<float> ySeparaters;

	// Use this for initialization
	void Start () {
		horizontalBarriers = new List<GameObject>(GameObject.FindGameObjectsWithTag("HorizontalBarrier"));
		ySeparaters = new List<float>();
		foreach(GameObject t in horizontalBarriers){
			ySeparaters.Add (t.transform.position.y);
		}
		ySeparaters.Sort ();

		paddles = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));

		SortPaddles();

	}
	private static int SortByY(GameObject o1, GameObject o2){
		return Mathf.RoundToInt(o1.transform.position.y - o2.transform.position.y);
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

	void SortPaddles(){
		paddles.Sort (SortByY);
	}

	void SendInput(Vector3 location){
		int whichPaddle = 0;
		for(int i = 0; i< ySeparaters.Count;i++){
			float yp = ySeparaters[i];
			if(location.y > yp){
				whichPaddle += 1;
			}else{
				break;
			}
		}
//		print (whichPaddle);
		paddles[whichPaddle].SendMessage("MoveTo", location);
		SortPaddles();
	}

}
