using UnityEngine;
using System.Collections;

public class Retry : MonoBehaviour {


	private int health =10;

	private Vector3 spawnPoint;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(health <=0)
		{

			this.transform.position = spawnPoint;

			health =10;
		}


		if(Input.GetKeyDown("r"))
		{
			health = 0;
		}

	
	}



	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "spawn1")
		{
			spawnPoint = col.gameObject.transform.position;
		}

		if(col.gameObject.tag == "spawn2")
		{
			spawnPoint = col.gameObject.transform.position;
		}


	}

}
