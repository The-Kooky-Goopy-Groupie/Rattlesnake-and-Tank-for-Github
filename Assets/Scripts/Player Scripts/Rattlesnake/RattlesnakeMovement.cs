using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // This is used to be able to swap through Scenes 

public class RattlesnakeMovement : MonoBehaviour
{

    public Animator myAnime;
    public Rigidbody2D MyRig;
    float Speed = 2.0f;
    public int HP = 10;
    public int MaxHP = 10;

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

        if (HP < 0)
        {
            SceneManager.LoadScene("Scene 4.1 - Lose!", LoadSceneMode.Single);
        }
    }


    private void OnTriggerEnter2D(Collider2D other) // Used For the Collision of the Bullets - CURRENT ISSUE - No Collisions Detected
    {

        if (other.gameObject.tag == "Enemy Bullets")
        {
            Debug.Log("COLLISION ENEMY BULLET DETECTED");
            HP = HP - 1; // put after sending it away 
        }
        if (other.gameObject.tag == "Enemy Strong Bullets")
        {
            Debug.Log("COLLISION ENEMY BULLET DETECTED");
            HP = HP - 2; // put after sending it away 
        }

    }
}