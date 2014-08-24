using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

	public TextMesh scoreRenderer;
	int score = 0;

	int Score{
		get{return score;}
		set{
			score = value;
			if(scoreRenderer != null){
				scoreRenderer.text = score.ToString();
			}
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col){
		string tag = col.gameObject.tag;
		if(tag == "Ball"){
			Transform ball = col.gameObject.transform.root;
			SendMessage("AddScore");
			print ("Goal!!! "+ball.name);
		}
	}

	void AddScore(){
		Score += 1;
	}

	int stuck_frames = 0;
	string stuck_thing = "";

	void OnTriggerStay2D(Collider2D col){
//		string tag = col.gameObject.tag;
		print (col.name+" might be stuck!");
		if(stuck_frames > 10  && stuck_thing == col.name){
			stuck_frames = 0;
			stuck_thing = "";
			print (col.name+" is probably stuck!");
			col.gameObject.transform.root.BroadcastMessage("Reset", false);
//			Debug.Break();
		}
		stuck_thing = col.name;
		stuck_frames += 1;
	}

	void OnTriggerExit2D(Collider2D col){
		stuck_thing = "";
		stuck_frames = 0;
	}

}
