using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Camera_System : MonoBehaviour {

    private GameObject player;
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;
    public Player_Score gameover;
    public Text gameOverText;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
    //控制摄像头跟随角色
	void LateUpdate () {
        if (gameover.isOver == false)
        {
            float x = Mathf.Clamp(player.transform.position.x, xMin, xMax);
            float y = Mathf.Clamp(player.transform.position.y, yMin, yMax);
            gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z);
            gameOverText.text = "";
        }
        else
        {
            //gameover时摄像头停留在最后位置
            gameOverText.transform.position = new Vector3(Screen.width / 2, Screen.height / 2, 0);
            gameOverText.text = "Game Over";
        }
    }
}
