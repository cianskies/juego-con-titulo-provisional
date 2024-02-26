using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TipoPuerta
{
    Tienda,
    SalidaNivel,
    Tesoro,
    Secreto
}
public class Puerta : MonoBehaviour
{
    private bool _cerrada;

    [SerializeField]private TipoPuerta _tipo;

    private Animator _animator;
    public bool Cerrada { get { return _cerrada; } }
    public TipoPuerta Tipo { get { return _tipo; } }

    public void Awake()
    {
        _cerrada = true;
        _animator = GetComponent<Animator>();
    }
    public void Abrir()
    {
        _cerrada = false;
        _animator.SetBool("Cerrada", false);
        _animator.SetTrigger("Accion");  
    }
    public void Cerrar()
    {
        _cerrada = false;
        _animator.SetBool("Cerrada", true);
        _animator.SetTrigger("Accion");   
    }
}
