using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBack : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        //スクロールするスピード
        this.transform.Translate(-0.02f,0,0);
    }
}
