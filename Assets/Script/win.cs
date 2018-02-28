using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class win : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if(dotNum.dotNumber>=355)
			gameObject.SetActive(true);
	}
}
