using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water : MonoBehaviour {
	int clock=0;
	public int animationFlame;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		clock += 1;
		if (clock == animationFlame)
			DestroyObject (gameObject);
	}
	void OnTriggerStay2D(Collider2D co){
		if (co.name != "maze"&&clock>=5)
			DestroyObject (GameObject.Find(co.name));
	}
	void OnTriggerEnter2D(Collider2D co){
		if (co.name != "maze"&&clock>=5)
			DestroyObject (GameObject.Find(co.name));
	}


}

