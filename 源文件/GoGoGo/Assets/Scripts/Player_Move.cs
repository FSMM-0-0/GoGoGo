using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class Player_Move : MonoBehaviour {

    public int playerSpeed = 3;       //运动速度
    public int playerJumpPower = 1500; //跳跃值
    private bool isGrounded = true;  //是否在地面上
    public Player_Score gameover;

    [DllImport("Gesture_DLL")]
    private static extern void GetCommand(ref int _gesture, ref int _over);

    //Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    //手势控制角色运动
    void PlayerMove()
    {
        //通过dll获取手势信息
        int over = 0;
        int gesture = -1;
        GetCommand(ref gesture, ref over);

        //通过手势信息判断是否跳跃
        if ((Input.GetButton("Jump") || gesture == 0) && isGrounded == true && gameover.isOver == false && gameover.win == false)
        {
            Jump();
        }

        //若游戏没有结束，角色以playerSpeed的速度向前运动
        if (gameover.isOver == false && gameover.win == false)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(playerSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
    }

    //跳跃
    void Jump()
    {
        //只有在地面上时才能跳跃，避免在空中连续跳跃的问题
        if (isGrounded == true)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, playerJumpPower));
            isGrounded = false;
        }
    }

    //判断是否在地面上
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
   
}
