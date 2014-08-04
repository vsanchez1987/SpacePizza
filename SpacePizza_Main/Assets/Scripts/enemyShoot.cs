using UnityEngine;
using System.Collections;

public class enemyShoot : MonoBehaviour {




	public Rigidbody bullet;

	public GameObject enemyGun;

	public GameObject player;

	public float speed = 0.2F;
	
	public int AttRange = 5;

	private float distance;

	private Vector3 direction;

	// Use this for initialization
	void Start () {

		player = GameObject.Find("player");

		enemyGun = GameObject.Find("enemyGun");
	}




	IEnumerator enemy_shot(int countUpTo, float waitTime) //ground shake with delay 
	{
		for(float i = 0.0f; i <20.0f; i++){
			
			
			Rigidbody instantiatedBullet = Instantiate(bullet, enemyGun.transform.position , this.transform.rotation) as Rigidbody;

			direction = (player.transform.position - this.transform.position) / 10.0f;

			instantiatedBullet.velocity = transform.TransformDirection(direction * speed);
			
			Debug.Log(i.ToString());
			yield return new WaitForSeconds(waitTime);
			
			

		}
		

	}





	// Update is called once per frame
	void Update () {



		distance = Vector3.Distance(player.transform.position, this.transform.position);


		direction = (player.transform.position - this.transform.position) / 10.0f;


		if (distance < AttRange)
		{

			StartCoroutine(enemy_shot(10,10.0f));

		}

		if(distance > AttRange)
		{
			print("HEY HEY");

		}


	
	}
}
