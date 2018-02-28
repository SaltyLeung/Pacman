using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class superdotface : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject spco=GameObject.Find ("spco");
		spco.GetComponent<Transform>().transform.localScale+=new Vector3(7,7,0);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
