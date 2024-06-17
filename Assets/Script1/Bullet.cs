using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    //GameControllerの入れ物:AddScoreを使う
    GameController gameController;
    //Bulletのスピード
    [SerializeField] int bulletSpeed ;

    GameController gameController2 ;
    private void Start()
    {
        //ヒエラルキー上のObjectを取得
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    void Update()
    {
        Move();
        OffScreen();
    }

    //Bulletを右に飛ばす
    private void Move()
    {
        transform.position += new Vector3(bulletSpeed, 0, 0) * Time.deltaTime;
    }

    //Bulletが画面外に出たら消滅
    private void OffScreen()
    {
        if(this.transform.position.x > 10)
        {
            Destroy(this.gameObject);
        }
    }

    //BulletがPlayer以外にぶつかったら実行
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!collision.gameObject.CompareTag("Player"))
        { 
            Destroy(this.gameObject) ;
        }
    }
}
