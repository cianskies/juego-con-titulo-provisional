using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaScript : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] protected Transform _posicionDisparo;
    [SerializeField] protected Arma _arma;
    private ArmaPersonaje _personaje;

    public ArmaPersonaje PersonajeArmaParent { get { return _personaje; } set { _personaje = value; } }
    public Arma Arma { get { return _arma; } set { _arma = value; } }
    private int _hitAnim = Animator.StringToHash("Hit");
    private Animator _animator;
    


    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    public void AnimarHit()
    {
        if (_animator != null) {
            _animator.SetTrigger(_hitAnim);
        }
        
    }
    public virtual void UsarArma()
    {

    }
}
