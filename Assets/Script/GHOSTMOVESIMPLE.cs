using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GHOSTMOVESIMPLE : MonoBehaviour {
		public Transform[] waypoints;
		public int cur = 0;
	    public bool bb = false;
		public float speed = 0.3f;

		void FixedUpdate () {
		//Debug.Log (crash);// Waypoint not reached yet? then move closer
		if (bb == true) {
			if (transform.position != waypoints [cur].position) {
				Vector2 p = Vector2.MoveTowards (transform.position,
					waypoints [cur].position,
					speed);
				GetComponent<Rigidbody2D> ().MovePosition (p);
			}
			else cur = (cur - 1) % waypoints.Length;
		} else {
			if (transform.position != waypoints [cur].position) {
				Vector2 p = Vector2.MoveTowards (transform.position,
					            waypoints [cur].position,
					            speed);
				GetComponent<Rigidbody2D> ().MovePosition (p);
			}
			// Waypoint reached, select next one 

		else
				cur = (cur + 1) % waypoints.Length;
		}

			// Animation
			Vector2 dir = waypoints[cur].position - transform.position;
			GetComponent<Animator>().SetFloat("DirX", dir.x);
			GetComponent<Animator>().SetFloat("DirY", dir.y);
		}
		void OnTriggerEnter2D(Collider2D co) {
		
		if (co.name == "pacman")
				Destroy(co.gameObject);
		}
}

