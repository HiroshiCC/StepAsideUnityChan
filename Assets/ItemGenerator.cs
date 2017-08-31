using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour {

    //carPrefabを入れる
    public GameObject carPrefab;
    //coinPrefabを入れる
    public GameObject coinPrefab;
    //cornPrefabを入れる
    public GameObject conePrefab;

    // Unity-chanのオブジェクト
    public GameObject unityChanObj ;

    // 障害物の間隔
    private float distance = 15.0f;
    // Unity-chanからみた、障害物の設置位置
    private float distanceOfUC = 40.0f;

    // 次に障害物を置くUnity-chanのZ位置
    private float targetPos;

    //スタート地点
    private int startPos = -160;
    //ゴール地点
    private int goalPos = 120;
    //アイテムを出すx方向の範囲
    private float posRange = 3.4f;

    // Use this for initialization
    void Start () {

        // Unity-chanのオブジェクトを取得
        unityChanObj = GameObject.Find("unitychan") ;

        // 次に目指す位置をセットする
        targetPos = (int)unityChanObj.transform.position.z + distanceOfUC + distance ;
    }

    // Update is called once per frame
    void Update () {
        // Unity-chanのZ座標を取得する
        float unityChanNow = unityChanObj.transform.position.z ;

        // 障害物を置かない位置ならば、何もしない（スタート直後とゴールの向こう側）
        if ( ( (unityChanNow + distanceOfUC ) < startPos) || (goalPos <= ( unityChanNow + distanceOfUC ) ) )
            return;

        // 次の目標位置に達していない場合は何もしない
        if (unityChanNow < targetPos)
            return;

        // 障害物を置く
        SetObstacle( unityChanNow + distanceOfUC );

        // 次の目標座標をセット
        targetPos += distance;

    }

    //***********************************************************
    //  障害物を置く
    //  引数
    //      float unityChanZ            : 障害物を置くZ位置
    //***********************************************************
    void SetObstacle(float unityChanZ)
    {
        //どのアイテムを出すのかをランダムに設定
        int num = Random.Range(0, 10);
        if (num <= 1)
        {
            //コーンをx軸方向に一直線に生成
            for (float j = -1; j <= 1; j += 0.4f)
            {
                GameObject cone = Instantiate(conePrefab) as GameObject;
                cone.transform.position = new Vector3(4 * j, cone.transform.position.y, unityChanZ);
            }
        }
        else
        {

            //レーンごとにアイテムを生成
            for (int j = -1; j < 2; j++)
            {
                //アイテムの種類を決める
                int item = Random.Range(1, 11);
                //アイテムを置くZ座標のオフセットをランダムに設定
                int offsetZ = Random.Range(-5, 6);
                //60%コイン配置:30%車配置:10%何もなし
                if (1 <= item && item <= 6)
                {
                    //コインを生成
                    GameObject coin = Instantiate(coinPrefab) as GameObject;
                    coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, unityChanZ + offsetZ);
                }
                else if (7 <= item && item <= 9)
                {
                    //車を生成
                    GameObject car = Instantiate(carPrefab) as GameObject;
                    car.transform.position = new Vector3(posRange * j, car.transform.position.y, unityChanZ + offsetZ);
                }
            }
        }

    }
}
