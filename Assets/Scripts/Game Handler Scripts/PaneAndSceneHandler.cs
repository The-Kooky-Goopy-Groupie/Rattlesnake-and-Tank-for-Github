using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // This is used to be able to swap through Scenes 

public class PaneAndSceneHandler : MonoBehaviour
{

    public GameObject p1; // p1 is the Pane for the start screen buttons
    public GameObject p2; // pane two is used for the sound settings buttons

    public GameObject p3; // These two are used for the items
    public GameObject p4;

    public GameObject p5; // These Are used to put the comic pages
    public GameObject p6;
    public GameObject p7;
    public void setPanel(int p) // This is the code that will be attached to the Canvas in order
    {
        switch (p) // Each of the comments above these state the type of Code
        {
            //Back Button
            case 0:
                p1.SetActive(true); 
                p2.SetActive(false);
                break;
            // Settings 
            case 1:
                p1.SetActive(false);
                p2.SetActive(true);
                break;
            // Game Start
            case 2:
               SceneManager.LoadScene("Scene 2 - Level 1 - Tutorial Plains", LoadSceneMode.Single);
                break;
        // Comic Cutscenes 
            case 3:
                 SceneManager.LoadScene("Cutscene 1", LoadSceneMode.Single);
                break;
            case 4:
                SceneManager.LoadScene("Cutscene 2", LoadSceneMode.Single);
                break;
            case 5:
                SceneManager.LoadScene("Cutscene 3", LoadSceneMode.Single);
                break;
            
            default:
            break;
        }
    }
}

