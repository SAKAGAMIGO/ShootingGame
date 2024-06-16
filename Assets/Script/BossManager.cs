using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
   // private Vector3 move = Vector3(5,0,0);
    //Enemyの最大HP
    float _health = 20000f;
    public float HP => _health;

    public GameController _gameController;

    //ダメージを与える
    public void AddDamage(float damage)
    {
        _health -= damage;
    }

    //private void Move()
    //{
    //    transform.position = move;
    //}

    void Start()
    {
        //Move();
    }


    void Update()
    {
        //HPが0になったら実行
        if (_health <= 0)
        {
            //破壊のエフェクト
            //Instantiate(explosion, transform.position, transform.rotation);
            //破壊される
            Destroy(this.gameObject);
            _gameController.GameClear();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
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
