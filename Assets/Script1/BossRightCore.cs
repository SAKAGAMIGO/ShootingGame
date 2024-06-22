using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRightCore : MonoBehaviour
{
    //ゲームオブジェクトを取得
    public GameObject _bulletPrefab;
    public GameObject _Muzzle;

    //爆発のエフェクト
    public GameObject _explosion;

    //Enemyの最大HP
    float _health = 2000f;
    public float HP => _health;

    //GameController取得
    GameController _gameController;

    private int count = 0;
    //ダメージを与える
    public void AddDamage(float damage)
    {
        _health -= damage;
    }

    BossManager _manager;


    //Enemyが生成されるとEnemyBulletも生成される
    private void Start()
    {
        _gameController = GameObject.Find("GameController").GetComponent<GameController>();
        _manager = GetComponentInParent<BossManager>();
    }

    void Update()
    {
        count++;

        Shot();
        //HPが0になったら実行
        if (_health <= 0)
        {
            //破壊のエフェクト
            Instantiate(_explosion, transform.position, transform.rotation);
            //破壊される
            Destroy(this.gameObject);
        }
    }

    //Bulletを生成
    private void Shot()
    {
        if (count % 400 == 0)
        {
            GameObject _bullet = Instantiate(_bulletPrefab);
            _bullet.transform.position = _Muzzle.transform.position;
        }
    }

        //Playerに当たったら実行
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
            //破壊のエフェクト
            Instantiate(_explosion, transform.position, transform.rotation);
        }
    }

    public void OnDestroy()
    {
        _gameController.AddScore();
        _manager.Count();
    }
}
