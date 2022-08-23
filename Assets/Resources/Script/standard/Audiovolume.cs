using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audiovolume : MonoBehaviour
{
    public bool battletrg = false;
    private bool isadd = false;
    float oldvolume;
    public bool setrg = false;
    void Start()
    {
        //アタッチされているAudioSource取得
        AudioSource audio = GetComponent<AudioSource>();
        if(GManager.instance.over == true)
        {
            audio.volume = GManager.instance.audioMax / 12;
            oldvolume = GManager.instance.audioMax / 12;
        }
        else if (setrg == false)
        {
            audio.volume = GManager.instance.audioMax / 4;
            oldvolume = GManager.instance.audioMax / 4;
        }
        else if (setrg == true)
        {
            audio.volume = GManager.instance.audioMax  ;
            oldvolume = GManager.instance.audioMax ;
        }
    }
    // Update is called once per frame
    private void Update()
    {
        AudioSource audio = GetComponent<AudioSource>();
        if (GManager.instance.over == true || GManager.instance.walktrg == false )
        {
            if (oldvolume != GManager.instance.audioMax / 16 && setrg == false && !GManager.instance.over )
            {
                audio.volume = GManager.instance.audioMax / 16;
                oldvolume = GManager.instance.audioMax / 16;
            }
            else if (oldvolume != 0 && setrg == false && GManager.instance.over)
            {
                audio.volume = 0;
                oldvolume = 0;
            }
        }
        else if (setrg == false && oldvolume != GManager.instance.audioMax / 4)
        {
            audio.volume = GManager.instance.audioMax / 4;
            oldvolume = GManager.instance.audioMax / 4;
        }
        else if (setrg == true && oldvolume != GManager.instance.audioMax)
        {
            audio.volume = GManager.instance.audioMax;
            oldvolume = GManager.instance.audioMax;
        }
        //オンオフ
        if (battletrg == false && GManager.instance.walktrg == false && isadd == false)
        {
            audio.enabled = false;
            isadd = true;
        }
        else if (battletrg == false && GManager.instance.walktrg == true && isadd == true)
        {
            audio.enabled = true;
            isadd = false;
        }
    }
}
