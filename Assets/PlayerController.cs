using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{ 
	public float xMin, xMax, zMin, zMax;
	public float speed;//飛行速度
	public float tilt;//傾斜角度

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
