using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class superdot1 : MonoBehaviour {
	int b = 1;
	// Use this for initialization
	void OnCollisionEnter2D(Collision2D co) {
		

		if (co.collider.name == "pacman"&&b==1) {// Do Stuff...
			GameObject superdot=GameObject.Find ("superdot (1)");
			superdot.GetComponent<Transform>().transform.localScale+=new Vector3(7,7,0);
			//GetComponent<Rigidbody2D> ().transform.localScale += new Vector3(1,1,0);
			b=0;

		}
	}
	void OnTriggerStay2D(Collider2D co){
		if (co.name == "fire") {
			dotNum.dotNumber += 1;
			Destroy (gameObject);
			Destroy (GameObject.Find ("superdot (1)"));
		}
	}
}
