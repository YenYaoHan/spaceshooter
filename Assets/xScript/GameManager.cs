using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> hazards = new List<GameObject>(); //宣告敵人與隕石 
    public Vector3 spawnValues; //生成數值位置
    public int hazardCount;     //敵人數量  3
    public float spawnWait;     //生成等待時間 //1
    public float startWait;     //初始化等待時間 1
    public float NextAttWait;	//下一波攻擊時間 1


    public Text scoreText;       //分數顯示
    public Text restartText;     //重新開始顯示
    public Text gameOverText;	//遊戲結束

    private bool gameOver;      //判斷是否遊戲結束
    private bool restart;       //判斷是否重新開始
    private int score;			//總計分數
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;       //遊戲尚未結束
        restart = false;        //尚未重新開始
        restartText.text = "";  //設定重新開始字串為null
        gameOverText.text = ""; //設定遊戲結束字串為null
        score = 0;              //初始分數為0
        UpdateScore();

        StartCoroutine(SpawnWaves());
    }
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);//開始等待時間
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {//迴圈 若i沒大於總量 則繼續執行
                GameObject hazard = hazards[Random.Range(0, hazards.Count)];//宣告生成物

                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);//生成位置
                Quaternion spawnRotation = Quaternion.identity; //生成選轉量

                Instantiate(hazard, spawnPosition, spawnRotation); //生成敵人與隕石
                yield return new WaitForSeconds(spawnWait);   //等待生成間隔時間
            }
            yield return new WaitForSeconds(NextAttWait);
        }
    }

    void Update()
    {
        if (gameOver)//若gameOver為真
        {
            restartText.text = "Press 'R' for Restart";
            restart = true;//重新開始為真
        }
        if (restart)//若遊戲結束
        {
            if (Input.GetKeyDown(KeyCode.R))//則按R再玩一次
            {
                SceneManager.LoadScene("main");
            }
        }
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;//計算分數看板
    }
    public void AddScore(int newScoreValue)//AddScore 函式專做加分判定
    {
        score += newScoreValue;//分數累計
        UpdateScore();
    }
    public void GameOver()
    {
        gameOverText.text = "Game Over!";//顯示遊戲結束字樣
        gameOver = true;//gameOver為真
    }
    public void Reload()
    {
        SceneManager.LoadScene("main");
    }
}