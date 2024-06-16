using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn1 : MonoBehaviour
{

    //ゲームオブジェクトを取得
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject upeer;
    [SerializeField] GameObject low;


    void Start()
    {
        //Spawnを1秒間隔で実行
        InvokeRepeating("Spawn", 0.8f, 0.8f);
    }

    void Update()
    {

    }

    //Enemyを生成
    private void Spawn()
    {
        //ランダムなx軸を取得
        Vector2 randomPos = new Vector2(Random.Range(upeer.transform.position.x, low.transform.position.x), Random.Range(upeer.transform.position.y, low.transform.position.y));
        GameObject _enemy = Instantiate(enemyPrefab);
        _enemy.transform.position = randomPos;
    }
}
