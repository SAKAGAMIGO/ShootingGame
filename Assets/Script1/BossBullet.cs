using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet1 : MonoBehaviour
{
    //Bulletのスピード
    public int _bulletSpeed = 8;

    void Update()
    {
        Move();
        OffScreen();
    }

    /// <summary>
    /// Bulletを左に飛ばす
    /// </summary>
    private void Move()
    {
        transform.position +=
            new Vector3(-_bulletSpeed, 0, 0) * Time.deltaTime;
    }

    /// <summary>
    /// Bulletが画面外に出たら消滅
    /// </summary>
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
            //プレイヤーにダメージを与える
            collision.gameObject.GetComponent<PlayerManager>().AddDamage(10f);
            //このオブジェクトが破壊される
            Destroy(this.gameObject);
        }
    }
}
