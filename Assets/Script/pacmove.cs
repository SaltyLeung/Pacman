using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class pacmove : MonoBehaviour {
	public float speed = 0.4f;
	int clock=0;
	public GameObject bubble;
	public int bubbleCount = 0;
	Collider2D crash=null;
	Vector2 dest = Vector2.zero;
	public bool up=false;

	void Start() {
		dest = (Vector2)transform.position;

	}
	void OnTriggerEnter2D(Collider2D co) {
		crash = co;
		//Debug.Log (co.name);
		/*if ((Vector2)transform.position == dest&&co.name!="bubble(clone)") {
			if (Input.GetKey (KeyCode.Space)) {
				if (clock % 5 == 0)
					Instantiate (bubble, GetComponent<Transform> ().position, GetComponent<Transform> ().rotation);
			}*
		}
		//if (co.collider.name == "maze") // Do Stuff...
*/
			

		}
	void OnTriggerStay2D(Collider2D co) {
		crash = co;
	}
	void OnTriggerExit2D(Collider2D co) {
		crash = co;
	}
	void FixedUpdate() {
		//Debug.Log (crash);
		clock += 1;
		// Move closer to Destination
		//Debug.Log (dotNum.dotNumber);
		Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
		GetComponent<Rigidbody2D>().MovePosition(p);
		//Debug.Log ((Vector2)transform.position);
		//Debug.Log (dest);
		//Debug.Log ((Vector2)transform.position == dest);
		// Check for Input if not moving
		if ((Vector2)transform.position == dest) 
		{
			if (Input.GetKey (KeyCode.Space)) {
				if ((bubbleCount<=20)&&(crash == null || (crash != null && crash.name != "bubble(Clone)"))) {
					Instantiate (bubble, GetComponent<Transform> ().position, GetComponent<Transform> ().rotation);
					bubbleCount += 1;
				}
			}
			if (Input.GetKey(KeyCode.W) && valid(Vector2.up))
			{GameObject.Find ("Mark").transform.localEulerAngles = new Vector3(0, 0, 90);
				dest = (Vector2)transform.position + Vector2.up;}
			if (Input.GetKey (KeyCode.D) && valid (Vector2.right)) {
				GameObject.Find ("Mark").transform.localEulerAngles = new Vector3(0, 0, 0);
				dest = (Vector2)transform.position + Vector2.right;
			}
			if (Input.GetKey (KeyCode.S) && valid (-Vector2.up)) {
				GameObject.Find ("Mark").transform.localEulerAngles = new Vector3(0, 0, -90);
				dest = (Vector2)transform.position - Vector2.up;
			}
			if (Input.GetKey (KeyCode.A) && valid (-Vector2.right)) {
				GameObject.Find ("Mark").transform.localEulerAngles = new Vector3(0, 0, 180);
				dest = (Vector2)transform.position - Vector2.right;
			}
		}
		Vector2 dir = dest - (Vector2)transform.position;
		GetComponent<Animator> ().SetFloat ("dirX", dir.x);
		GetComponent<Animator> ().SetFloat ("dirY", dir.y);
	}

	public bool valid(Vector2 dir) {
		 //Cast Line from 'next to Pac-Man' to 'Pac-Man'
		Vector2 pos = transform.position;
		RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
		return (hit.collider == GetComponent<Collider2D> ()) || (hit.collider == (GameObject.Find ("random").GetComponent<Collider2D> ()));/*)||(hit.collider==GameObject.Find ("fire").GetComponent<Collider2D>())*/

	}
}