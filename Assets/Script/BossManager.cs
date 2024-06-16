using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
   // private Vector3 move = Vector3(5,0,0);
    //Enemy�̍ő�HP
    float _health = 20000f;
    public float HP => _health;

    public GameController _gameController;

    //�_���[�W��^����
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
        //HP��0�ɂȂ�������s
        if (_health <= 0)
        {
            //�j��̃G�t�F�N�g
            //Instantiate(explosion, transform.position, transform.rotation);
            //�j�󂳂��
            Destroy(this.gameObject);
            _gameController.GameClear();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Player�Ƀ_���[�W��^����
            collision.gameObject.GetComponent<PlayerManager>().AddDamage(10f);
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            _health -= 100f;
        }
    }
}
