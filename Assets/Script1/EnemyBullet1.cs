using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet1 : MonoBehaviour
{
    //Bullet�̃X�s�[�h
    public int _bulletSpeed = 8;

   //    public GameController explosion2;

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
           // Instantiate(explosion2,transform.position,transform.rotation);
            //�v���C���[�Ƀ_���[�W��^����
            collision.gameObject.GetComponent<PlayerManager>().AddDamage(10f);
            //���̃I�u�W�F�N�g���j�󂳂��
            Destroy(this.gameObject);

        }
    }
}
