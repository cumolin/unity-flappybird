using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    /*
     水管類別
     -觸發時呼叫得分函數
     */
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<Bird>() != null)
        {
            GameControl.instance.BirdScored();
        }
    }
}
