using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
    public void OnClickStartButton()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void OnClickGameOverButton()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void OnClickResultButton()
    {
        SceneManager.LoadScene("TitleScene");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
