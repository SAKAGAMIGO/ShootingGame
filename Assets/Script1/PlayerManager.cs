using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using Cinemachine;
using Unity.VisualScripting;


public class PlayerManager : MonoBehaviour
{
    //�v���C���[�̈ړ����x
    [SerializeField] int _moveSpeed = 5;

    //Bullet�����̃C���^�[�o��
    float _interval = 0;

    //Bullet    �̐����C���^�[�o���̍ő�l
    [SerializeField] float _intervalMax = 1;

    //player�̈ړ��͈�
    [SerializeField] Transform _leftPosition;
    [SerializeField] Transform _rightPosition;
    [SerializeField] Transform _upperPosition;
    [SerializeField] Transform _lowerPosition;

    //GameController���擾
    [SerializeField] GameController _gameController;

    //Player�̍ő�HP
    float _health = 100f;
    public float HP => _health;

    //�Q�[���I�u�W�F�N�g���擾
    public GameObject bulletPrefab;
    public GameObject Muzzle1;
    public GameObject Muzzle2;

    //�����G�t�F�N�g
    public GameObject explosion;

    //Player�̗̑�
    HealthGuage _healthGuage;
    AudioSource _audioSource;

    //SpriteRenderer���擾
    SpriteRenderer _sp;

    //�_�ł̊Ԋu
    [SerializeField] float _flashInterval;

    //�_�ł�����Ƃ��̃��[�v�J�E���g
    [SerializeField] int _loopCount;

    //�����������ǂ����̃t���O
    bool _isHit;

    //�R���C�_�[���I���I�t���邽�߂�Collider2D
    BoxCollider2D _bCollider;
    CapsuleCollider2D _cCollider;

    public void AddDamage(float damage)
    {
        _health -= damage;
        _healthGuage.TakeDamage(damage);
        var impulseSource = GetComponent<CinemachineImpulseSource>();
        impulseSource.GenerateImpulse();

    }

    private void Start()
    {
        //HealthGuage���擾
        _healthGuage = GameObject.FindAnyObjectByType<HealthGuage>();
        _audioSource = GameObject.Find("GameController").GetComponent<AudioSource>();
        //Setup���ɍő�HP���擾
        _healthGuage.Setup(_health);

        //SpriteRenderer,BoxCollider2D,CapsuleCollider2D���i�[
        _sp = GetComponent<SpriteRenderer>();
        _bCollider = GameObject.FindAnyObjectByType<BoxCollider2D>();
        _cCollider = GameObject.FindAnyObjectByType<CapsuleCollider2D>();
    }

    // ���N���b�N��������Bullet�����������
    void Update()
    {
        _interval += Time.deltaTime;
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
            //BGM���~�߂�
            _audioSource.Stop();
            //�j��̃G�t�F�N�g
            Instantiate(explosion, transform.position, transform.rotation);
            //GameOver�𔻒�
            _gameController.GameOver();
            //Collider���I�t�ɂ���
            _bCollider.enabled = false;
            _cCollider.enabled = false;
            //Player��Destroy ������
            Destroy(gameObject);
        }
    }

    //�v���C���[���ړ�������֐�
    private void Move()
    {
        //�L�[�̓��͒l���擾
        float x = Input.GetAxisRaw("Horizontal") * _moveSpeed;
        float y = Input.GetAxisRaw("Vertical") * _moveSpeed;
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

    //���������Ƃ��̏���
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Hit���Ă����珈�����s��Ȃ�
        if (_isHit)
        {
            return;
        }
        //�R���[�`�����J�n
        StartCoroutine(_hit());
    }

    //�_�ł����鏈��
    IEnumerator _hit()
    {
        //������t���O��true�ɕύX�i�������Ă����ԁj
        _isHit = true;

        _bCollider.enabled = false;
        _cCollider.enabled = false;

        //�_�Ń��[�v�J�n
        for (int i = 0; i < _loopCount; i++)
        {
            //flashInterval�҂��Ă���
            yield return new WaitForSeconds(_flashInterval);
            //spriteRenderer���I�t
            _sp.enabled = false;
            //flashInterval�҂��Ă���
            yield return new WaitForSeconds(_flashInterval);
            //spriteRenderer���I��
            _sp.enabled = true;
        }

        //�_�Ń��[�v���������瓖����t���O��false(�������ĂȂ����)
        _isHit = false;
        _bCollider.enabled = true;
        _cCollider.enabled = true;
    }
}
