using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
	public float speed = 10f;
	// Use this for initialization
	void Start()
	{
		gameObject.GetComponent<Rigidbody>().velocity = transform.forward * speed;


		//Vector3.forward (0,0,1)
		//Vector3.back (0,0,-1)
		//Vector3.right (1,0,0)	
		//Vector3.left (-1,0,0)	
	}
}
