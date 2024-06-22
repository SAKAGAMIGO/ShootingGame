using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    //GameController�̓��ꕨ:AddScore���g��
    GameController _gameController;
    //Bullet�̃X�s�[�h
    [SerializeField] int _bulletSpeed ;

    private void Start()
    {
        //�q�G�����L�[���Object���擾
        _gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    void Update()
    {
        Move();
        OffScreen();
    }

    //Bullet���E�ɔ�΂�
    private void Move()
    {
        transform.position += new Vector3(_bulletSpeed, 0, 0) * Time.deltaTime;
    }

    //Bullet����ʊO�ɏo�������
    private void OffScreen()
    {
        if(this.transform.position.x > 10)
        {
            Destroy(this.gameObject);
        }
    }

    //Bullet��Player�ȊO�ɂԂ���������s
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        { 
            Destroy(this.gameObject) ;
        }
    }
}
