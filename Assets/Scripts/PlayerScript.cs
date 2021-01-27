using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public GameObject Neutrophils;
    public GameObject Macrophage;
    float rotation_speed = 0; // 回転速度
    public float limit = 0;          //出現限界
    float tiltAngle = 60.0f;
    float smooth = 5.0f;
    void Start()
    {

    }
    void Update()
    {
        
        float dx = Input.GetAxis("Horizontal") * Time.deltaTime * 8f;           //xの座標操作
        float dy = Input.GetAxis("Vertical") * Time.deltaTime * 8f;             //yの座標操作
        float tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x + dx, -8.5f, 8.5f),                  //先ほどのｘ座標を基準に操作（位置　、左の移動制限、右の移動制限）
             Mathf.Clamp(transform.position.y + dy, -4.5f, 4.5f),                 //先ほどのｙ座標を基準に操作（位置　、下の移動制限、上の移動制限）
             0f                                                                 //z軸は変わらない
            );
        if (Time.timeScale != 0)
        {
            
            if (Input.GetKeyUp("space"))
            {
               
                if(limit < 5)
                {
                    Instantiate(
                        Macrophage,
                        transform.position,
                        transform.rotation
                    );

                    limit += 1;
                }
            }
            if (Input.GetKeyUp(KeyCode.B))
            {
                if (limit < 5)
                {
                    Instantiate(
                        Neutrophils,
                        transform.position,
                        transform.rotation
                    );

                    limit += 1;
                }
                

                
            }
        }
        Quaternion target = Quaternion.Euler(0, 0, tiltAroundZ);
        //ターゲットの回転に向かって減衰します
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
    }
    private void OnTriggerEnter2D(Collider2D collision)     //衝突判定
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);                                          //enemyを消す
            Destroy(gameObject);
            SceneManager.LoadScene("GameoverScene");
        }
    }
    

}

