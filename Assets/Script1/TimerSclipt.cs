
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




    void Start()
    {
        //StartCoroutine(Timer());

        _minute = 0;
        _seconds = 0f;
        _oldSeconds = 0f;
        _timerText = GetComponentInChildren<Text>();
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
    //public IEnumerator Timer()
    //{


    ////3秒暇
    //yield return new WaitForSeconds(2);
    //    //Enemy1が10秒間出現
    //    _enemySpawn1.SetActive(true);
    //    //Enemy2が10秒間出現
    //    _enemySpawn2.SetActive(true);
    //    //Bossが65秒後に出現
    //    _bossSpawn.SetActive(true);
    //    yield return new WaitForSeconds(20);
    //    _enemySpawn1.SetActive(false) ;
    //    _enemySpawn2.SetActive(false);

    //    yield return new WaitForSeconds(1);

    //    _enemySpawn3.SetActive(true);
    //    yield return new WaitForSeconds(1);
    //    _enemySpawn3.SetActive(false) ;

    //    yield return new WaitForSeconds(1);

    //    _enemySpawn3.SetActive(true) ;
    //    yield return new WaitForSeconds(1);
    //    _enemySpawn3.SetActive(false) ;

    //    yield return new WaitForSeconds(1);

    //    _enemySpawn3.SetActive(true);
    //    yield return new WaitForSeconds(1);
    //    _enemySpawn3.SetActive(false);

    //    yield return new WaitForSeconds(1);

    //    _enemySpawn3.SetActive(true);
    //    yield return new WaitForSeconds(1);
    //    _enemySpawn3.SetActive(false);

    //    yield return new WaitForSeconds(1);

    //    _blockSpawn.SetActive(true);
    //    _blockSpawnSmall.SetActive(true);
    //    _enemySpawn1.SetActive(true);
    //    yield return new WaitForSeconds(20);
    //    _enemySpawn1.SetActive(false);

    //    yield return new WaitForSeconds(1);

    //    _enemySpawn1.SetActive(true);
    //    _enemySpawn2.SetActive(true) ;
    //    yield return new WaitForSeconds(10);
    //    _enemySpawn1.SetActive(false);
    //    _enemySpawn2.SetActive(false) ;
    //    _blockSpawn.SetActive(false);
    //    _blockSpawnSmall.SetActive(false);
    //}
}
