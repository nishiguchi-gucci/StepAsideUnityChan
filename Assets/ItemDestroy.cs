using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDestroy : MonoBehaviour {
    private GameObject mainCamera; //ゲームオブジェクト


    // Use this for initialization
    void Start () {
        this.mainCamera = GameObject.Find ("Main Camera"); //Findで見つけて代入
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(this.transform.position.z  < +mainCamera.transform.position.z) //距離の差を求める
        {
            Destroy(this.gameObject); //このゲームオブジェクト破壊
        }

    }
}
