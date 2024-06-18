using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager1 : MonoBehaviour
{
    //Enemy�̈ړ����x
    [SerializeField] int moveSpeed ;

    //�Q�[���I�u�W�F�N�g���擾
    public GameObject bulletPrefab;
    public GameObject Muzzle;

    //�����̃G�t�F�N�g
    public GameObject explosion;

    //Enemy�̍ő�HP
    float _health = 100f;
    public float HP => _health;

    //GameController�擾
    GameController _gameController;

    //�_���[�W��^����
    public void AddDamage(float damage)
    {
        _health -= damage;
    }


    //Enemy������������EnemyBullet�����������
    private void Start()
    {
        _gameController = GameObject.Find("GameController").GetComponent<GameController>();
        Shot();
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

    //Bullet�𐶐�
    private void Shot()
    {
        GameObject _bullet = Instantiate(bulletPrefab);
        _bullet.transform.position = Muzzle.transform.position;
    }

    //Player�ɓ�����������s
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Player�Ƀ_���[�W��^����
            collision.gameObject.GetComponent<PlayerManager>().AddDamage(10f);
            //�j�󂳂��
            Destroy(this.gameObject);
            //�j��̃G�t�F�N�g
            Instantiate(explosion, transform.position, transform.rotation);
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            _health -= 100f;
        }
    }

    public void OnDestroy()
    {
        //_gameController.AddScore();
    }
}
