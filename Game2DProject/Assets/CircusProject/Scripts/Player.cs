using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    //1主角移动功能 :获取背景脚本,调用对用的方法
    BackGround backGround;
    Animator anim;

    Rigidbody2D rig;
    void Start()
    {
        backGround = GameObject.Find("BackGround").GetComponent<BackGround>();
        anim = GetComponent<Animator>();

        rig = GetComponent<Rigidbody2D>();
    }

    public float horizontal;
    void Update()
    {
        PlayerMove();

    }

    private void PlayerMove()
    {
        if (isDie) return;
        horizontal = Input.GetAxis("Horizontal");

        if (horizontal != 0)
        {
            backGround.BackGroundMove(horizontal);
            anim.SetBool("IsRun", true);
        }
        else
        {
            anim.SetBool("IsRun", false);
        }



        //跳跃逻辑:第一游戏物体位置发生变化(Y),  通过刚体加力度的方式(力度)
        if (Input.GetKeyDown(KeyCode.Space) && isJump)
        {
            rig.AddForce(transform.up * 160);

            AudioManager.initialization.PlayJump();
        }
    }

    bool isJump;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            anim.SetBool("IsJump", false);
            isJump = true;
        }


    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            anim.SetBool("IsJump", true);
            isJump = false;
        }
    }


    public static bool isDie;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fire")
        {
            anim.SetBool("IsDie", true);
            AudioManager.initialization.PlayDie();
            isDie = true;
            rig.AddForce(Vector3.up * 150);
            Destroy(GetComponent<BoxCollider2D>());
            //GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
