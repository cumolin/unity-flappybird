using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    /*
     遊戲控制類別：
     -控制遊戲進行及顯示UI
     -只能有一個GameControl物件
     */
    public static GameControl instance; //可藉由instance對外存取GameControl的變數及函數
    //遊戲UI
    public GameObject gameOverText;
    public Text scoreText;
    public bool gameOver = false;   //是否遊戲結束
    public float scrollSpeed = -1.5f;   //場景移動速度

    private int score = 0;  //分數

    void Awake()    //在Start()前執行，確認只有一個GameControl
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if(gameOver && Input.GetMouseButtonDown(0)) //遊戲結束後按左鍵可重新遊玩
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);   //載入目前場景
        }
    }

    public void BirdScored()    //得分函數
    {
        if (gameOver)
        {
            return;
        }
        score++;
        scoreText.text = "Score: " + score.ToString();
    }

    public void BirdDied()  //死亡函數
    {
        gameOverText.SetActive(true);
        gameOver = true;
    }
}
