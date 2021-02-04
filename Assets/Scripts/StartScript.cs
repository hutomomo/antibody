using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
    public AudioClip sound1;
    AudioSource audioSource;
   
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private IEnumerator WaitCommand()
    {

        audioSource.PlayOneShot(sound1);

        while (true)
        {

            yield return new WaitForFixedUpdate();

            if (!audioSource.isPlaying)
            {
                Debug.Log("コルーチン終了");
                SceneManager.LoadScene("MainScene");
                break;
            }

        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClickStartButton()
    {
        //audioSource.PlayOneShot(sound1);
        StartCoroutine(WaitCommand());
        //SceneManager.LoadScene("MainScene");
    }
    public void OnClickGameOverButton()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void OnClickResultButton()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
