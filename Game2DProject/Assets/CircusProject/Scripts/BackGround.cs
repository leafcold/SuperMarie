using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{

    Renderer backGroundMat;
    void Start()
    {
      backGroundMat=  GetComponent<Renderer>();
    }

    
    void Update()
    {
        
    }


    float offSet = 0;
    public void BackGroundMove(float dir)
    {
        //判断前后  dir>0 D前奏  dir<0  A 后走
        if (dir > 0)
        {
            backGroundMat.material.SetTextureOffset("_MainTex",
                new Vector2(offSet+=Time.deltaTime,0));
        }
        else
        {
            backGroundMat.material.SetTextureOffset("_MainTex",
                new Vector2(offSet -= Time.deltaTime, 0));
        }
    }

}
