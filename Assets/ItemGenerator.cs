using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    //carPrefabを入れる
    public GameObject carPrefab;
    //coinPrefabを入れる
    public GameObject coinPrefab;
    //cornPrefabを入れる
    public GameObject conePrefab;

    //スタート地点
    private int startPos = -160;
    //ゴール地点
    private int goalPos = 120;
    //アイテムを出すx方向範囲
    private float posRange = 3.4f;

    private GameObject unityChan;//ゲームオブジェクト unitychan

    private float unitychanPos = -160.0f;//unitychanの地点

    // Use this for initialization
    void Start()
    {
        this.unityChan = GameObject.Find("unitychan");//unityちゃんを見つける

        //一定の距離ごとにアイテム生成
        //for(int i = startPos; i < goalPos; i+=15)
        //{

        //}

    }


    // Update is called once per frame
    void Update()
    {
        if (this.unitychanPos < this.unityChan.transform.position.z)//unitychanPosよりunitychanの位置が大きくなったら
        {
            //どのアイテムを出すのかをランダムに設定
            int num = Random.Range(1, 11);
            if (num <= 2)
            {
                //コインをx軸方向に一直線に生成
                for (float j = -1; j <= 1; j += 04f)
                {
                    GameObject cone = Instantiate(conePrefab) as GameObject;
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, this.unityChan.transform.position.z + 40);
                }
            }
            else
            {
                //レーンごとにアイテムを生成
                for (int j = -1; j <= 1; j++)
                {
                    //アイテムの種類を決める
                    int item = Random.Range(1, 11);
                    //アイテムを置くz座標のオフセットをランダムに設定
                    int offsetZ = Random.Range(-5, 6);
                    //60%コイン配置:30%車配置:10%何もなし
                    if (1 <= item && item <= 6)
                    {
                        //コインを生成
                        GameObject coin = Instantiate(coinPrefab) as GameObject;
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, this.unityChan.transform.position.z + 40 + offsetZ);
                    }
                    else if (7 <= item && item <= 9)
                    {
                        //車を生成
                        GameObject car = Instantiate(carPrefab) as GameObject;
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, this.unityChan.transform.position.z + 40 + offsetZ);
                    }
                }
            }

            unitychanPos += 40.0f;//unitychanの位置を前に進める

        }

    }
}

