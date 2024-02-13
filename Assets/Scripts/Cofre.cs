using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cofre : MonoBehaviour
{
    [Header("Posicion Item")]
    [SerializeField] private Transform _posicionItem;

    [SerializeField] private bool _ContieneItemEspecifico;
    [SerializeField] private GameObject _ItemEspecifico;


    private bool _cofreAbierto;

    private int _animAbrirCofre = Animator.StringToHash("AbrirCofre");
    private Animator _animator;


    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void MostrarObjeto()
    {
        if(_ContieneItemEspecifico)
        {
            Instantiate(_ItemEspecifico,transform.position,Quaternion.identity,_posicionItem);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!_cofreAbierto&&(collision.CompareTag("Player")))
        {
            _animator.SetTrigger(_animAbrirCofre);
            MostrarObjeto();
            _cofreAbierto = true;
        }
    }
}
