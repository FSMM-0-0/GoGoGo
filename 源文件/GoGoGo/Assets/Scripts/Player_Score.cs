using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_Score : MonoBehaviour {

    private float timeLeft = 100;  //总时间
    private int playerScore = 0;  //当前分数
    private int k = 97;
    public bool isOver = false;   //是否gameover
    public bool win = false;     //是否win
    public GameObject scoreUI;
	
	void Update () {
        Health();
        Score();
    }

    //根据游戏进度计算当前分数
    void Score()
    {
        timeLeft -= Time.deltaTime;
        if ((int)timeLeft == k && isOver == false && win == false)
        {
            playerScore += 5;
            k -= 3;
        }
        scoreUI.gameObject.GetComponent<Text>().text = ("Score: " + Min(playerScore, 100));
    }

    private int Min(int a, int b)
    {
        if (a < b) return a;
        return b;
    }

    //用角色的位置信息判断是否掉落
    void Health()
    {
        if (gameObject.transform.position.y < -7)
        {
            isOver = true;
        }
    }

    //判断，触发win则获胜，触发flower则减10分
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "win")
        {
            win = true;
        }
        if (collision.gameObject.tag == "flower")
        {
            playerScore -= 10;
        }
    }

}
