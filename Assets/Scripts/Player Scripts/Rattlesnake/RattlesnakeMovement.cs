using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // This is used to be able to swap through Scenes 

public class RattlesnakeMovement : MonoBehaviour
{

    public Animator myAnime;
    public Rigidbody2D MyRig;
    float Speed = 2.0f;
    public static int HP = 10;
    public static int MaxHP = 10;
    public static bool HasItem1 = false;
    public static bool HasItem2 = false;
    public GameObject Bullet;
    public Transform firePoint;

    public PaneAndSceneHandler Activator;

    Vector2 lookDirection;
    float lookAngle;


    // Start is called before the first frame update
    void Start()
    {
        myAnime = this.GetComponent<Animator>();
        MyRig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        //Basic Vertical Movement Code!
        float v = Input.GetAxisRaw("Vertical");
        MyRig.velocity = new Vector3(0, v, 0).normalized * Speed;


        // Animation Controls  - Note Animations take Prioity based on order seen here
        if (Input.GetAxisRaw("Fire1") > 0)
        {
            myAnime.SetInteger("DIR", 3); // works
        }
        else if (Input.GetAxisRaw("Vertical") > 0)
        {
            myAnime.SetInteger("DIR", 4); // Not going here for some reason - SOLVED - Reason Why Was Because Of no else

        }
        else if (Input.GetAxisRaw("Vertical") < 0)
        {
            myAnime.SetInteger("DIR", 5); // works

        }
        else
        {
            myAnime.SetInteger("DIR", 0); // works

        }

        if (HP <= 0)
        {
            SceneManager.LoadScene("Scene 4 - Lose!", LoadSceneMode.Single);
            HP = 10;
        }


        if (Input.GetAxisRaw("Jump") > 0 && HasItem2 == true) {
            HP = HP + 2;
            HasItem2 = false;
            Activator.p4.SetActive(false);
        }


        if (Input.GetAxisRaw("Jump") > 0 && HasItem1 == true)
        {
            myAnime.SetInteger("DIR", 3);
            HasItem1 = false;
            Activator.p3.SetActive(false);

            lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - firePoint.position;  
            lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg; 

            GameObject bulletClone = Instantiate(Bullet);
            bulletClone.transform.position = firePoint.position;
            bulletClone.transform.rotation = Quaternion.Euler(0, 0, 0);

            bulletClone.GetComponent<Rigidbody2D>().velocity = firePoint.right * Speed;

          
        }
    }


    private void OnTriggerEnter2D(Collider2D other) // Used For the Collision of the Bullets - CURRENT ISSUE - No Collisions Detected
    {

        if (other.gameObject.tag == "Enemy Bullets")
        {
           
            HP = HP - 1; // put after sending it away 
        }
        if (other.gameObject.tag == "Enemy Strong Bullets")
        {
           
            HP = HP - 2; // put after sending it away 
        }

    }
}