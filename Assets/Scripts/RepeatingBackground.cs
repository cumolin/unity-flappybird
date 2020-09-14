using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    /*
     重複背景：
     -實現無限場景的效果
     */
    private BoxCollider2D groundCollider;   //取得BoxCollider2D
    private float groundHorizontalLength;   //取得BoxCollider2D的x大小

    void Start()
    {
        groundCollider = GetComponent<BoxCollider2D>(); //取得BoxCollider2D
        groundHorizontalLength = groundCollider.size.x; //取得BoxCollider2D的x大小
    }

    void Update()
    {
        if(transform.position.x <= -groundHorizontalLength) //當場景x位置小於-groundHorizontalLength
        {
            RepositionBackground();
        }
    }

    private void RepositionBackground() //將場景x位置加2倍groundHorizontalLength
    {
        Vector2 groundOffset = new Vector2(groundHorizontalLength * 2f, 0);
        transform.position = (Vector2)transform.position + groundOffset;
    }
}
