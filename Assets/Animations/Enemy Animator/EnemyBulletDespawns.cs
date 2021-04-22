using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletDespawns : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) // Used For the Collision of the Bullets - CURRENT ISSUE - No Collisions Detected
    {
        // Start is called before the first frame update
        if (other.gameObject.tag == "Basic Walling") // != Exists! can be used for the thing
        {

            Destroy(this.gameObject);
        }

        if (other.gameObject.tag == "Player") // != Exists! can be used for the thing
        {

            Destroy(this.gameObject);
        }

        if (other.gameObject.tag == "Ball") // != Exists! can be used for the thing
        {
            Debug.Log("COLLISION Ball DETECTED");
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "Bullet") // != Exists! can be used for the thing
        {
          
            Destroy(this.gameObject);
        }


    }
}
