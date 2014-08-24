using UnityEngine;
using System.Collections;

public class ParticleSortingLayerFix : MonoBehaviour {

	public string layerName = "Ball";
	
	// Use this for initialization
	void Awake () {
		particleSystem.renderer.sortingLayerName = layerName;
		particleSystem.renderer.sortingOrder = -1;
	}
	
}
