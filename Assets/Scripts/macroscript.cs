﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class macroscript : MonoBehaviour
{
    private GameObject nearObj;         //最も近いオブジェクト
    private GameControllerScript gameController;
    private bool eat = false;
    public Vector2 speed = new Vector2(0.05f, 0.05f);
    private float rad = 0;
    private Vector2 Position;
    GameObject Player; //Playerが入る変数
    PlayerScript script; //PlayerScriptが入る変数

    void Start()
    {
        nearObj = serchTag(gameObject, "Enemy");
        gameController = GameObject
           .FindWithTag("GameController")           //GameControllerを探すため
           .GetComponent<GameControllerScript>();
        Player = GameObject.Find("Player"); //Playerをオブジェクトの名前から取得して変数に格納する
        script = Player.GetComponent<PlayerScript>(); //Playerの中にあるPlayerScriptを取得して変数に格納する
    }

    void Update()
    {
        
        rad = Mathf.Atan2(
            nearObj.transform.position.y - transform.position.y,
            nearObj.transform.position.x - transform.position.x);
        Position = transform.position;
        Position.x += speed.x * Mathf.Cos(rad) * Time.deltaTime * 50;
        Position.y += speed.y * Mathf.Sin(rad) * Time.deltaTime * 50;
        transform.position = Position;
    }
    void FixedUpdate() {
        if (eat)
        {
            nearObj = serchTag(gameObject, "Player");    //最も近かったEnemyタグを持ったオブジェクトを取得
        }
        else
        {
            nearObj = serchTag(gameObject, "Enemy");    //最も近かったEnemyタグを持ったオブジェクトを取得
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)     //衝突判定
    {
        if (eat)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                gameController.AddScore(10);
                Destroy(gameObject);                                               //このオブジェクトを消す
                script.limit += 1;
            }
        }
        else {
            
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Destroy(collision.gameObject);                                          //enemyを消す
                eat = true;
            }
        }
        
        
    }
    GameObject serchTag(GameObject nowObj, string tagName)//どのオブジェクトが近いか
    {
        float tmpDis = 0;           //距離用一時変数
        float nearDis = 0;          //最も近いオブジェクトの距離
        GameObject targetObj = null; //オブジェクト

        
        foreach (GameObject obs in GameObject.FindGameObjectsWithTag(tagName))  //タグ指定されたオブジェクトを配列で取得する
        {
            tmpDis = Vector3.Distance(obs.transform.position, nowObj.transform.position);  //自身と取得したオブジェクトの距離を取得
            if (nearDis == 0 || nearDis > tmpDis)
            {
                nearDis = tmpDis;
                targetObj = obs;
            }

        }
        return targetObj;
    }
    

}
