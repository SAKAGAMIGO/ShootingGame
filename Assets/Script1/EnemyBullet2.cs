using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet2 : MonoBehaviour
{

    //Bulletのスピード
    public int bulletSpeed = 8;

    void Update()
    {
        Move();
        OffScreen();
    }

    //Bulletを左に飛ばす
    private void Move()
    {
        transform.position +=
            new Vector3(-bulletSpeed, 0, 0) * Time.deltaTime;
    }

    //Bulletが画面外に出たら消滅
    private void OffScreen()
    {
        if (this.transform.position.x < -10)
        {
            Destroy(this.gameObject);
        }
    }

    //BulletがPlayerにぶつかったら実行
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Playerにダメージを与える
            collision.gameObject.GetComponent<PlayerManager>().AddDamage(30f);
            //このオブジェクトが破壊される
            Destroy(this.gameObject);

        }
    }
}
