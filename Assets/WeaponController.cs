using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour {

	public GameObject shot;//發射物
	public Transform shotSpawn;//發射位置
	public float fireRate;//發射尖閣k
	public float delay;//初始間格
	
	void Start ()
	{
		InvokeRepeating ("Fire", delay, fireRate);
	}

	void Fire ()
	{
		Instantiate(shot, shotSpawn.position, Quaternion.identity);
		if(gameObject!=null)
			GetComponent<AudioSource>().Play();
	}
}
