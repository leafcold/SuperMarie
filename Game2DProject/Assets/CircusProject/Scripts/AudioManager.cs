using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    AudioSource playerAudio;
    void Start()
    {
        initialization = this;
        playerAudio = GetComponent<AudioSource>();
    }

   
    void Update()
    {
        
    }


    public AudioClip jump, die,over;
    public static AudioManager initialization;
    public void PlayJump()
    {
        playerAudio.PlayOneShot(jump);
    }
    public void PlayDie()
    {
        playerAudio.PlayOneShot(die);
        //延时调用  (自己倒计时)
        Invoke("PlayOver",1.5f);
    }
    public void PlayOver()
    {
        //停止背景音乐
        playerAudio.Stop();
        playerAudio.PlayOneShot(over);
    }
}
