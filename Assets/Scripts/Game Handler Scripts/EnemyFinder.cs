using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyFinder : MonoBehaviour // Used to see if all the basic enemy are dead and if they are go to the next scene
{
    public static int EnemyCount;
    GameObject[] objs;
    // Start is called before the first frame update
    void Start()
    {
        objs = GameObject.FindGameObjectsWithTag("Basic Enemy");
        foreach (GameObject Enemy in objs)
        {
            EnemyCount = EnemyCount + 1;
        }

        }

    // Update is called once per frame
    void Update()
    {
            if (EnemyCount <= 0)
            {
                SceneManager.LoadScene("bonus");
            }
        }
    }

