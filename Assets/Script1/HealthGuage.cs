using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HealthGuage : MonoBehaviour
{

    //�ΐF�̃o�[
    [SerializeField] private Image _health;
    //�ԐF�̃o�[
    [SerializeField] private Image _burn;

    //HP�����鎞��
    public float _duration = 0.5f;
    //�ő�HP
    private float _currentHP = 100f;
    //�o�[�������
    public float _damage = 10f;
    //�o�[���h��鋭��
    public float _strength = 20f;
    //�o�[���h��鋭��
    public int _vibrate = 100;

    private float _maxHp;

    public void Setup(float hp)
    {
        _currentHP = hp;
        _maxHp = hp;
    }

    public void SetGuage(float targetRate)
    {
        _health.DOFillAmount(targetRate, _duration).OnComplete(() =>
        {
            _burn.DOFillAmount(targetRate, _duration * 0.5f).SetDelay(0.5f);
        });
        transform.DOShakePosition(_duration * 0.5f, _strength, _vibrate);
    }

    //HP������v���O����
    public void TakeDamage(float rate)
    {
        SetGuage((_currentHP - rate) / _maxHp);
        _currentHP -= rate;
        Debug.Log($"Rate: {rate}, Current: {_currentHP}, Max: {_maxHp}");
    }
}
