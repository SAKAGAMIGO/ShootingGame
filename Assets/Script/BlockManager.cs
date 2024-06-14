using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    //Block�̈ړ����x
    [SerializeField] float moveSpeed;

    //�����̃G�t�F�N�g
    public GameObject explosion;

    //Block�̍ő�HP
    float _health = 900f;
    public float HP => _health;

    //�_���[�W��^����
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
        //Block����]����
        transform.Rotate(0, 0, 1);

        //HP��0�ɂȂ�������s
        if (_health <= 0)
        {
            //�j��̃G�t�F�N�g
            Instantiate(explosion, transform.position, transform.rotation);
            //�j�󂳂��
            Destroy(this.gameObject);
        }
    }

    //Block�����Ɉړ�������
    private void Move()
    {
        transform.position +=
            new Vector3(-moveSpeed, 0, 0) * Time.deltaTime;
       
    }

    //Block����ʊO�ɏo�������
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
            //Player�Ƀ_���[�W��^����
            collision.gameObject.GetComponent<PlayerManager>().AddDamage(10f);
            //�j��̃G�t�F�N�g
            Instantiate(explosion, transform.position, transform.rotation);
            //�j�󂳂��
            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            _health -= 100f;
        }
    }
}
