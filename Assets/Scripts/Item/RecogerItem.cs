using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecogerItem : MonoBehaviour
{
    [SerializeField] protected ItemData _item;
    

    private ControlesJugador _controlesJugador;
    private TextoItem _textoCreadoItem;

    protected bool _sePuedeRecoger;
    public ItemData Item { get { return _item; } }

    public virtual void Awake()
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

    private void MostrarNombre()
    {
        Vector3 posicionTexto=new Vector3(0,1,0);
        Color color = Color.white;
        if(_item is Arma)
        {
            color = Color.yellow;
        }
        _textoCreadoItem=ItemTextoManager.Instancia.MostrarMensaje(_item.Nombre, transform.position + posicionTexto, color);

    }
    private void OcultarNombre()
    {
        if(_textoCreadoItem!=null)
        {

            Destroy(_textoCreadoItem.gameObject);
        }
    }
    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            MostrarNombre();
            _sePuedeRecoger = true;
        }
    }
    public virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OcultarNombre();
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
