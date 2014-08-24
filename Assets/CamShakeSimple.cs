using UnityEngine;
using System.Collections;

public class CamShakeSimple : MonoBehaviour 
{
	
	Vector3 originalCameraPosition;
	
	float shakeAmt = 0;

	public float shakeMultiplier = 0.0025f;

	Camera mainCamera;

	void Start(){
		if(mainCamera == null){
			mainCamera = Camera.main;
		}
		originalCameraPosition = mainCamera.transform.position;
	}
	
	void Shake(Collision2D coll) 
	{
		
		shakeAmt = coll.relativeVelocity.magnitude * shakeMultiplier;
		InvokeRepeating("CameraShake", 0, .01f);
		Invoke("StopShaking", 0.3f);
		
	}
	
	void CameraShake()
	{
		if(shakeAmt>0) 
		{
			float quakeAmt = Random.value*shakeAmt*2 - shakeAmt;
			Vector3 pp = mainCamera.transform.position;
			pp.y+= quakeAmt; // can also add to x and/or z
			mainCamera.transform.position = pp;
		}
	}
	
	void StopShaking()
	{
		CancelInvoke("CameraShake");
		mainCamera.transform.position = originalCameraPosition;
	}
	
}