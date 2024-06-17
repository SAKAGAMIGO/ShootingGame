using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Enemy�̈ړ����x
    [SerializeField] int moveSpeed;


    //�����̃G�t�F�N�g
    public GameObject explosion;

    //Enemy�̍ő�HP
    float _health = 200f;
    public float HP => _health;

    //�_���[�W��^����
    public void AddDamage(float damage)
    {
        _health -= damage;
    }


    void Update()
    {
        Move();
        OffScreen();
        //HP��0�ɂȂ�������s
        if (_health <= 0)
        {
            //�j��̃G�t�F�N�g
            Instantiate(explosion, transform.position, transform.rotation);
            //�j�󂳂��
            Destroy(this.gameObject);
        }
    }

    //Enemy�����Ɉړ�������
    private void Move()
    {
        transform.position +=
            new Vector3(-moveSpeed, 0, 0) * Time.deltaTime;
    }

    //Enemy����ʊO�ɏo�������
    private void OffScreen()
    {
        if (this.transform.position.x < -10f)
        {
            Destroy(this.gameObject);
        }
    }

    //Player�ɓ�����������s
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
