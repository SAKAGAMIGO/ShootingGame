using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HealthGuage : MonoBehaviour
{

    //�ΐF�̃o�[
    [SerializeField] private Image healthImage;
    //�ԐF�̃o�[
    [SerializeField] private Image burnImage;

    //HP�����鎞��
    public float duration = 0.5f;
    //�ő�HP
    public float currentHP = 100f;
    //�o�[�������
    public float _damage = 10f;
    //�o�[���h��鋭��
    public float strength = 20f;
    //�o�[���h��鋭��
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

    //HP������v���O����
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
