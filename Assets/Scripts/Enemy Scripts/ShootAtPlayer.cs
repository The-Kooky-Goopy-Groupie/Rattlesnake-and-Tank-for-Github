using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAtPlayer : MonoBehaviour
{ 
	[SerializeField]
	GameObject bullet;
	public float fireRate = 4f;

	float nextFire;
	

	// Use this for initialization
	void Start()
	{
		nextFire = Time.time;
	}

	// Update is called once per frame
	void Update()
	{
		CheckIfTimeToFire();
	}

	void CheckIfTimeToFire()
	{
		if (Time.time > nextFire)
		{
			Instantiate(bullet, transform.position, Quaternion.identity);
			nextFire = Time.time + fireRate;
		}

	}

}