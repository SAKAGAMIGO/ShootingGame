using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawn : MonoBehaviour
{
    [SerializeField] GameObject _bossPrefab;
    [SerializeField] GameObject _bossSpawnPos;

    [SerializeField] float _interval;
    float timer;

    void Start()
    {
      
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > _interval)
        {
            Spawn();
            timer = 0;
        }
    }

    //BossEnemy
    private void Spawn()
    {
        GameObject _enemy = Instantiate(_bossPrefab);
        _enemy.transform.position = _bossSpawnPos.transform.position;
    }
}
