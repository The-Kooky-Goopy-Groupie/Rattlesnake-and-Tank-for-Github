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
}
