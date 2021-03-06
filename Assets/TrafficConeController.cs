﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficConeController : MonoBehaviour {

    // Unity-chanのオブジェクト
    private GameObject unityChanObj;

    // Use this for initialization
    void Start () {
        // Unity-chanのオブジェクトを取得
        unityChanObj = GameObject.Find("unitychan");
    }

    // Update is called once per frame
    void Update () {
        if (this.transform.position.z < ( unityChanObj.transform.position.z - 15 ) )
        {
            // Unity-chanより、15後方になったら消す
            Destroy(this.gameObject);
        }
    }
}
