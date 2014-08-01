using UnityEngine;
using System.Collections;

public class EB_wall : MonoBehaviour {
	
	
	public Rigidbody stoneWall;
	public GameObject player;
	
	private float look = 1.0f;
	
	public int speed = 30;

	private Vector3 currPos;
	
	// Use this for initialization
	void Start () {
		
		
		player = GameObject.Find("player");
		
	}
	
	
	
	
	
	
	IEnumerator earth_wall(int countUpTo, float waitTime)
	{
		for(int i = 0; i < 3; i++){

			Rigidbody instantiatedStone = Instantiate(stoneWall, currPos + new Vector3(0.0f,-1.0f + i,0.0f) , this.transform.rotation) as Rigidbody;
		
			instantiatedStone.velocity = transform.TransformDirection(new Vector3(0, 0, 0)); // up vector speed

			Destroy(instantiatedStone);

			yield return new WaitForSeconds(waitTime);


		
		}

		
		//instantiatedStone.velocity = transform.TransformDirection(new Vector3(speed, 0, 0)); //forward vector speed
		
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
		
		if(Input.GetKeyDown("l"))
		{

			currPos = this.transform.position;
			
			StartCoroutine(earth_wall(20, 0.2f));
			
		}
		
		
		//=====================================================================================================================
		
		
	}
}
