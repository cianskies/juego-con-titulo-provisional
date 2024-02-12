using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    public bool Cerrada;

    private Animator _animator;

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
