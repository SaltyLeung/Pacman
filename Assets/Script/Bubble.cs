using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour {
	int destroyFlame=0;
	int clock=0;
	Collider2D crash=null;
	public Object water; 
	// Use this for initialization
	void Start () {
		GetComponent<Collider2D>().enabled=false;
	}
	void OnTriggerEnter2D(Collider2D co){
		if ((co.name == "mai_0") ||
		    (co.name == "mai_1") ||
		    (co.name == "mai_2") ||
		    (co.name == "mai_3")) {
			//MonoBehaviour script=GameObject.Find (co.name).GetComponent<GHOSTMOVESIMPLE> ();
			GameObject.Find (co.name).GetComponent<GHOSTMOVESIMPLE> ().bb = true;
			//GameObject.Find (co.name).GetComponent<GHOSTMOVESIMPLE> ().cur = (GameObject.Find (co.name).GetComponent<GHOSTMOVESIMPLE> ().cur - 1) % GameObject.Find (co.name).GetComponent<GHOSTMOVESIMPLE> ().waypoints.Length;
		}
	}
	// Update is called once per frame
	void FixedUpdate () {
		clock += 1;
		destroyFlame += 1;
		if (destroyFlame == 75) {
			GetComponent<Animator> ().SetBool ("bomb", true);
			Instantiate (water, GetComponent<Transform> ().position + new Vector3 (0,-2,0), 
				Quaternion.Euler(gameObject.transform.rotation.eulerAngles.x, 
					gameObject.transform.rotation.eulerAngles.y, 
					gameObject.transform.rotation.eulerAngles.z-90));
			Instantiate (water, GetComponent<Transform> ().position + new Vector3 (0, 2,0), 
				Quaternion.Euler(gameObject.transform.rotation.eulerAngles.x, 
					gameObject.transform.rotation.eulerAngles.y, 
					gameObject.transform.rotation.eulerAngles.z+90));
			Instantiate (water, GetComponent<Transform> ().position + new Vector3 (-2, 0,0), 
				Quaternion.Euler(gameObject.transform.rotation.eulerAngles.x, 
					gameObject.transform.rotation.eulerAngles.y, 
					gameObject.transform.rotation.eulerAngles.z+180));
			Instantiate (water, GetComponent<Transform> ().position + new Vector3 (2, 0,0), 
				Quaternion.Euler(gameObject.transform.rotation.eulerAngles.x, 
					gameObject.transform.rotation.eulerAngles.y, 
					gameObject.transform.rotation.eulerAngles.z));
			GetComponent<Collider2D>().isTrigger=true;
}
		if (destroyFlame == 100) {
			GameObject.Find ("pacman").GetComponent<pacmove> ().bubbleCount -= 1;
		    DestroyObject (gameObject);
		}
		if(clock==50)GetComponent<Collider2D>().enabled=true;
	}


}
