using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillHp : MonoBehaviour
{
    //public RectTransform hpPos;
    public Image HPBar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //hpPos.localScale = new Vector3((RattlesnakeMovement.HP / (float)RattlesnakeMovement.MaxHP)* 0.2f, 3f, 1);
        HPBar.fillAmount = ((float)RattlesnakeMovement.HP / RattlesnakeMovement.MaxHP);

    }
}
