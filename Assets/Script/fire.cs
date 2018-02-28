using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour {
	
	bool open=false;
	int a=0;
	void Start(){
		GetComponent<Animator> ().SetBool ("onfire", false);
		GetComponent<BoxCollider2D> ().enabled = false;
		GetComponent<Renderer> ().enabled = false;
	}
	// Use this for initialization
	void FixedUpdate(){
		
		if (Input.GetKey (KeyCode.F)) {
			GetComponent<Collider2D> ().enabled = true;
			GetComponent<Animator> ().SetBool ("onfire", true);
			GetComponent<Renderer> ().enabled = true;

			open = true;
		}
		if (open == true&&a<=25) {
			a += 1;
			GetComponent<Animator> ().SetInteger ("time", a);
		} 
		if (a >= 25) {
			a = 0;
			open = false;
			GetComponent<Renderer> ().enabled =false;
			GetComponent<Collider2D> ().enabled = false;
			GetComponent<Animator> ().SetBool ("onfire", false);
		}
	}
	void OnTriggerEnter2D(){
}
}
