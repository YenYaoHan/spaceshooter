using UnityEngine;
using System.Collections;

public class ChangeDir : MonoBehaviour {

	public float xMin, xMax, zMin, zMax;
	public float tilt;//制定偏移角
	public float dodge; //閃避
	public float smoothing;

	public Vector2 startWait;//初始等待時間  
	public Vector2 maneuverTime;//機動時間  maneuverTime.x , maneuverTime.y 
	public Vector2 maneuverWait;//停頓等待
	
	private float currentSpeed; //當前速度
	private float targetManeuver;

	private Rigidbody rig;
	public float speed = 10f;
	void Start ()
	{
		gameObject.GetComponent<Rigidbody>().velocity = transform.forward * speed;

		currentSpeed = gameObject.GetComponent<Rigidbody>().velocity.z;//制定當前速度往前
		StartCoroutine(Evade());//製作Coroutine
		rig = gameObject.GetComponent<Rigidbody>();
	}
	IEnumerator Evade ()
	{
		yield return new WaitForSeconds (Random.Range (startWait.x, startWait.y));//等待初始時間
		while (true)//進入無限迴圈
		{
			targetManeuver = Random.Range (1, dodge) * -Mathf.Sign (transform.position.x);//亂數偏移
			//mathf.sign(正數)-->返回1 , mathf.sign(負數)-->返回-1
			yield return new WaitForSeconds (Random.Range (maneuverTime.x, maneuverTime.y));//等一下
			targetManeuver = 0;
			yield return new WaitForSeconds (Random.Range (maneuverWait.x, maneuverWait.y));
		}
	}


	void FixedUpdate ()
	{
		float newManeuver = Mathf.MoveTowards (rig.velocity.x, targetManeuver, smoothing * Time.deltaTime);
		rig.velocity = new Vector3 (newManeuver, 0.0f, currentSpeed);//飛行指定

		rig.position = new Vector3
			(
				Mathf.Clamp(rig.position.x, xMin, xMax), 
				0.0f, 
				Mathf.Clamp(rig.position.z, zMin, zMax)
				);

		rig.rotation = Quaternion.Euler (0, 0, rig.velocity.x * -tilt);//飛行偏移量
	}
}
