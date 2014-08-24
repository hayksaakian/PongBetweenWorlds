using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	// Use this for initialization

	Color base_color;
	public ParticleSystem trail;
	public ParticleSystem teleport_effects;
	public ParticleSystem collision_effects;
	public Color fast_color = new Color(0f, 255f, 49f, 255f);

	void Start () {
		RandomPush();
		ballSprite = GetComponent<SpriteRenderer>();

		base_color = ballSprite.color;
	}

	SpriteRenderer ballSprite;
	
	public Vector2 currentV = Vector2.zero;
	
	float tooMuchY = 7f;
	float tooMuchX = 30f;
	
	float minX = 2f;
	float minY = 0.1f;

	// Update is called once per frame
	void Update () {
		currentV = rigidbody2D.velocity;
		if(Mathf.Abs(currentV.y) > tooMuchY){
			currentV.y = Mathf.Sign (currentV.y)*tooMuchY;
		}
		
		if(Mathf.Abs(currentV.x) > tooMuchX){
			currentV.x = Mathf.Sign (currentV.x)*tooMuchX;
		}
		
		if(Mathf.Abs(currentV.y) < minY){
			currentV.y = Mathf.Sign (currentV.y)*minY*1.10f;
		}

		if(Mathf.Abs(currentV.x) < minX){
			currentV.x = Mathf.Sign (currentV.x)*minX*1.10f;
		}

		rigidbody2D.velocity = currentV;

		speedRatio = (((Mathf.Abs (currentV.x)-minX)/(tooMuchX-minX))+((Mathf.Abs (currentV.y)-minY)/(tooMuchY-minY)))*0.5f;
		Color newColor = ColorLerp(base_color, fast_color, speedRatio);
		ballSprite.color = newColor;
		trail.startColor = ballSprite.color;
	}

	void OutOfBoundsCheck(){
		if(Vector3.Distance(transform.position, Vector3.zero) > 35f){
			Reset(true);
		}
	}

	public float speedRatio;

	public static Color ColorLerp(Color c1, Color c2, float t){
		Vector4 rgba1 = new Vector4(c1.r, c1.g, c1.b, c1.a);
		Vector4 rgba2 = new Vector4(c2.r, c2.g, c2.b, c2.a);
		Vector4 rgbaNew = Vector4.Lerp(rgba1, rgba2, t);
		return new Color(rgbaNew.x, rgbaNew.y, rgbaNew.z, rgbaNew.w);
	}

	void OnMouseDown(){
		print ("clicked ball");
		Burst(10);
	}

	void Reset(bool hardReset=false){
		transform.position = new Vector3(0f, transform.position.y, transform.position.z);
		RandomPush();
	}

	void RandomPush(){
		Vector2 force = new Vector2(Mathf.Sign(Random.value)*5f, Random.value);
		rigidbody2D.velocity = force;
	}

	float teleportCooldown = 0.25f;
	float lastTeleportTime = 0f;

	void TryTeleportTo(Vector3 position){
		if(Time.time > lastTeleportTime+teleportCooldown){
			BroadcastMessage("TeleportTo", position);
		}
	}

	void TeleportTo(Vector3 position){
		SendMessage("BurstTeleporter", 10);
		trail.enableEmission = false;
		transform.position = position;

		lastTeleportTime = Time.time;
		InvokeNextFrame(EnableTrail);
	}

	void EnableTrail(){
		trail.enableEmission = true;
	}
	
	void Burst(int amount){
		collision_effects.Emit(amount);
	}

	void BurstTeleporter(int amount){
		teleport_effects.Emit(amount);
	}

	// Code to call a function on the next frame
	public delegate void Function();
	
	public void InvokeNextFrame(Function function){
		try{
			StartCoroutine(_InvokeNextFrame(function));    
		}catch{
			Debug.Log ("Trying to invoke " + function.ToString() + " but it doesnt seem to exist");    
		}           
	}
	
	private IEnumerator _InvokeNextFrame(Function function){
		yield return null;
		function();
	}


}
