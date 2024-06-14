using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet2 : MonoBehaviour
{

    //Bullet�̃X�s�[�h
    public int bulletSpeed = 8;

    void Update()
    {
        Move();
        OffScreen();
    }

    //Bullet�����ɔ�΂�
    private void Move()
    {
        transform.position +=
            new Vector3(-bulletSpeed, 0, 0) * Time.deltaTime;
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
            //Player�Ƀ_���[�W��^����
            collision.gameObject.GetComponent<PlayerManager>().AddDamage(30f);
            //���̃I�u�W�F�N�g���j�󂳂��
            Destroy(this.gameObject);

        }
    }
}
