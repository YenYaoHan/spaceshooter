using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> hazards = new List<GameObject>(); //宣告敵人與隕石 
    public Vector3 spawnValues; //生成數值位置
    public int hazardCount;     //敵人數量  3
    public float spawnWait;     //生成等待時間 //1
    public float startWait;     //初始化等待時間 1
    public float NextAttWait;	//下一波攻擊時間 1

    // Start is called before the first frame update
    void Start()
    {
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

    // Update is called once per frame
    void Update()
    { 
    }
}
