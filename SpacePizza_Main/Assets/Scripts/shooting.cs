using UnityEngine;
using System.Collections;

public class shooting : MonoBehaviour {


	public GameObject bullet;
	private Vector3 direction;
	public GameObject aim;
	//public GameObject gun;


	// Use this for initialization
	void Start () {

		bullet = GameObject.Find("Bullet");
		aim = GameObject.Find("Aim");
		//gun = GameObject.Find("Gun");
		//COMMENT FOR GITHUB
	}
	
	// Update is called once per frame
	void Update () {

		//direction = aim.transform.position - gun.transform.position;

		if(Input.GetMouseButtonDown(0))
		{

			bullet = Instantiate(Resources.Load("Bullet")) as GameObject;
			bullet.transform.position = this.transform.position;
			print(this.transform.position);
			bullet.rigidbody.AddForce(Vector3.right * 10);

		}

	
	}
}
