using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // This is used to be able to swap through Scenes 

public class RandomMoveBoss : MonoBehaviour
{
    private float latestDirectionChangeTime;
    private float directionChangeTime = 3f;
    private float characterVelocity = 0.5f;
    private Vector2 movementDirection;
    private Vector2 movementPerSecond;
    public Animator myAnime;
    public int HP = 100;
    public int MaxHP = 100;
    public float fireRate = 4f;
    float nextFire;

    void Start()
    {
        latestDirectionChangeTime = 0f;
        myAnime = this.GetComponent<Animator>();
        calcuateNewMovementVector();
        nextFire = Time.time;

    }

    void calcuateNewMovementVector()
    {
        //create a random direction vector with the magnitude of 1, later multiply it with the velocity of the enemy
        movementDirection = new Vector2(0, Random.Range(-1.0f, 1.0f)).normalized;
        movementPerSecond = movementDirection * characterVelocity;
    }

    void Update()
    {
        //if the changeTime was reached, calculate a new movement vector
        if (Time.time - latestDirectionChangeTime > directionChangeTime)
        {
            latestDirectionChangeTime = Time.time;
            directionChangeTime = Random.Range(0f, 5.0f); // THIS IS USED TO MAKE THE RANDOM CODE RANDOM
            calcuateNewMovementVector();
        }

        //move enemy: 
        transform.position = new Vector2(transform.position.x + (movementPerSecond.x * Time.deltaTime),
        transform.position.y + (movementPerSecond.y * Time.deltaTime));
        if (HP < 0)
        {
            StartCoroutine(WaitForDeathAnimation());
        }
        // Update is called once per frame

    }


    public IEnumerator WaitForDeathAnimation()
    {
        myAnime.SetInteger("DIR", 1);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Scene 4 - Win!", LoadSceneMode.Single);

    }

    public IEnumerator InvunurbilityFrames()
    {
        yield return new WaitForSeconds(.2f);

    }

    private void OnTriggerEnter2D(Collider2D other) // This Is used to Check If hitting a wall Area and then To Turn Back 
    {
        if (other.gameObject.tag == "Basic Walling")
        {
            Debug.Log("COLLISION  WALL"); // Used Currently In Testing
            movementPerSecond = -movementDirection * characterVelocity; // Inverses the direction on the movement Instead
        }

        if (other.gameObject.tag == "Ball") // Can Do Damage inside of here and this will give invublity on hit
        {
            Debug.Log("Enemy hit - Ball"); // Used Currently In Testing
            StartCoroutine(InvunurbilityFrames());
            HP = HP - 5;
        }

        if (other.gameObject.tag == "Bullet") // Can Do Damage inside of here and this will give invublity on hit
        {
            Debug.Log("Enemy hit"); // Used Currently In Testing
            StartCoroutine(InvunurbilityFrames());
            HP = HP - 1;
        }
    }
}






