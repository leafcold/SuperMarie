using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mario : MonoBehaviour
{

    //声音动画跳跃 死亡

    //额外需求:怪物
    Rigidbody2D rig;
    Animator anim;
    SpriteRenderer spriteRenderer;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        //获取动画
        anim = GetComponent<Animator>();
        //获取图片
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        MarioMove();

        MarioJump();
    }

    void MarioMove()
    {
        //第一刚体碰撞式 第二Tranform  第三 点对点
        float horizontal = Input.GetAxis("Horizontal");
        Vector2 rigVelocity = rig.velocity;
        rigVelocity.x = horizontal * 2.5f;
        rig.velocity = rigVelocity;

        if (horizontal != 0)
        {
            spriteRenderer.flipX = horizontal > 0 ? false: true;

            anim.SetBool("IsRun", true);
        }
        else
        {
            anim.SetBool("IsRun", false);
        }
    }

    void MarioJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rig.AddForce(transform.up * 150);
        }
    }
}
