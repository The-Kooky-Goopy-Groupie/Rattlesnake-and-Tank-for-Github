using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallStart : MonoBehaviour
{
    public float speed = 4.0f;
    public Rigidbody2D MyRig;
    public float timer = 0;
    public GameObject Bullet;
    public Transform firePoint;
   
    
    public PaneAndSceneHandler Activator;

    Vector2 lookDirection;
    float lookAngle;

    // Start is called before the first frame update
    void Start()
    {
        MyRig = GetComponent<Rigidbody2D>();
      
    }

    // Update is called once per frame
    void Update()
    {

        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - firePoint.position; // Test 2  - Firepoint.position; - WORKS - THIS WORKS BECAUSE IT MINUSING THE CAMERA POSTION FROM IT 
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg; // testing here if can manualy move orgin point - Which yes by doing +5f it does arrive at that point

        firePoint.rotation = Quaternion.Euler(0, 0, lookAngle);

        if (Input.GetAxisRaw("Fire2") > 0 && timer < 0) // Other Issue Currently Can hold fire  - SOLVED - Fixed by Adding a Timer
        {
            timer = 300; // Timer reset Time
            MyRig.velocity = -(firePoint.right * speed);
        }
        timer = --timer; // Used to make the timer go back to 0
    }// CURRENT ISSUE - Ball Slows down and speeds up on some collisions


    private void OnTriggerEnter2D(Collider2D other) // Used For the Collision of the Bullets - CURRENT ISSUE - No Collisions Detected
    {

        
        if (other.gameObject.tag == "Bullet Item")
        {
            RattlesnakeMovement.HasItem1 = true;
            Activator.p3.SetActive(true);
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Heart Item")
        {
            RattlesnakeMovement.HasItem2 = true;
            Activator.p4.SetActive(true);
            Destroy(other.gameObject);
        }

    }
}
