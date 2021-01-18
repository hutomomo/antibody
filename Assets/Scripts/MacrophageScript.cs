using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MacrophageScript : MonoBehaviour
{
    private GameObject nearObj;         //最も近いオブジェクト
    private float searchTime = 0;    //経過時間
    private bool eat = false;       //食判定
    void Start()
    {
        nearObj = serchTag(gameObject,"Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        searchTime += Time.deltaTime;
        if (searchTime >= 1.0f)
        {
            if (eat)
            {
                nearObj = serchTag(gameObject, "Player");    //最も近かったEnemyタグを持ったオブジェクトを取得
            }
            else {
                nearObj = serchTag(gameObject, "Enemy");    //最も近かったEnemyタグを持ったオブジェクトを取得
            }
            searchTime = 0;                             //searchタイムを０にする
        }
        transform.LookAt(nearObj.transform);        //対象の位置の方向を向く
        transform.Translate(Vector3.forward * 0.01f);        //自分自身の位置から相対的に移動する
    }
    GameObject serchTag(GameObject nowObj, string tagName)//どのオブジェクトが近いか
    {
        float tmpDis = 0;           //距離用一時変数
        float nearDis = 0;          //最も近いオブジェクトの距離
        //string nearObjName = "";    //オブジェクト名称
        GameObject targetObj = null; //オブジェクト

        //タグ指定されたオブジェクトを配列で取得する
        foreach (GameObject obs in GameObject.FindGameObjectsWithTag(tagName))
        {
            //自身と取得したオブジェクトの距離を取得
            tmpDis = Vector3.Distance(obs.transform.position, nowObj.transform.position);

            //オブジェクトの距離が近いか、距離0であればオブジェクト名を取得
            //一時変数に距離を格納
            if (nearDis == 0 || nearDis > tmpDis)
            {
                nearDis = tmpDis;
                //nearObjName = obs.name;
                targetObj = obs;
            }

        }
        //最も近かったオブジェクトを返す
        //return GameObject.Find(nearObjName);
        return targetObj;
    }
}
