using UnityEngine;
using System.Collections;

public class EnemyOffense : MonoBehaviour {

	private GameObject player;
	 		HealthBar health;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void OnTriggerEnter(Collider other)
	{
		health = player.GetComponent ("HealthBar") as HealthBar;
		health.playerHealth -= 10;
		
		Debug.Log ("the player has lost 10 points in health");

	}
}
