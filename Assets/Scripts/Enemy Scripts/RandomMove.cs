using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMove : MonoBehaviour
{
    private float latestDirectionChangeTime;
    private float directionChangeTime = 3f;
    private float characterVelocity = 0.5f;
    private Vector2 movementDirection;
    private Vector2 movementPerSecond;
    public Animator myAnime;
    public int HP = 10;
    public int MaxHP = 10;


    void Start()
    {
        latestDirectionChangeTime = 0f;
        myAnime = this.GetComponent<Animator>();
        calcuateNewMovementVector();
    }

    void calcuateNewMovementVector()
    {
        //create a random direction vector with the magnitude of 1, later multiply it with the velocity of the enemy
        movementDirection = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
        movementPerSecond = movementDirection * characterVelocity;
    }

    void Update()
    {
        //if the changeTime was reached, calculate a new movement vector
        if (Time.time - latestDirectionChangeTime > directionChangeTime)
        {
            latestDirectionChangeTime = Time.time;
            directionChangeTime = Random.Range(0f, 5.0f); // THIS IS USED TO MAKE THE RANDOM CODE HAPPEN ON A RANDOM INTERVAL
            calcuateNewMovementVector();
        }

        //move enemy: 
        transform.position = new Vector2(transform.position.x + (movementPerSecond.x * Time.deltaTime),
        transform.position.y + (movementPerSecond.y * Time.deltaTime));
        if (HP < 0)
        {
            StartCoroutine(WaitForDeathAnimation());
        }

    }

    public IEnumerator WaitForHurtAnimation()
    {
        yield return new WaitForSeconds(0.5f);
        myAnime.SetBool("Hurt", false);
    }
    public IEnumerator WaitForDeathAnimation()
    {
        myAnime.SetBool("Death", true);
        yield return new WaitForSeconds(1.0f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) // This Is used to Check If hitting a wall Area and then To Turn Back 
    {
        if (other.gameObject.tag == "Basic Walling")
        {
            Debug.Log("COLLISION  WALL"); // Used Currently In Testing
            movementPerSecond = -movementDirection * characterVelocity; // Inverses the direction on the movement Instead
            //movementDirection = new Vector2(0, 0);
        }

        if (other.gameObject.tag == "Bullet" && myAnime.GetBool("Hurt") == false) // Can Do Damage inside of here and this will give invublity on hit
        {
            Debug.Log("Enemy hit"); // Used Currently In Testing
            myAnime.SetBool("Hurt", true);
            HP = HP - 1;
            StartCoroutine(WaitForHurtAnimation());
        }

        if (other.gameObject.tag == "Ball" && myAnime.GetBool("Hurt") == false) // Can Do Damage inside of here and this will give invublity on hit
        {
            Debug.Log("Enemy hit"); // Used Currently In Testing
            myAnime.SetBool("Hurt", true);
            HP = HP - 5;
            StartCoroutine(WaitForHurtAnimation());
        }
    }

}
