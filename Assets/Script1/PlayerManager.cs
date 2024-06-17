using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //�v���C���[�̈ړ����x
    [SerializeField] int moveSpeed = 5;

    float _interval = 0;

    //Bullet�����̃C�����[�o��
    [SerializeField] float _intervalMax = 1;

    //player�̈ړ��͈�
    [SerializeField] Transform _leftPosition;
    [SerializeField] Transform _rightPosition;
    [SerializeField] Transform _upperPosition;
    [SerializeField] Transform _lowerPosition;

    //GameController���擾
    public GameController _gameController;

    //Player�̍ő�HP
    float _health = 100f;
    public float HP => _health;

    //�Q�[���I�u�W�F�N�g���擾
    public GameObject bulletPrefab;
    public GameObject Muzzle1;
    public GameObject Muzzle2;

    public GameObject explosion;

    //
    HealthGuage _healthGuage;

    public void AddDamage(float damage)
    {
        _health -= damage;
        _healthGuage.TakeDamage(damage * .01f);
    }

    private void Start()
    {
        //HealthGuage���擾
        _healthGuage = GameObject.FindAnyObjectByType<HealthGuage>();
    }

    // ���N���b�N��������Bullet�����������
    void Update()
    {
        //Move();
        _interval += Time.deltaTime;
        //Move();
        if (_interval >= _intervalMax && Input.GetButton("Fire1"))
        {
            Instantiate(bulletPrefab, //�����������I�u�W�F�N�g
                        Muzzle1.transform.position, //�ʒu
                        transform.rotation); //��]
            _interval = 0;

            Instantiate(bulletPrefab, //�����������I�u�W�F�N�g
                        Muzzle2.transform.position, //�ʒu
                        transform.rotation); //��]
            _interval = 0;

        }
        Move();

        if (_health <= 0)
        {
            //�j��̃G�t�F�N�g
            Instantiate(explosion, transform.position, transform.rotation);
            _gameController.GameOver();
            Destroy(this.gameObject);
        }
    }



    //�v���C���[���ړ�������֐�
    private void Move()
    {
        //�L�[�̓��͒l���擾
        float x = Input.GetAxisRaw("Horizontal") * moveSpeed;
        float y = Input.GetAxisRaw("Vertical") * moveSpeed;
        if (transform.position.x < _leftPosition.position.x && x < 0)
        {
            x = 0;
        }
        if (transform.position.x > _rightPosition.position.x && x > 0)
        {
            x = 0;
        }
        if (transform.position.y > _upperPosition.position.y && y > 0)
        {
            y = 0;
        }
        if (transform.position.y < _lowerPosition.position.y && y < 0)
        {
            y = 0;
        }

        //�擾�������͒l�𔽉f������
        transform.position += new Vector3(x, y, 0) * Time.deltaTime;
    }

}
