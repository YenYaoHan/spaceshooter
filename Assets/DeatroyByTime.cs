﻿using UnityEngine;
using System.Collections;

public class DeatroyByTime : MonoBehaviour {

	public float lifetime;
	
	// Use this for initialization
	void Start () {
		Destroy(gameObject,lifetime);
	}

}
