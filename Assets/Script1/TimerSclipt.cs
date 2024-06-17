
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    //��
    [SerializeField]private int _minute;
    //�b
    [SerializeField]private float _seconds;
    //�@�O��Update�̎��̕b��
    private float _oldSeconds;
    //�@�^�C�}�[�\���p�e�L�X�g
    private Text _timerText;

    private bool _isTime;

    //Enemy��Sponer
    public GameObject _enemySpawn1;
    public GameObject _upeer1;
    public GameObject _low1;
    public GameObject _enemySpawn2;
    public GameObject _upeer2;
    public GameObject _low2;
    public GameObject _enemySpawn3;
    public GameObject _blockSpawn;
    public GameObject _upeer3;
    public GameObject _low3;
    public GameObject _blockSpawnSmall;
    public GameObject _uper4;
    public GameObject _low4;

    //public GameObject _enemy1;
    //public GameObject _enemy2;
    //public GameObject _enemy3;
    //public GameObject _block1;
    //public GameObject _block2;

    void Start()
    {
        _minute = 0;
        _seconds = 0f;
        _oldSeconds = 0f;
        _timerText = GetComponentInChildren<Text>();

        //�Q�[���N������Object���\���ɂ���
        _enemySpawn1.SetActive(false);
        _upeer1.SetActive(false);
        _low1.SetActive(false);
        Debug.Log("�쓮");
        _enemySpawn2.SetActive(false);
        _upeer2.SetActive(false);
        _low2.SetActive(false);
        _enemySpawn3.SetActive(false);
        _blockSpawn.SetActive(false);
        _upeer3.SetActive(false);
        _low3.SetActive(false);
        _blockSpawnSmall.SetActive(false);
        _uper4.SetActive(false);
        _low4.SetActive(false);

        //_enemy1.SetActive(false);
        //_enemy2.SetActive(false);
        //_enemy3.SetActive(false);
        //_block1.SetActive(false);
        //_block2.SetActive(false);
    }

    void Update()
    {

        //���t���[��seconds��Time.deltaTime�𑫂�
        _seconds += Time.deltaTime;
        //seconds��60�b�ȏ�ɂȂ�����
        if (_seconds >= 60f)
        {
            //minute��1�𑫂�
            _minute++;
            //seconds��0�ɖ߂�
            _seconds = _seconds - 60;
        }
        //�@�l���ς�����������e�L�X�gUI���X�V
        if ((int)_seconds != (int)_oldSeconds)
        {
            _timerText.text = _minute.ToString("00") + ":" + ((int)_seconds).ToString("00");
        }
        _oldSeconds = _seconds;

    }
    public void Timer()
    {
        //5�b�ȏ��Enemy1���o��
        if (_seconds >= 5.0f)
        {
            _enemySpawn1.SetActive(true);
            _upeer1.SetActive(true);
            _low1.SetActive(true);
            _isTime = true;
            Debug.Log("�쓮");

            //_enemy1.SetActive(true);
        }
        else if (_seconds >= 20f)
        {
            //_enemySpawn1.SetActive(false);

        }
    }

}
