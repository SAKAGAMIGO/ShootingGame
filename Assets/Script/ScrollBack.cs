using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBack : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //�X�N���[������X�s�[�h
        this.transform.Translate(-0.02f,0,0);
    }
}
