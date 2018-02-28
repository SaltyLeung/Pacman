using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemShow : MonoBehaviour {
	//public Transform[] BeanLocation;
	//int a=0;
	// Use this for initialization
	void Start () {
		int a = Random.Range (0, 353);
		a = (a == 353 ? 352 : a);
		string theName = "bean"+a.ToString();
		GameObject g=GameObject.Find (theName);
		Transform t = GetComponent<Transform>();
		t.position= g.GetComponent<Transform>().position;


	}
	void FixedUpdate (){
	}
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D co) {
		int roll = 0;

		//ChangePac
		if(roll==0&&co.name=="pacman"){
			
			GameObject.Find ("mai_0").GetComponent<Animator> ().SetBool("ChangePac" , true);
			GameObject.Find ("mai_1").GetComponent<Animator> ().SetBool("ChangePac" , true);
			GameObject.Find ("mai_2").GetComponent<Animator> ().SetBool("ChangePac" , true);
			GameObject.Find ("mai_3").GetComponent<Animator> ().SetBool("ChangePac" , true);

			Destroy (gameObject);
		}

	}
}
