using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public bool zoomtrg = true;
    public bool enablecamera = true;
    //　キャラクターのTransform
    [SerializeField]
    private Transform charaLookAtPosition;
    //　カメラの移動スピード
    [SerializeField]
    private float cameraMoveSpeed = 2f;
    //　カメラの回転スピード
    // 障害物とするレイヤー
    [SerializeField]
    private LayerMask obstacleLayer;
    Vector3 defaultPos;
    Vector3 dfP;
    public player pl;

    [SerializeField]
    private bool hittrg = false;
    private bool stoptrg = false;
    private float stoptime = 0;
    GameObject cpos;
    GameObject raypos;
    GameObject dfpos;
    //BoxCollider bc;
    
    private void Awake()
    {
        cameraMoveSpeed = 4;
        cpos = GameObject.Find("cmpos");
        raypos = GameObject.Find("raypos");
        dfpos = GameObject.Find("dfpos");//this.transform.position - pl.oldjumpP;
    }
    void LateUpdate()
    {
        if (GManager.instance.walktrg == true && charaLookAtPosition != null && enablecamera == true && cpos != null && raypos != null )
        {
            if(!Input.GetKey(KeyCode.LeftShift))
            {
                if (Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.Q))
                {
                    this.transform.eulerAngles = dfpos.transform.eulerAngles;
                    this.transform.position = dfpos.transform.position;
                }
            }
            if (stoptrg == true)
            {
                stoptime += Time.deltaTime;
                if (stoptime > 2f)
                {
                    stoptime = 0;
                    stoptrg = false;
                }
            }
            //　カメラの位置をキャラクターの後ろ側に移動させる
            if (hittrg == false && stoptrg == false)
            {
                transform.position = Vector3.Lerp(transform.position, dfpos.transform.position , cameraMoveSpeed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, dfpos.transform.position, cameraMoveSpeed * Time.deltaTime);
            }

            RaycastHit hit;
            //　キャラクターとカメラの間に障害物があったら障害物の位置にカメラを移動させる
            if (Physics.Linecast(raypos.transform.position, transform.position, out hit, obstacleLayer))
            {
                if (hittrg == false)
                {
                    stoptrg = true;
                    hittrg = true;
                }
            }
            else
            {
                if (hittrg == true && stoptrg == false)
                {

                    hittrg = false;
                }
            }
        }
    }

}