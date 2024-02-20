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
    public bool Cerrada;
    [SerializeField]private TipoPuerta _tipo;

    private Animator _animator;

    public TipoPuerta Tipo { get { return _tipo; } }

    public void Awake()
    {
        Cerrada=true;
        _animator = GetComponent<Animator>();
    }
    public void Abrir()
    {
 
            Cerrada = false;
            _animator.SetBool("Cerrada", false);
            _animator.SetTrigger("Accion");
        
    }
    public void Cerrar()
    {
        
            Cerrada = false;
            _animator.SetBool("Cerrada", true);
            _animator.SetTrigger("Accion");
        
    }
}
