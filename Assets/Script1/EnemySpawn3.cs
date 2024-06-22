using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn3 : MonoBehaviour
{
    //ゲームオブジェクトを取得
    [SerializeField] GameObject _enemyPrefab;
    [SerializeField] GameObject _upeer;
    [SerializeField] GameObject _low;

    private float _interval;

    private float _time = 0f;
  
    void Start()
    {
        _interval = 0.2f;
    }

    
    void Update()
    {
        

        _time += Time.deltaTime;

        if (_time > _interval)
        {
            GameObject enemy = Instantiate(_enemyPrefab,
                                           this.transform.position,
                                           transform.rotation);
            _time = 0f;
            Spawn();
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
