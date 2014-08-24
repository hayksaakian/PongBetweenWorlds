using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Teleporter : MonoBehaviour {

	public Transform nextTeleporter;
	public List<GameObject> otherTeleporters;

	public Color activeColor;
	public Color nextColor;
	public Color inactiveColor;
	bool active = false;

	SpriteRenderer sprite;

	public bool Active{
		set{
			active = value;
			sprite.color = active ? activeColor : inactiveColor;
			if(Active)
				nextTeleporter.SendMessage("SetNext");
		}
		get{
			return active;
		}
	}


	// Use this for initialization
	void Start () {
		otherTeleporters = new List<GameObject>(GameObject.FindGameObjectsWithTag("Teleporter"));
		otherTeleporters.Remove(gameObject);
		sprite = GetComponent<SpriteRenderer>();
		SortTeleporters();
		Transform ball = GameObject.FindGameObjectWithTag("Ball").transform;
		ballPosition = ball.transform.position;
		if(Vector3.Distance(transform.position, ballPosition) < Vector3.Distance(otherTeleporters[0].transform.position, ballPosition)){
			Active = true;
		}
	}

	bool shrink_top = false;

	// Update is called once per frame
	void Update () {
//		if(top.localScale.y < 0.1f){
//			shrink_top = false;
//		}
//		if(shrink_top){
////			top.localScale.y = Vector3.Lerp(
//			print ("lerping");
//			top.localScale = Vector3.Lerp(top.localScale, shrunken_top_scale, 0.3f);
//		}else{
//			top.localScale = Vector3.Lerp(top.localScale, original_top_scale, 0.3f);
//
//		}
	}

	
	static float teleportCooldown = 0.1f;
	static float lastTeleportTime = -0.1f;

	void OnTriggerEnter2D(Collider2D col){


		
		Rigidbody2D rb = col.gameObject.transform.root.rigidbody2D;
		if(Mathf.Sign (rb.velocity.x) != Mathf.Sign (rb.position.x)){
//		if(Time.time > lastTeleportTime+teleportCooldown){
			print ("teleporting");
			//SortTeleporters();
			//nextTeleporter = otherTeleporters[0].transform;

			Active =  false;
			nextTeleporter.SendMessage ("Activate", true);

			ballPosition = col.transform.position;

			Vector3 nextPos = ballPosition;
	//
	//		shrink_top = true;


			float yDelta = nextTeleporter.position.y - transform.position.y;
			nextPos.y = nextPos.y + yDelta;
			nextPos.x = nextTeleporter.position.x;
			col.gameObject.SendMessageUpwards("TeleportTo", nextPos);

			lastTeleportTime = Time.time;
		}
	}

	void SetNext(){
		sprite.color = nextColor;
	}

	void Activate(bool state){
		Active = state;
	}

	static Vector3 ballPosition = Vector3.zero;

	protected  int SortByY(GameObject o1, GameObject o2){
		return Mathf.RoundToInt(Vector3.Distance(o1.transform.position, ballPosition) - Vector3.Distance(o2.transform.position, ballPosition));
	}

	// sorts teleporters by nearest to furthest from a position
	protected void SortTeleporters(){
		otherTeleporters.Sort (SortByY);
	}

}
