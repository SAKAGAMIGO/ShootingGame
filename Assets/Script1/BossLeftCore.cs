using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLeftCore : MonoBehaviour
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

    //BossManagerを取得
    BossManager _manager;

    //Bullet生成のインターバル
    private int _interval;

    /// <summary>
    /// ダメージを与える
    /// </summary>
    /// <param name="damage"></param>
    public void AddDamage(float damage)
    {
        _health -= damage;
    }

    /// <summary>
    /// Enemyが生成されるとEnemyBulletも生成される
    /// </summary>
    private void Start()
    {
        _gameController = GameObject.Find("GameController").GetComponent<GameController>();
        _manager = GetComponentInParent<BossManager>();
    }

    void Update()
    {
        _interval++;

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

    /// <summary>
    /// Bulletを生成
    /// </summary>
    private void Shot()
    {
        if (_interval % 800 == 0)
        {
            GameObject _bullet = Instantiate(_bulletPrefab);
            _bullet.transform.position = _Muzzle.transform.position;
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
            //破壊のエフェクト
            Instantiate(_explosion, transform.position, transform.rotation);
        }
    }

    /// <summary>
    /// Destroyしたら実行
    /// </summary>
    public void OnDestroy()
    {
        _gameController.AddScore();
        _manager.Count();
    }
}
