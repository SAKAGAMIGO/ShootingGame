using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn3 : MonoBehaviour
{
    //ゲームオブジェクトを取得
    [SerializeField] GameObject _enemyPrefab;
    [SerializeField] GameObject _upeer;
    [SerializeField] GameObject _low;

    float _interval = 10f;

    float _timer = 1;

    void Start()
    {
        _interval = 0.2f;
    }
    
    void Update()
    {
        //Spawnを1秒間隔で実行
        _timer += Time.deltaTime;

        if (_timer > _interval)
        {
            Spawn();
            _timer = 0f;
        }

    }

    //EnemyをUpeerとLowの間でランダムに生成
    private void Spawn()
    {
        //ランダムなx軸を取得
        Vector2 randomPos = new Vector2(Random.Range(_upeer.transform.position.x, _low.transform.position.x), Random.Range(_upeer.transform.position.y, _low.transform.position.y));
        GameObject _enemy = Instantiate(_enemyPrefab);
        _enemy.transform.position = randomPos;

    }
}
