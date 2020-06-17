using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    //让我活从右到左移动
    Player player;
    void Start()
    {
        player= GameObject.Find("Player").GetComponent<Player>();
    }

   
    void Update()
    {
        if (Player.isDie) return;
        transform.Translate(Vector3.left * Time.deltaTime * (player.horizontal + 0.5f));
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
