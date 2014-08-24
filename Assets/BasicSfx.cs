using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BasicSfx : MonoBehaviour {

	protected Dictionary<List<AudioClip>, int> clipTracker = new Dictionary<List<AudioClip>, int>();
			
	protected AudioClip random(List<AudioClip> clips){
		// won't give an out of bounds exception
		return clips[Random.Range(0, clips.Count)];
	}

	protected AudioClip next(List<AudioClip> clips){
		int index = 0;
		if(clipTracker.ContainsKey(clips)){
			index = clipTracker[clips];
			index += 1;
			if(index >= clips.Count){
				index = 0;
			}
		}
		clipTracker[clips] = index;

		// won't give an out of bounds exception
		return clips[index];
	}

}
