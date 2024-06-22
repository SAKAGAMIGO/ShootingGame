using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn2 : MonoBehaviour
{

    //ゲームオブジェクトを取得
    [SerializeField] GameObject _enemyPrefab;
    [SerializeField] GameObject _upeer;
    [SerializeField] GameObject _low;

    [SerializeField] float _interval;
    float timer;

    void Start()
    {
        //Spawnを1秒間隔で実行
    }

    void Update()
    {
        timer += Time.deltaTime;

        if(timer > _interval)
        {
            Spawn();
            timer = 0;
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
