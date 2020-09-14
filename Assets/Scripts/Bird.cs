using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    /*
     鳥類別：
     -控制鳥的移動及死亡
     */

    public float upForce = 200f;    //向上的數值

    private bool isDead = false;    //是否死亡
    private Rigidbody2D rb2d;   //Rigibody2D

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); //獲得掛在物體上的Rigibody2D
    }

    void Update()
    {
        if (!isDead)    //非死亡狀態執行
        {
            if (Input.GetMouseButtonDown(0))    //如果按下左鍵
            {
                rb2d.velocity = Vector2.zero;   //將速度設為０，為包持每次上升的速度一致
                rb2d.AddForce(new Vector2(0, upForce)); //向上加力
            }
        }
    }

    private void OnCollisionEnter2D()   //當發生碰撞
    {
        rb2d.velocity = Vector2.zero;   //設速度為０
        isDead = true;  //死亡
        GameControl.instance.BirdDied();    //呼叫GameControl中的死亡函數
    }
}
