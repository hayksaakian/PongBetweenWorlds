using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PaddleController : MonoBehaviour {
	
	protected List<GameObject> horizontalBarriers;
	protected List<GameObject> paddles;
	
	protected List<float> ySeparaters;
	
	// Use this for initialization
	void Start () {
		AlignBarriers ();		
	}

	protected void AlignBarriers(){
		horizontalBarriers = new List<GameObject>(GameObject.FindGameObjectsWithTag("HorizontalBarrier"));
		ySeparaters = new List<float>();
		foreach(GameObject t in horizontalBarriers){
			ySeparaters.Add (t.transform.position.y);
		}
		ySeparaters.Sort ();

	}
	protected static int SortByY(GameObject o1, GameObject o2){
		return Mathf.RoundToInt(o1.transform.position.y - o2.transform.position.y);
	}

	protected void SortPaddles(){
		paddles.Sort (SortByY);
	}
	
	protected void SendInput(Vector3 location){
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
		location.z = paddles[whichPaddle].transform.position.z;
		paddles[whichPaddle].SendMessage("MoveTo", location);
		SortPaddles();
	}
}
