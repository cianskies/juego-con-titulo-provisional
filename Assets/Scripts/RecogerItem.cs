using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecogerItem : MonoBehaviour
{
    [SerializeField] private ItemData _item;

    private ControlesJugador _controlesJugador;

    private bool _itemAlAlcance;

    private void Awake()
    {
        _controlesJugador=new ControlesJugador();
    }
    private void Start()
    {
        _controlesJugador.Acciones.Recoger.performed += ctx => Recoger();
    }
    private void Recoger()
    {
        if(_itemAlAlcance)
        {
            _item.Recoger();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _itemAlAlcance = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _itemAlAlcance = false;
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