using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawn : MonoBehaviour
{
    [SerializeField] GameObject _bossPrefab;
    
    void Start()
    {
        Instantiate(_bossPrefab,transform.position,transform.rotation);
    }

    void Update()
    {
        
    }
}
