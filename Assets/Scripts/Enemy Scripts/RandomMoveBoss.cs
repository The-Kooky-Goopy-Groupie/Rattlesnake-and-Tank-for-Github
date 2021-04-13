using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMoveBoss : MonoBehaviour
{
    private float latestDirectionChangeTime;
    private float directionChangeTime = 3f;
    private float characterVelocity = 0.5f;
    private Vector2 movementDirection;
    private Vector2 movementPerSecond;


    void Start()
    {
        latestDirectionChangeTime = 0f;
        calcuateNewMovementVector();
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

    }

    private void OnTriggerEnter2D(Collider2D other) // This Is used to Check If hitting a wall Area and then To Turn Back 
    {
        if (other.gameObject.tag == "Basic Walling")
        {
            Debug.Log("COLLISION  WALL"); // Used Currently In Testing
            movementPerSecond = -movementDirection * characterVelocity; // Inverses the direction on the movement Instead
        }
    }

}
