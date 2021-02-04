using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BaikinScript : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x + Random.Range(-8f, 8f) * Time.deltaTime, -8.5f, 8.5f),    //x座標
            transform.position.y - 2f * Time.deltaTime,
            0f
            );


        /*transform.position += new Vector3(
            Random.Range(-8f, 8f) * Time.deltaTime,                                   //x座標
            -2f * Time.deltaTime,
            0f
            );*/



        //    if (transform.position.y <= -10f)
        //    {
        //    }
    }
}
