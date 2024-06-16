using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HealthGuage : MonoBehaviour
{

    //緑色のバー
    [SerializeField] private Image healthImage;
    //赤色のバー
    [SerializeField] private Image burnImage;

    //HPが減る時間
    public float duration = 0.5f;
    //最大HP
    public float currentHP = 100f;
    //バーが減る量
    public float _damage = 10f;
    //バーが揺れる強さ
    public float strength = 20f;
    //バーが揺れる強さ
    public int vibrate = 100;

    public void SetGuage(float targetRate)
    {
        healthImage.DOFillAmount(targetRate, duration).OnComplete(() =>
        {
            burnImage.DOFillAmount(targetRate, duration * 0.5f).SetDelay(0.5f);
        });
        transform.DOShakePosition(duration * 0.5f, strength, vibrate);
        currentHP = targetRate;
    }

    //HPが減るプログラム
    public void TakeDamage(float rate)
    {
        SetGuage(currentHP - rate);
    }


    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (!collision.gameObject.CompareTag("Player"))
    //    {
    //        TakeDamage(_damage);
    //    }
    //}
}
