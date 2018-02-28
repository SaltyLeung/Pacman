using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class superdot : MonoBehaviour {
	int b = 1;
	// Use this for initialization
	void OnCollisionEnter2D(Collision2D co) {
		

		if (co.collider.name == "pacman"&&b==1) {// Do Stuff...
			GameObject superdot=GameObject.Find ("superdot");
			superdot.GetComponent<Transform>().transform.localScale+=new Vector3(17,17,0);
			//GetComponent<Rigidbody2D> ().transform.localScale += new Vector3(1,1,0);
			b=0;
		}
		if (co.collider.name == "fire") {
			Destroy (gameObject);
			Destroy (GameObject.Find ("superdot"));
		}
	}
	void OnTriggerStay2D(Collider2D co){
		if (co.name == "fire") {
			dotNum.dotNumber += 1;
			Destroy (gameObject);
			Destroy (GameObject.Find ("superdot"));
		}
	}
}
