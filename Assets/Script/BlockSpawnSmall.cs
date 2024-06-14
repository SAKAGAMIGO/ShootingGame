using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawnSmall : MonoBehaviour
{
    //ゲームオブジェクトを取得
    [SerializeField] GameObject smallBlockPrefab;
    [SerializeField] GameObject upeer;
    [SerializeField] GameObject low;

    void Start()
    {
        //Spawnを2秒間隔で実行
        InvokeRepeating("Spawn", 2f, 2f);
    }


    void Update()
    {

    }

    private void Spawn()
    {
        //ランダムなx軸を取得
        Vector2 randomPos = new Vector2(Random.Range(upeer.transform.position.x, low.transform.position.x), Random.Range(upeer.transform.position.y, low.transform.position.y));
        GameObject _enemy = Instantiate(smallBlockPrefab);
        _enemy.transform.position = randomPos;
    }
}
