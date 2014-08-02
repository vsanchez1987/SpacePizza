using UnityEngine;
using System.Collections;

public class shooting : MonoBehaviour {


	public Rigidbody bullet;
	public Rigidbody soda;
	//private Vector3 direction;
	//public GameObject aim;
	public GameObject player;
	//public GameObject gun;
	canInventory canInventory;

	private float look = 1.0f;

	private Vector3 shoot_direction;

	public int speed = 50;

	// Use this for initialization
	void Start () {

		//bullet = Rigidbody.Find("Bullet");
		//aim = GameObject.Find("Aim");
		player = GameObject.Find("player");
		//gun = GameObject.Find("gun");
		//COMMENT FOR GITHUB
	}
	
	// Update is called once per frame
	void Update () {


		if(Input.GetKeyDown("a")){
			look = -1.0f;

			speed = -50;
		}

		if(Input.GetKeyDown("d")){
			look = 1.0f;

			speed = 50;
		}

		this.transform.position = player.transform.position + new Vector3(look,0.0f,0.0f);

		//direction = aim.transform.position - gun.transform.position;

		if(Input.GetMouseButtonDown(0))
		{
			Rigidbody instantiatedBullet = Instantiate(bullet, this.transform.position , this.transform.rotation) as Rigidbody;
			//bullet = Instantiate(Resources.Load("Bullet")) as GameObject;

			instantiatedBullet.velocity = transform.TransformDirection(new Vector3(speed, 0, 0));

			//instantiatedBullet.transform.position = instantiatedBullet.transform.position + new Vector3(0.0f,0.0f,0.0f);

			//bullet.transform.position = gun.transform.position;
			//bullet.transform.position = player.transform.position + new Vector3(1.0f,1.0f,0.0f);
			//print(instantiatedBullet.transform.position.y);
			//bullet.rigidbody.AddForce(Vector3.right * 10);

		}


		//=====================================================================================================================


		if (Input.GetMouseButtonDown (1)) 
			{
				

				Rigidbody instantiatedSoda = Instantiate (soda, this.transform.position + new Vector3 (0.0f, 2.0f, 0.0f), this.transform.rotation) as Rigidbody;
				//bullet = Instantiate(Resources.Load("Bullet")) as GameObject;
	
				instantiatedSoda.velocity = transform.TransformDirection (new Vector3 (speed / 4, 0, 0));

				canInventory = (canInventory)player.GetComponent (typeof(canInventory));

				canInventory.HMCans -= 1;
	
				//instantiatedBullet.transform.position = instantiatedBullet.transform.position + new Vector3(0.0f,0.0f,0.0f);
	
				//bullet.transform.position = gun.transform.position;
				//bullet.transform.position = player.transform.position + new Vector3(1.0f,1.0f,0.0f);
				//print(instantiatedBullet.transform.position.y);
				//bullet.rigidbody.AddForce(Vector3.right * 10);

			} 
			
	}
}
