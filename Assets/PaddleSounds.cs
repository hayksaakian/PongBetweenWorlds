using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(AudioSource))]
public class PaddleSounds : BasicSfx {
	
	public static List<AudioClip> hits;
	public List<AudioClip> default_hits;
	
	float volume = 0.2f;

	// Use this for initialization
	void Start () {
		if(default_hits != null && default_hits.Count > 0){
			hits = default_hits;
		}
	}
	
	// Update is called once per frame
	void Update () {
	}

	void EmitDebris(int iDontCare){
		audio.PlayOneShot(random (hits), volume);
	}
}
