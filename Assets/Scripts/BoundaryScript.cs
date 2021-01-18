using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryScript : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {            //出ていくゲームオブジェクトはcollisionで取得できる
        Destroy(collision.gameObject);                              //削除した
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
