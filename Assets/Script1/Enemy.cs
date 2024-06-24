using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Enemyの移動速度
    [SerializeField] int _moveSpeed;

    //爆発のエフェクト
    public GameObject _explosion;

    //Enemyの最大HP
    float _health = 200f;
    public float HP => _health;

    GameController _gameController;

    //ダメージを与える
    public void AddDamage(float damage)
    {
        _health -= damage;
    }

    void Update()
    {
        Move();
        OffScreen();
        //HPが0になったら実行
        if (_health <= 0)
        {
            //Scoreを+100
            //_gameController.AddScore();
            //破壊のエフェクト
            Instantiate(_explosion, transform.position, transform.rotation);
            //破壊される
            Destroy(this.gameObject);
        }
    }

    //Enemyを左に移動させる
    private void Move()
    {
        transform.position +=
            new Vector3(-_moveSpeed, 0, 0) * Time.deltaTime;
    }

    //Enemyが画面外に出たら消滅
    private void OffScreen()
    {
        if (this.transform.position.x < -10f)
        {
            Destroy(this.gameObject);
        }
    }

    //Playerに当たったら実行
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Playerにダメージを与える
            collision.gameObject.GetComponent<PlayerManager>().AddDamage(10f);
        }

        if (collision.gameObject.CompareTag("Bullet"))
        {
            _health -= 100f;
        }
    }
}
