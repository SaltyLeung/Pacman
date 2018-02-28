using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameradisabled : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject.Find ("Camera (1)").SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
