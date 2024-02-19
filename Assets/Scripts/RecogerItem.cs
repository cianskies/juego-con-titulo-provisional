using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecogerItem : MonoBehaviour
{
    [SerializeField] protected ItemData _item;
    

    private ControlesJugador _controlesJugador;

    protected bool _sePuedeRecoger;

    private void Awake()
    {
        _controlesJugador=new ControlesJugador();
    }
    private void Start()
    {
        _controlesJugador.Acciones.Recoger.performed += ctx => Recoger();
    }
    public virtual void Recoger()
    {
        if(_sePuedeRecoger)
        {
            _item.Recoger();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _sePuedeRecoger = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _sePuedeRecoger = false;
        }
    }

    private void OnEnable()
    {
       _controlesJugador.Enable();
    }
    private void OnDisable()
    {
        _controlesJugador.Disable();
    }
}
