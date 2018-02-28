using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class test : MonoBehaviour {
	bool firstStep=true;
	Vector2[] wp=new Vector2[77]; 
	Vector2 before=new Vector2(0,0);
	Vector2 dest;
	Vector2[] temp=new Vector2[77]; 
	public float speed = 0.3f;

	void Start () {
		for (int i = 0; i <= 76; ++i)
			wp [i] = GameObject.Find ("WP" + i.ToString ()).GetComponent<Transform> ().position;
		//Debug.Log (wp [76]);
	
		
		for (int j = 0; j <= 76; ++j) {
			bool a=true;
			for (int i = 0; i <= 76; ++i) {
				LayerMask mask1 = 1 << 8;
				bool condition1 = (!Physics2D.Linecast(wp[i],wp[j],mask1));
				bool condition2 = (Math.Abs(wp[i].x-wp[j].x)<1)||(Math.Abs(wp[i].y-wp[j].y)<1);
				bool condition4 = (wp [i] != wp[j]);
				if ((condition1 && condition2&&condition4) == true) {
					a = false;
					Debug.Log (j.ToString () + " " + i.ToString ());
				}
			}
			if (a==true)Debug.Log(j);
		}
	}
	void FixedUpdate () {
		int size = 0;
		for (int i = 0; i <= 76; ++i)
			temp [i] = new Vector2 (0, 0);
		if (firstStep == true) {
			Vector3 firstDest = GameObject.Find ("Waypoint0").GetComponent<Transform> ().position;
			Vector2 p = Vector2.MoveTowards (transform.position, firstDest, speed);
			GetComponent<Rigidbody2D> ().MovePosition (p);
			if (transform.position == firstDest) {
				firstStep = false;
				dest = transform.position;
				before = transform.position;
			}
		} 
		else {
			if ((Vector2)transform.position != dest) {
				Vector2 pNext = Vector2.MoveTowards ((Vector2)transform.position,
					dest, speed);
				GetComponent<Rigidbody2D> ().MovePosition (pNext);

			} 
			else {
			Vector2 pos = transform.position;
				Debug.Log (pos);
			for (int i = 0; i <= 76; ++i){
				LayerMask mask1 = 1 << 8;
				bool condition1 = (!Physics2D.Linecast(wp[i],pos,mask1));
				bool condition2 = (Math.Abs(wp[i].x-pos.x)<1)||(Math.Abs(wp[i].y-pos.y)<1);
				bool condition3 = (wp [i] != before);
				bool condition4 = (wp [i] != (Vector2)pos);
					Debug.Log ("1"+condition1);
					Debug.Log ("2"+condition2);
					Debug.Log ("3" + condition3);
					Debug.Log ("4" + condition4);
					if (condition1&&condition2&&condition4&&condition3){
						temp [size] = wp [i];
					size += 1;
				}
					//Debug.Log (size);
					int r = UnityEngine.Random.Range (0, 2);
				if (r == size) {
						r = size ;
						Debug.Log ("seldom");
					}
					Debug.Log ("r"+r);
					dest = temp [r];
			}
			before = transform.position;
		}
	}
		Vector2 dir = dest - (Vector2)transform.position;
		GetComponent<Animator> ().SetFloat ("DirX", dir.x);
		GetComponent<Animator> ().SetFloat ("DirY", dir.y);
  }

}
