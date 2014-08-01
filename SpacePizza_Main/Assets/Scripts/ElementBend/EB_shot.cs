using UnityEngine;
using System.Collections;

public class EB_shot : MonoBehaviour {
	
	
	public Rigidbody stone;
	public GameObject player;
	
	private float look = 1.0f;
	
	public int speed = 30;
	
	// Use this for initialization
	void Start () {
		

		player = GameObject.Find("player");

	}






	IEnumerator earth_shot(int countUpTo, float waitTime)
	{

		Rigidbody instantiatedStone = Instantiate(stone, this.transform.position + new Vector3(0.0f,-1.0f,0.0f) , this.transform.rotation) as Rigidbody;
		
		instantiatedStone.velocity = transform.TransformDirection(new Vector3(0, 5, 0)); // up vector speed


		yield return new WaitForSeconds(waitTime);
		
		instantiatedStone.velocity = transform.TransformDirection(new Vector3(speed, 0, 0)); //forward vector speed

	}




	
	// Update is called once per frame
	void Update () {
		
		
		if(Input.GetKeyDown("a")){
			look = -2.0f;
			
			speed = -30;
		}
		
		if(Input.GetKeyDown("d")){
			look = 2.0f;
			
			speed = 30;
		}
		
		this.transform.position = player.transform.position + new Vector3(look,0.0f,0.0f);
		
		//direction = aim.transform.position - gun.transform.position;
		
		if(Input.GetMouseButtonDown(0))
		{

			StartCoroutine(earth_shot(20, 0.5f));
			
		}
		
		
		//=====================================================================================================================
		
		
	}
}
