using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //需求一:敌人移动  碰到任意物体后,回头(相反方向移动)

    //需求二:当主角踩到敌人后,敌人死亡,并且给主角回弹效果.(声音)

    //需求三:1解决柱子问题,2解决卡怪物的问题
    //3如果主角没有跳过去第二个珠子,隐形墙出现.
    //如果隐形墙出现主角死亡:
    //(主角死亡方式:1自定义,
    //2诞生一个怪物,强制死亡或者产生一个太阳(诞生一个王八让主角死亡))   
    Animator enemyAnim;
    void Start()
    {
        enemyAnim= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        EnmeyMove();
    }


    float speed = 0.5f;
    public void EnmeyMove()
    {
        if (GetComponent<Rigidbody2D>() == null) return;
        transform.Translate(Vector2.left*Time.deltaTime* speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            speed = -speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Mario")
        {
            //需要写在主角触发器里面
            //这里需要两次判断

            enemyAnim.SetTrigger("Die");

            collision.GetComponent<Rigidbody2D>().AddForce(transform.up*50);
            Destroy(GetComponent<Rigidbody2D>());
            Destroy(GetComponent<CircleCollider2D>());
            Destroy(GetComponent<BoxCollider2D>());
            Destroy(gameObject,1);
        }
    }
}
