
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

    public GameObject _enemySpawn1;
    public GameObject _enemySpawn2;
    public GameObject _enemySpawn3;
    public GameObject _blockSpawn1;
    public GameObject _blockSpawn2;
    public GameObject _bossSpawn;

    AudioSource _audio1;
    AudioSource _audio2;


    void Start()
    {
        StartCoroutine(Timer());

        _minute = 0;
        _seconds = 0f;
        _oldSeconds = 0f;
        _timerText = GetComponentInChildren<Text>();

        _enemySpawn1.SetActive(false);
        _enemySpawn2.SetActive(false);
        _enemySpawn3.SetActive(false);
        _blockSpawn1.SetActive(false);    
        _blockSpawn2.SetActive(false);
        _bossSpawn.SetActive(false);
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

        if (_minute >= 1 && _seconds >= 6)
        {
            _audio1 = GameObject.Find("GameController").GetComponent<AudioSource>();
            _audio1.Stop();
        }
    }
    public IEnumerator Timer()
    {
        //3�b��
        yield return new WaitForSeconds(2);
        //Enemy1��10�b�ԏo��
        _enemySpawn1.SetActive(true);
        //Enemy2��10�b�ԏo��
        _enemySpawn2.SetActive(true);
        //Boss��65�b��ɏo��
        _bossSpawn.SetActive(true);
        yield return new WaitForSeconds(20);
        _enemySpawn1.SetActive(false);
        _enemySpawn2.SetActive(false);

        yield return new WaitForSeconds(1);

        _enemySpawn3.SetActive(true);
        yield return new WaitForSeconds(1);
        _enemySpawn3.SetActive(false);

        yield return new WaitForSeconds(1);

        _enemySpawn3.SetActive(true);
        yield return new WaitForSeconds(1);
        _enemySpawn3.SetActive(false);

        yield return new WaitForSeconds(1);

        _enemySpawn3.SetActive(true);
        yield return new WaitForSeconds(1);
        _enemySpawn3.SetActive(false);

        yield return new WaitForSeconds(1);

        _enemySpawn3.SetActive(true);
        yield return new WaitForSeconds(1);
        _enemySpawn3.SetActive(false);

        yield return new WaitForSeconds(1);

        _blockSpawn1.SetActive(true);
        _blockSpawn2.SetActive(true);
        _enemySpawn1.SetActive(true);
        yield return new WaitForSeconds(20);
        _enemySpawn1.SetActive(false);

        yield return new WaitForSeconds(1);

        _enemySpawn1.SetActive(true);
        _enemySpawn2.SetActive(true);
        yield return new WaitForSeconds(10);
        _enemySpawn1.SetActive(false);
        _enemySpawn2.SetActive(false);
        _blockSpawn1.SetActive(false);
        _blockSpawn2.SetActive(false);
    }
}
