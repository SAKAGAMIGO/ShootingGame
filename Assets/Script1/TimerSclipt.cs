
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

        if (_minute >= 1 && _seconds >= 6)
        {
            _audio1 = GameObject.Find("GameController").GetComponent<AudioSource>();
            _audio1.Stop();
        }
    }
    public IEnumerator Timer()
    {
        //3秒暇
        yield return new WaitForSeconds(2);
        //Enemy1が10秒間出現
        _enemySpawn1.SetActive(true);
        //Enemy2が10秒間出現
        _enemySpawn2.SetActive(true);
        //Bossが65秒後に出現
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
