using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager1 : MonoBehaviour
{
    //Blockの移動速度
    [SerializeField] float moveSpeed;

    //爆発のエフェクト
    public GameObject explosion;

    //Blockの最大HP
    float _health = 900f;
    public float HP => _health;

    //GameController取得
    GameController _gameController;

    //ダメージを与える
    public void AddDamage(float damage)
    {
        _health -= damage;
    }

    void Start()
    {
        _gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    void Update()
    {
        Move();
        OffScreen();
        //Blockが回転する
        transform.Rotate(0, 0, 0.1f);

        //HPが0になったら実行
        if (_health <= 0)
        {
            //破壊のエフェクト
            Instantiate(explosion, transform.position, transform.rotation);
            //破壊される
            Destroy(this.gameObject);
        }
    }

    /// <summary>
    /// Blockを左に移動させる
    /// </summary>
    private void Move()
    {
        transform.position +=
            new Vector3(-moveSpeed, 0, 0) * Time.deltaTime;
       
    }

    //Blockが画面外に出たら消滅
    private void OffScreen()
    {
        if (this.transform.position.x < -10f)
        {
            Destroy(this.gameObject);
        }
    }

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

    /// <summary>
    /// あああ
    /// </summary>
    public void OnDestroy()
    {
        //_gameController.AddScore();
    }
}
