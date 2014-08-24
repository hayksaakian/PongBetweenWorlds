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
			Score += 1;
			print ("Goal!!! "+ball.name);
		}
	}

}
