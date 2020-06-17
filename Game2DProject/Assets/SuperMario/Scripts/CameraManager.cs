using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    GameObject mario;
    float cameraX;
    void Start()
    {
        cameraX = transform.position.x;
        mario= GameObject.Find("Mario");
    }

    // Update is called once per frame
    void Update()
    {
        CameraMove();
    }

    Vector3 thisPos;
    void CameraMove()
    {
        thisPos = transform.position;
        thisPos.x = mario.transform.position.x;

        //如果当前的X位置小于起始位置就别动了
        if (thisPos.x < cameraX)
        {
            return;
        }
        else
        {
            cameraX= thisPos.x ;
        }
        transform.position = thisPos;
    }
}
