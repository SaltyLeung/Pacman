using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DJH_Tool : MonoBehaviour {
	[MenuItem("DJH/ChangeName")]
	// Use this for initialization
	public static void ChangeName()
	{
		int i = 0;
		foreach (GameObject g in Selection.gameObjects) {
			g.name += i;
			++i;
		}

	}
}
