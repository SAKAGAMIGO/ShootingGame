using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    //Blockの移動速度
    [SerializeField] float moveSpeed;

    //爆発のエフェクト
    public GameObject explosion;

    //Blockの最大HP
    float _health = 900f;
    public float HP => _health;

    //ダメージを与える
    public void AddDamage(float damage)
    {
        _health -= damage;
    }

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        OffScreen();
        //Blockが回転する
        transform.Rotate(0, 0, 1);

        //HPが0になったら実行
        if (_health <= 0)
        {
            //破壊のエフェクト
            Instantiate(explosion, transform.position, transform.rotation);
            //破壊される
            Destroy(this.gameObject);
        }
    }

    //Blockを左に移動させる
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
}
