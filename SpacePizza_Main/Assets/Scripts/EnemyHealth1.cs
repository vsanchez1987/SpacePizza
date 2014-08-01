using UnityEngine;
using System.Collections;

public class EnemyHealth1 : MonoBehaviour {


	public float eneHealth;
	private shooting Shooting;
	private GameObject enemy;
	private bool hasHit = false;




	// Use this for initialization
	void Start () {

		enemy = GameObject.FindGameObjectWithTag ("enemy");

		eneHealth = 100;
	
	}

	void OnCollisionEnter(Collision collision)
	{

		Shooting = (shooting)enemy.GetComponent(typeof(shooting));
		if(collision == Shooting.bullet)
		{
			eneHealth -= 10;
			Debug.Log("The Enemy has lost 10 points to its life");
		}
	}
	

}
