using UnityEngine;
using System.Collections;

public class enemyHealth : MonoBehaviour {





	public int life = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	

		if (life <= 0)
		{
			Destroy(this.gameObject);
		}

	}




	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.tag == "bullet")
		{
			life -= 2;

		}

		if(col.gameObject.tag == "can")
		{
			life =0;

		}

	}


}
