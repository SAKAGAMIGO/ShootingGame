using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossManager : MonoBehaviour
{
   // private Vector3 move = Vector3(5,0,0);
    //Enemyの最大HP
    float _health = 20000f;
    public float HP => _health;

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
        //HPが0になったら実行
        if (_health <= 0)
        {
            //破壊のエフェクト
            //Instantiate(explosion, transform.position, transform.rotation);
            //破壊される
            Destroy(this.gameObject);
            //ClearSceneに跳ぶ
            SceneManager.LoadScene("ClearScene");
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
