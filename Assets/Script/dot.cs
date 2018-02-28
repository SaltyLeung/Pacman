using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dot : MonoBehaviour {
	

	// Use this for initialization
	void OnTriggerEnter2D(Collider2D co) {
		if (co.name == "pacman") {// Do Stuff...
			dotNum.dotNumber+=1;
			Destroy (gameObject);
		}
		
	}
	void OnTriggerStay2D(Collider2D co){
		if (co.name == "fire") {
			dotNum.dotNumber+=1;
			Destroy (gameObject);
		}
	}
}
