using UnityEngine;
using System.Collections;

public class enemyAI : MonoBehaviour {




	private float distance;

	private Vector3 direction; 

	public GameObject player;

	public float speed = 0.2F;

	public int AttRange = 10;

	// Use this for initialization
	void Start () {



		player = GameObject.Find("player");
	
	}
	
	// Update is called once per frame
	void Update () {

		distance = Vector3.Distance(player.transform.position,this.transform.position);

		direction = player.transform.position - this.transform.position;


		if (distance < AttRange)
		{


			this.rigidbody.velocity = (direction * speed)/10;

		}



	
	}
}
