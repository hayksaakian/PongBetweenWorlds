using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(AudioSource))]
public class GoalSounds : BasicSfx {

	public List<AudioClip> goals;

	void AddScore(){

		print ("playing goal sfx");
		audio.PlayOneShot(next (goals), 0.3f);
	}

}
