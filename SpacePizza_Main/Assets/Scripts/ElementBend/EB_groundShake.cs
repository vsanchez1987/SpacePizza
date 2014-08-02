using UnityEngine;
using System.Collections;

public class EB_groundShake : MonoBehaviour {
	
	
	public Rigidbody stone;
	public GameObject player;
	
	private float look = 1.0f;
	
	public int speed = 20;

	private Vector3 currPos;

	private int iD;
	
	// Use this for initialization
	void Start () {
		
		
		player = GameObject.Find("player");
		
	}


	/*
	void groundShake() 
	{

		for(float i = 0.0f; i <10.0f; i++){

			
			Rigidbody instantiatedStone = Instantiate(stone, this.transform.position + new Vector3(i,-1.0f,0.0f) , this.transform.rotation) as Rigidbody;
			
			instantiatedStone.velocity = transform.TransformDirection(new Vector3(0, 5, 0));


		}


	}
*/



	IEnumerator earth_quake(int countUpTo, float waitTime) //ground shake with delay 
	{
		for(float i = 0.0f; i <20.0f; i++){


			Rigidbody instantiatedStone = Instantiate(stone, currPos + new Vector3(i+i,-1.0f,0.0f) , this.transform.rotation) as Rigidbody;
			
			instantiatedStone.velocity = transform.TransformDirection(new Vector3(0, 1, 0));

			Debug.Log(i.ToString());
			yield return new WaitForSeconds(waitTime);


			Destroy(instantiatedStone);
			
		}
			

	}

	IEnumerator earth_quake_L(int countUpTo, float waitTime) //ground shake with delay 
	{
		for(float i = 0.0f; i <20.0f; i++){
			
			
			Rigidbody instantiatedStone = Instantiate(stone, currPos + new Vector3(-i,-1.0f,0.0f) , this.transform.rotation) as Rigidbody;
			
			instantiatedStone.velocity = transform.TransformDirection(new Vector3(0, 1, 0));
			
			Debug.Log(i.ToString());
			yield return new WaitForSeconds(waitTime);
			
			
			Destroy(instantiatedStone);
			
		}
		
		
	}



	// Update is called once per frame
	void Update () {
		
		
		if(Input.GetKeyDown("a")){
			look = -2.0f;

			iD = -1;//i pos or neg

			speed = -20;
		}
		
		if(Input.GetKeyDown("d")){
			look = 2.0f;

			iD = 1;

			speed = 20;
		}
		
		this.transform.position = player.transform.position + new Vector3(look,0.0f,0.0f);
		
		//direction = aim.transform.position - gun.transform.position;
		
		if(Input.GetMouseButtonDown(1))
		{
			//groundShake();

			currPos = this.transform.position;

			if(look == 2.0f)
			{
				StartCoroutine(earth_quake(20, 0.1f));
			}

			if(look == -2.0f)
			{
				StartCoroutine(earth_quake_L(20, 0.1f));
			}
		}


		
		
		//=====================================================================================================================
		
		
	}
}
