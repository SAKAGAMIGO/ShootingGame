using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn2 : MonoBehaviour
{

    //ゲームオブジェクトを取得
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject upeer;
    [SerializeField] GameObject low;

    [SerializeField] float interval;
    float timer;

    void Start()
    {
        //Spawnを1秒間隔で実行
    }

    void Update()
    {
        timer += Time.deltaTime;

        if(timer > interval)
        {
            Spawn();
            timer = 0;
        }
    }

    //EnemyをUpeerとLowの間でランダムに生成
    private void Spawn()
    {
        //ランダムなx軸を取得
        Vector2 randomPos = new Vector2(Random.Range(upeer.transform.position.x, low.transform.position.x), Random.Range(upeer.transform.position.y, low.transform.position.y));
        GameObject _enemy = Instantiate(enemyPrefab);
        _enemy.transform.position = randomPos;
    }
}
