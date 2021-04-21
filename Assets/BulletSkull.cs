using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSkull : MonoBehaviour
{
    public float speed = 4.0f;
    public Rigidbody2D MyRig;
    // Start is called before the first frame update
    void Start()
    {
        
    MyRig = GetComponent<Rigidbody2D>();
    MyRig.velocity = new Vector2(1, 0).normalized * speed;

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D other) // Used For the Collision of the Bullets - CURRENT ISSUE - No Collisions Detected
    {
        if (other.gameObject.tag == "Basic Walling") // != Exists! can be used for the thing
        {

            Destroy(this.gameObject);
        }


        if (other.gameObject.tag == "Basic Enemy" || other.gameObject.tag == "Boss Enemy") // != Exists! can be used for the thing
        {
            Destroy(this.gameObject);
        }

        if (other.gameObject.tag == "Enemy Bullets") // != Exists! can be used for the thing
        {
            Destroy(other.gameObject);
        }

    }
}
