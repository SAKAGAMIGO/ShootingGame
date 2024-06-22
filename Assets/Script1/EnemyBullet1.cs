using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet1 : MonoBehaviour
{
    //Bullet�̃X�s�[�h
    public int _bulletSpeed = 8;

    public GameObject _explosion;

    void Update()
    {
        Move();
        OffScreen();
    }

    //Bullet�����ɔ�΂�
    private void Move()
    {
        transform.position +=
            new Vector3(-_bulletSpeed, 0, 0) * Time.deltaTime;
    }

    //Bullet����ʊO�ɏo�������
    private void OffScreen()
    {
        if (this.transform.position.x < -10)
        {
            Destroy(this.gameObject);
        }
    }

    //Bullet��Player�ɂԂ���������s
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //�v���C���[�Ƀ_���[�W��^����
            collision.gameObject.GetComponent<PlayerManager>().AddDamage(10f);
            //�j��̃G�t�F�N�g
            Instantiate(_explosion);
            //���̃I�u�W�F�N�g���j�󂳂��
            Destroy(this.gameObject);
        }
    }
}
