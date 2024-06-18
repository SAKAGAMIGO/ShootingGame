using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager2 : MonoBehaviour
{
    //Enemyの移動速度
    [SerializeField] int moveSpeed;

    //ゲームオブジェクトを取得
    public GameObject bulletPrefab;
    public GameObject Muzzle1;
    public GameObject Muzzle2;

    //爆発のエフェクト
    public GameObject explosion;

    //Enemyの最大HP
    float _health = 100f;
    public float HP => _health;

    //GameController取得
    GameController _gameController;

    //ダメージを与える
    public void AddDamage(float damage)
    {
        _health -= damage;
    }

    //Enemyが生成されるとEnemyBulletも生成される
    private void Start()
    {
        _gameController = GameObject.Find("GameController").GetComponent<GameController>();
        Shot1();
        Shot2();
    }

    void Update()
    {
        Move();
        OffScreen();
        //HPが0になったら実行
        if (_health <= 0)
        {
            //破壊のエフェクト
            Instantiate(explosion, transform.position, transform.rotation);
            //破壊される
            Destroy(this.gameObject);
        }
    }

    //Enemyを左に移動させる
    private void Move()
    {
        transform.position +=
            new Vector3(-moveSpeed, 0, 0) * Time.deltaTime;
    }

    //Enemyが画面外に出たら消滅
    private void OffScreen()
    {
        if (this.transform.position.x < -10f)
        {
            Destroy(this.gameObject);
        }
    }

    //Bulletを生成
    private void Shot1()
    {
        GameObject _bullet = Instantiate(bulletPrefab);
        _bullet.transform.position = Muzzle1.transform.position;
    }

    private void Shot2()
    {
        GameObject _bullet = Instantiate(bulletPrefab);
        _bullet.transform.position = Muzzle2.transform.position;
    }



    //BulletがPlayerにぶつかったら実行
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Playerにダメージを与える
            collision.gameObject.GetComponent<PlayerManager>().AddDamage(10f);
            //破壊のエフェクト
            Instantiate(explosion, transform.position, transform.rotation);
            //破壊される
            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            _health -= 100f;
        }
    }

    public void OnDestroy()
    {
        //_gameController.AddScore();
    }
}
