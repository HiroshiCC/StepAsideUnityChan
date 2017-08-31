using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CoinController : MonoBehaviour {

    // Unity-chanのオブジェクト
    private GameObject unityChanObj;

    // Use this for initialization
	void Start () {

        // Unity-chanのオブジェクトを取得
        unityChanObj = GameObject.Find("unitychan");

        //回転を開始する角度を設定
        this.transform.Rotate(0, Random.Range(0, 360), 0);
    }

    // Update is called once per frame
    void Update () {
        //回転
        this.transform.Rotate(0, 3, 0);

        // Unity-chanより、15後方になったら消す
        if (this.transform.position.z < ( unityChanObj.transform.position.z - 15 ) )
        {
            Destroy(this.gameObject);
        }
    }
}
