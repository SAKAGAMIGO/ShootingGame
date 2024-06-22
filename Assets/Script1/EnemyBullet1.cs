using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet1 : MonoBehaviour
{
    //Bulletのスピード
    public int _bulletSpeed = 8;

    public GameObject _explosion;

    void Update()
    {
        Move();
        OffScreen();
    }

    //Bulletを左に飛ばす
    private void Move()
    {
        transform.position +=
            new Vector3(-_bulletSpeed, 0, 0) * Time.deltaTime;
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
            //プレイヤーにダメージを与える
            collision.gameObject.GetComponent<PlayerManager>().AddDamage(10f);
            //破壊のエフェクト
            Instantiate(_explosion);
            //このオブジェクトが破壊される
            Destroy(this.gameObject);
        }
    }
}
