using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BcellScript : MonoBehaviour
{

    private GameControllerScript gameController;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject
           .FindWithTag("GameController")           //GameControllerを探すため
           .GetComponent<GameControllerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(
            0,                                   //x座標
            2f * Time.deltaTime,
            0f
            );
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {    
        if (collision.gameObject.CompareTag("Enemy"))
        {
            gameController.AddScore(10);
            //Instantiate(explosion, transform.position, transform.rotation);         //爆発の演出を出す
            Destroy(collision.gameObject);                                          //enemyを消す
            Destroy(gameObject);                                                    //B細胞を消す
        }
    }

}
