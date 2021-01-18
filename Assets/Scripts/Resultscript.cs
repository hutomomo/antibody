using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Resultscript : MonoBehaviour
{
    public Text ResultText;
    int resultscore = 0;
    void Start()
    {
        resultscore = GameControllerScript.getscore();
        Debug.Log(resultscore);
        ResultText.text = "スコア:" + resultscore;  //Scoreを更新する
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
