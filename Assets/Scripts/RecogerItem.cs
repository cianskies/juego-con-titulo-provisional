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
    protected void Start()
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

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _sePuedeRecoger = true;
        }
    }
    protected void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _sePuedeRecoger = false;
        }
    }

    protected void OnEnable()
    {
       _controlesJugador.Enable();
    }
    protected void OnDisable()
    {
        _controlesJugador.Disable();
    }
}
