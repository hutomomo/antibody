using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
    [SerializeField]
    float speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0, Time.deltaTime * speed);       //ゆっくり下に流れる
        if (transform.position.y <= -10f)                                   //y座標が－10f以下ならば
        {
            transform.position = new Vector2(0, 10f);                       //移動させる
        }
    }
}
