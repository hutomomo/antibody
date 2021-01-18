using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour
{
    public GameObject enemy;
    public static int score;
    public  Text scoreText;
    public Text TimeText;
    private float Timelimit = 30;
    /*private GameObject pauseUIPrefab;	//ポーズした時に表示するUIのプレハブ
    private GameObject pauseUIInstance;    //ポーズUIのインスタンス*/
    void Start()
    {
        //DontDestroyOnLoad(this);
        InvokeRepeating("Spawn", 2f, 0.5f);
    }
    void Spawn()
    {
        Vector3 spawnPosition = new Vector3(                
            Random.Range(-8.5f, 8.5f),            
            transform.position.y,            
            transform.position.z
            );
            
        Instantiate(
            enemy,                  //プレハブを生成する            
            spawnPosition,     //位置をこのオブジェクトと一緒の位置にする
            transform.rotation      //回転をこのオブジェクトと一緒にする
            
            );
    }
    public static int getscore()
    {
        
        return score;
    }
    void Update()
    {
        Timelimit -= Time.deltaTime;
        TimeText.text = "残り時間" + Timelimit;  //Scoreを更新する
        if (Timelimit <= 0){
            SceneManager.LoadScene("ScoreScene");
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape key was pressed");
            if (Time.timeScale != 0f)                 //ポーズUIが表示されてる時は停止
            {
                Time.timeScale = 0f;
            }
            else
            {
                Time.timeScale = 1f;
            }
        }
    }
    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        UpdateScoreText();
    }
    void UpdateScoreText()                  //Scoreを更新する関数
    {
        scoreText.text = "Score:" + score;  //Scoreを更新する
    }

}
