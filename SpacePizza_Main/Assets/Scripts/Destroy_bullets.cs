﻿using UnityEngine;
using System.Collections;

public class Destroy_bullets : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}



	void OnCollisionEnter(Collision col)
	{
		Destroy(this.gameObject); 

	}
}
