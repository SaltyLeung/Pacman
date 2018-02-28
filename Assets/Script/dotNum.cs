using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dotNum : MonoBehaviour {
	public static int dotNumber=0;
	// Use this for initialization
	void Start () {
		dotNumber = 0;
	}
	
	// Update is called once per frame
	void Update () {
		Text t = GetComponent<Text> ();
		t.text = dotNum.dotNumber.ToString();
	}
}
