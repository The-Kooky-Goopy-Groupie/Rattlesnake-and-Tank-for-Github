using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollisions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D other) // Used For the Collision of the Bullets - CURRENT ISSUE - No Collisions Detected
    {
        if (other.gameObject.tag ==  "WALL") // != Exists! can be used for the thing
        {
            Debug.Log("COLLISION DETECTED");
            Destroy(this.gameObject);
        }


        if (other.gameObject.tag == "ENEMY") // != Exists! can be used for the thing
        {
            Debug.Log("COLLISION DETECTED");
            Destroy(this.gameObject);
        }
      
        if (other.gameObject.tag == "ENEMYBULLET") // != Exists! can be used for the thing
        {
            Debug.Log("COLLISION DETECTED");
            Destroy(this.gameObject);
        }

    }
}
