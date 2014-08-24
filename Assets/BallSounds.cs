using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(AudioSource))]
public class BallSounds : BasicSfx {

	public List<AudioClip> bounces;
	public List<AudioClip> teleports;

	float volume = 0.2f;

	void Burst(int iDontCare){
		audio.PlayOneShot(next (bounces), volume);
	}

	void BurstTeleporter(int iDontCare){
//		print ("playing teleport sound");
		audio.PlayOneShot(next (teleports), volume);
	}

}
