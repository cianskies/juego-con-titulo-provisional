using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaScript : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] protected Transform _posicionDisparo;
    [SerializeField] protected Arma _arma;

    public Arma Arma { get { return _arma; } set { _arma = value; } }
    private int _hitAnim = Animator.StringToHash("Hit");
    private Animator _animator;


    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    public void AnimarHit()
    {
        _animator.SetTrigger(_hitAnim);
    }
    public virtual void UsarArma()
    {

    }
}
