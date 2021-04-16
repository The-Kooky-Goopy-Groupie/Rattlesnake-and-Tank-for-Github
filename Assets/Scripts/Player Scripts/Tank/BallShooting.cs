using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShooting : MonoBehaviour
{ 
	[SerializeField]
	public GameObject bullet;
	public Transform firePoint;
	public float bulletSpeed = 3;
	public float timer = 0;

	Vector2 lookDirection;
	float lookAngle;

	// Update is called once per frame
	void Update()
	{
		CheckIfTimeToFire();
		if (Input.GetAxisRaw("Fire2") > 0 && timer < 0) // CURRRENT ISSUE - How to stop the glitchy Bullet launch
		{
			timer = 300; // Timer reset Time
			GameObject bulletClone = Instantiate(bullet);
			bulletClone.transform.position = firePoint.position;
			bulletClone.transform.rotation = Quaternion.Euler(0, 0, lookAngle);

			bulletClone.GetComponent<Rigidbody2D>().velocity = firePoint.right * bulletSpeed;
		}
		timer = --timer;
	}

	void CheckIfTimeToFire()
	{
		
		 // Used to make the timer go back to 0
	}

}