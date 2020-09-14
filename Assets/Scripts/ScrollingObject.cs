using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    /*
     移動物件類別：
     -可以指定速度及方向移動
     */
    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(GameControl.instance.scrollSpeed, 0);   //設定速度
    }


    void Update()
    {
        if (GameControl.instance.gameOver)  //如果遊戲結束
        {
            rb2d.velocity = Vector2.zero;   //設定速度為０
        }
    }
}
