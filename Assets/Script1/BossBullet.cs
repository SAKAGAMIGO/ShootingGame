using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet1 : MonoBehaviour
{
    //Bullet�̃X�s�[�h
    public int _bulletSpeed = 8;

    void Update()
    {
        Move();
        OffScreen();
    }

    /// <summary>
    /// Bullet�����ɔ�΂�
    /// </summary>
    private void Move()
    {
        transform.position +=
            new Vector3(-_bulletSpeed, 0, 0) * Time.deltaTime;
    }

    /// <summary>
    /// Bullet����ʊO�ɏo�������
    /// </summary>
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
            //���̃I�u�W�F�N�g���j�󂳂��
            Destroy(this.gameObject);
        }
    }
}
