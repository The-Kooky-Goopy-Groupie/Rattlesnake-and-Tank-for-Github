using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyFinder2 : MonoBehaviour // Used to see if all the basic enemy are dead and if they are go to the next scene
{
    //public static int EnemyCount;
    GameObject[] objs;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        objs = GameObject.FindGameObjectsWithTag("Basic Enemy");
        if (objs.Length <= 0)
        {
            SceneManager.LoadScene("Scene 2 - Level 1.2 - Tutorial Plains");
        }
    }
}

