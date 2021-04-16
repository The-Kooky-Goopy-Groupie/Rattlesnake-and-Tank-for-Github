using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shooting : MonoBehaviour
{ // PROBLEM - Need a Way to delay shot for the animation or adjust animnation to compensate.
    public GameObject Bullet;
    public Transform firePoint;
    public float bulletSpeed = 5;
    public float timer = 0;

    Vector2 lookDirection;
    float lookAngle;

    void Update()
    { // Issue  - Currrently Being Taken at the Orgin instead  - SOLVED - By adding +5f
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - firePoint.position; // Test 2  - Firepoint.position; - WORKS - THIS WORKS BECAUSE IT MINUSING THE CAMERA POSTION FROM IT 
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg; // testing here if can manualy move orgin point - Which yes by doing +5f it does arrive at that point

        firePoint.rotation = Quaternion.Euler(0, 0, lookAngle);

        if (Input.GetAxisRaw("Fire1") > 0 && timer < 0) // Other Issue Currently Can hold fire  - SOLVED - Fixed by Adding a Timer
        {
            timer = 150; // Timer reset Time
            GameObject bulletClone = Instantiate(Bullet);
            bulletClone.transform.position = firePoint.position;
            bulletClone.transform.rotation = Quaternion.Euler(0, 0, lookAngle);

            bulletClone.GetComponent<Rigidbody2D>().velocity = firePoint.right * bulletSpeed;
        }
        timer = --timer; // Used to make the timer go back to 0
    }
}

