﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{ 
	public float xMin, xMax, zMin, zMax;
	public float speed;//飛行速度
	public float tilt;//傾斜角度

	public AudioClip fireSound;
	public GameObject shot;//發射物宣告
	public Transform shotSpawn;//發射地點
	public float FireRate;
	private float NextFire;

	void Update()
	{
		if (Input.GetKey(KeyCode.Space) && Time.time > NextFire)
		{
			NextFire = Time.time + FireRate;
			Instantiate(shot, shotSpawn.position, Quaternion.identity);
			gameObject.GetComponent<AudioSource>().clip = fireSound;
			gameObject.GetComponent<AudioSource>().Play();//播放音效
		}
	}

	void FixedUpdate ()//執行階級比update高
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");//抓取遊戲控制器ad

		float moveVertical = Input.GetAxis ("Vertical");//抓取遊戲控制器ws

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		gameObject.GetComponent<Rigidbody> ().velocity = movement * speed;
				
		//限定範圍
		gameObject.GetComponent<Rigidbody> ().position = new Vector3
				(
				Mathf.Clamp (gameObject.GetComponent<Rigidbody> ().position.x, xMin, xMax), //x軸範圍
				0.0f, 
				Mathf.Clamp (gameObject.GetComponent<Rigidbody> ().position.z, zMin, zMax)//z軸範圍
		);

		gameObject.GetComponent<Rigidbody> ().rotation = Quaternion.Euler (0.0f, 0.0f, gameObject.GetComponent<Rigidbody> ().velocity.x * -tilt);
	}
}
