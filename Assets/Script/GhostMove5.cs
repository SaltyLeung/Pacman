using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMove5 : MonoBehaviour {
	public Transform[] waypoints;
	 Vector2[] Direction=new Vector2[4]; 
	Vector2[] line=new Vector2[4]; 
	Vector2[] Temp=new Vector2[4]; 
	Vector2 dest;
	Vector2 face;
	int cur=0;
	public float speed = 0.3f;
	bool firstStep;
	// Use this for initialization
	void Start () {
		firstStep = true;
		for(int i=0;i<=3;++i) Temp[i]=new Vector2 (0,0); 
	}
	
	// Update is called once per frame
	/*void FixedUpdate1 () {
		// Waypoint not reached yet? then move closer
		if (transform.position != waypoints[cur].position) {
			Vector2 p = Vector2.MoveTowards(transform.position,
				waypoints[cur].position,speed);
			GetComponent<Rigidbody2D>().MovePosition(p);
		}
		// Waypoint reached, select next one
		else cur = (cur + 1) % waypoints.Length;
		Vector2 dir = waypoints[cur].position - transform.position;
		GetComponent<Animator>().SetFloat("DirX", dir.x);
		GetComponent<Animator>().SetFloat("DirY", dir.y);
	}*/


void OnTriggerEnter2D(Collider2D co) {
	if (co.name == "pacman")
		Destroy(co.gameObject);
 }

	void OnTriggerStay2D(Collider2D co){
		if (co.name == "fire") {
			
			Destroy (gameObject);

		}
	}

	void FixedUpdate ()
	{
		for(int i=0;i<=3;++i) Temp[i]=new Vector2 (0,0); 
		// Waypoint not reached yet? then move closer
		if (firstStep == true) {
			Vector2 p = Vector2.MoveTowards (transform.position, waypoints [0].position, speed);
			GetComponent<Rigidbody2D> ().MovePosition (p);
			face = new Vector2 (0,1);
			if (transform.position == waypoints [0].position) {
				firstStep = false;
				dest = transform.position;

			}

		} 
		else {
			
			if ((Vector2)transform.position != dest) {
				Vector2 pNext = Vector2.MoveTowards ((Vector2)transform.position,
					               dest, speed);
				GetComponent<Rigidbody2D> ().MovePosition (pNext);

			} else {//Choose a dest
				
				Vector2 pos = transform.position;
				int size=0;
				Direction [0] = pos + new Vector2 (1, 0);
				Direction [1] = pos + new Vector2 (-1, 0);
				Direction [2] = pos + new Vector2 (0, -1);
				Direction [3] = pos + new Vector2 (0, 1);
				line [0] = pos + new Vector2 (1.5f, 0);
				line [1] = pos + new Vector2 (-1.5f, 0);
				line [2] = pos + new Vector2 (0, -1.5f);
				line [3] = pos + new Vector2 (0, 1.5f);
				for (int i = 0; i <= 3; ++i) {
					RaycastHit2D hit = Physics2D.Linecast (line[i], pos);
					bool condition1 = hit.collider.name != "maze";
					Debug.Log(condition1);
					bool condition2 = (face != -(Direction [i]-pos));
					Debug.Log (hit.collider.name);
					if (condition1&&condition2) {
						Temp [size] = Direction [i];
						size += 1;
					}
				}
				//RaycastHit2D hit2 = Physics2D.Linecast ((Vector2)transform.position+face, pos);
				//bool b=hit2.collider.name != "maze";
				if (size == 1) {
					dest = Temp[0];
					Debug.Log (size);
				} 
				else {
					int r = Random.Range (0, size);
					if (r == size)
						r = size - 1;
					Debug.Log (size);
					dest = Temp [r];

				}
				face = dest - (Vector2)transform.position;
			}
			Vector2 dir = dest - (Vector2)transform.position;
			GetComponent<Animator> ().SetFloat ("DirX", dir.x);
			GetComponent<Animator> ().SetFloat ("DirY", dir.y);

		}
	}
}