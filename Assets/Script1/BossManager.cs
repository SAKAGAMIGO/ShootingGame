using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossManager : MonoBehaviour
{
    //GameObject��ǉ�
    public GameObject _centerCore;
    public GameObject _leftCore;
    public GameObject _rightCore;
    public GameObject _decoration;

    //Core�̐�
    public int _count;

    //
    public GameObject _bossPrefab;

    //Boss�̈ړ����x
    public int _speed = 5;

    Vector3 movePosition;

    GameController _gameController;

    //SpriteRenderer���擾
    SpriteRenderer _sp;

    //�_�ł̊Ԋu
    [SerializeField] float _flashInterval;

    //�_�ł�����Ƃ��̃��[�v�J�E���g
    [SerializeField] int _loopCount;

    //�����������ǂ����̃t���O
    bool _isHit;

    void Start()
    {
        _gameController = GameObject.Find("GameController").GetComponent<GameController>();
        movePosition = moveRandomPosition();

        //SpriteRenderer,BoxCollider2D,CapsuleCollider2D���i�[
        _sp = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (movePosition == _bossPrefab.transform.position)
        {
            movePosition = moveRandomPosition();
        }
        this._bossPrefab.transform.position = Vector3.MoveTowards(_bossPrefab.transform.position, movePosition, _speed * Time.deltaTime);

        if (_count == 0)
        {
            //AudioSource audio = this.gameObject.GetComponent<AudioSource>();
            //audio.Play();
            _decoration.SetActive(false);
             _sp.enabled = false;
            _gameController.finish();


        }

    }

    private Vector3 moveRandomPosition()
    {
        Vector3 randomPosi = new Vector3(Random.Range(-7, 7), Random.Range(-4, 4), 5);
        return randomPosi;
    }

    public void Count()
    {
        _count--;
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
    }
}
