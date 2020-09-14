using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipePool : MonoBehaviour
{
    /*
     水管池類別：
     -遊戲開始時生成５個水管
     -固定頻率分別移動到指定位置
     */
    public int pipePoolSize = 5;    //水管池中有幾個水管
    public GameObject pipePrefab;   //水管Prefab
    public float spawnRate = 4f;    //生成頻率
    public float pipeMin = -1f;     //最小生成y座標
    public float pipeMax = 3.5f;    //最大生成y座標

    private GameObject[] pipes;     //存放水管陣列
    private Vector2 objectPoolPosition = new Vector2(-15f, -25f);   //遊戲開始時生成位置（相機外）
    private float timeSinceLastSpawned;     //距離上一次生成的時間
    private float spawnXPosition = 10f;     //生成x座標
    private int currentPipe = 0;            //目前移動水管在陣列中的位置

    void Start()
    {
        pipes = new GameObject[pipePoolSize];   //初始化陣列
        for(int i = 0; i < pipePoolSize; i++)   //生成pipePoolSize個水管
        {
            pipes[i] = (GameObject)Instantiate(pipePrefab, objectPoolPosition, Quaternion.identity);
        }
    }


    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime; //計時

        if(!GameControl.instance.gameOver && timeSinceLastSpawned >= spawnRate) //遊戲沒有結束且時間大於頻率
        {
            timeSinceLastSpawned = 0;   //重新計時
            float spawnYPosition = Random.Range(pipeMin, pipeMax);  //隨機生成生成y座標
            pipes[currentPipe].transform.position = new Vector2(spawnXPosition, spawnYPosition);    //移動陣列中第currentPipe個水管
            currentPipe++;  //currentPipe加一
            if (currentPipe >= pipePoolSize)    //如果大於pipePoolSize
                currentPipe = 0;    //重設currentPipe
        }
    }
}
