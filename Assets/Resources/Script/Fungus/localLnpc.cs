using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class localLnpc : MonoBehaviour
{
    public bool bgmplay = false;
    public bool endTrg = false;
    public string local = "local";
    public string badend = "badend";
    public bool setP = false;
    public npcsay input_say = null;
    Flowchart flowChart;
    // Start is called before the first frame update
    void Start()
    {
        flowChart = this.GetComponent<Flowchart>();
        if (GManager.instance.isEnglish == 1)
        {
            flowChart.SetBooleanVariable(local, true);
        }
        if(endTrg == true && GManager.instance.EventNumber[10] < GManager.instance.EventNumber[11])
        {
            flowChart.SetBooleanVariable(badend, true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(flowChart.GetBooleanVariable(local) == true && GManager.instance.isEnglish == 0)
        {
            flowChart.SetBooleanVariable(local, false);
        }
        else if (flowChart.GetBooleanVariable(local) == false && GManager.instance.isEnglish == 1)
        {
            flowChart.SetBooleanVariable(local, true);
        }
        if (endTrg == true && flowChart.GetBooleanVariable(badend) == false && GManager.instance.EventNumber[10] < GManager.instance.EventNumber[11])
        {
            flowChart.SetBooleanVariable(badend, true);
        }
        else if (endTrg == true && flowChart.GetBooleanVariable(badend) == true && GManager.instance.EventNumber[10] >= GManager.instance.EventNumber[11])
        {
            flowChart.SetBooleanVariable(badend, false);
        }
        if (bgmplay == true && flowChart.GetBooleanVariable("bgm") == true)
        {
            flowChart.SetBooleanVariable("bgm", false);
            npcsay ns = this.GetComponent<npcsay>();
            GameObject BGM = GameObject.Find("BGM");
            AudioSource bgmA = BGM.GetComponent<AudioSource>();
            bgmA.Stop();
            bgmA.clip = ns.bgm;
            bgmA.Play();
        }
        if(setP && flowChart.GetBooleanVariable("setP"))
        {
            flowChart.SetBooleanVariable("setP",false);
            GManager.instance.instantP[0] = flowChart.GetFloatVariable("npcX");
            GManager.instance.instantP[1] = flowChart.GetFloatVariable("npcY");
            GManager.instance.instantP[2] = flowChart.GetFloatVariable("npcZ");
            flowChart.SetFloatVariable("npcX", 0);
            flowChart.SetFloatVariable("npcY", 0);
            flowChart.SetFloatVariable("npcZ", 0);
        }
        if (input_say && flowChart.GetIntegerVariable("input") != 0)
        {
            input_say._inputLocal = flowChart.GetIntegerVariable("input");
            flowChart.SetIntegerVariable("input", 0);
        }

    }
}
