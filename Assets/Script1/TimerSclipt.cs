
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    //分
    [SerializeField]private int _minute;
    //秒
    [SerializeField]private float _seconds;
    //　前のUpdateの時の秒数
    private float _oldSeconds;
    //　タイマー表示用テキスト
    private Text _timerText;

    private bool _isTime;

    //EnemyのSponer
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

        //ゲーム起動時にObjectを非表示にする
        _enemySpawn1.SetActive(false);
        _upeer1.SetActive(false);
        _low1.SetActive(false);
        Debug.Log("作動");
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

        //毎フレームsecondsにTime.deltaTimeを足す
        _seconds += Time.deltaTime;
        //secondsが60秒以上になったら
        if (_seconds >= 60f)
        {
            //minuteに1を足す
            _minute++;
            //secondsを0に戻す
            _seconds = _seconds - 60;
        }
        //　値が変わった時だけテキストUIを更新
        if ((int)_seconds != (int)_oldSeconds)
        {
            _timerText.text = _minute.ToString("00") + ":" + ((int)_seconds).ToString("00");
        }
        _oldSeconds = _seconds;

    }
    public void Timer()
    {
        //5秒以上でEnemy1を出現
        if (_seconds >= 5.0f)
        {
            _enemySpawn1.SetActive(true);
            _upeer1.SetActive(true);
            _low1.SetActive(true);
            _isTime = true;
            Debug.Log("作動");

            //_enemy1.SetActive(true);
        }
        else if (_seconds >= 20f)
        {
            //_enemySpawn1.SetActive(false);

        }
    }

}
