using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
	public GameObject explosion; //宣告爆炸特效(自身)
	public GameObject playerExplosion;//飛機爆炸特效

	public int scoreValue;      //分數
	private GameManager gameController; //抓取元件

	// Use this for initialization
	void Start()
	{
		GameObject gameControllerObject = GameObject.Find("ApplicationGameMaker");
		//使用名稱抓取遊戲物件

		if (gameControllerObject != null)
		{
			//若該物件存在
			gameController = gameControllerObject.GetComponent<GameManager>();
			//抓取其遊戲物件之元件Done_GameController
		}
		if (gameController == null)
		{//若物件不存在則顯示警告標語
			Debug.Log("Cannot find 'GameController' script");
		}
	}

	void OnTriggerEnter(Collider other)//觸發事件
	{
		if (other.tag == "Boundary" || other.tag == "Enemy")
		{
			//若碰到邊界或敵人
			return;//返回
		}

		if (explosion != null)
		{
			//若炸特效不存在
			Instantiate(explosion, transform.position, transform.rotation);
			//生成爆炸特效
		}

		if (other.tag == "Player")
		{
			//若碰到的對象為飛機本身
			if (playerExplosion != null)
				Instantiate(playerExplosion, other.transform.position, other.transform.rotation);//生成飛機爆炸特效

			gameController.GameOver();//呼叫gameover函式
		}
		gameController.AddScore(scoreValue);//加分
		Destroy(other.gameObject);//刪除觸發物
		Destroy(gameObject);//刪除本體
	}
}
