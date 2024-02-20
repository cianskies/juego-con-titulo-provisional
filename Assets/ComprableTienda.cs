using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class ComprableTienda : RecogerItem
{
    // Start is called before the first frame update
  
    [SerializeField]private float _valor;

    private TextoItem _precioItem;
    private readonly Color _colorPordefecto=Color.white;

    public float Valor { get { return _valor; } set { _valor = value; } }
    public override void Awake()
    {
        base.Awake();
        MostrarPrecio(_colorPordefecto);
    }
    public override void Recoger()
    {

        if (sePuedeComprar()&& _sePuedeRecoger)
        {

                Debug.Log("Compraste un item");
                _item.Recoger();
                Destroy(gameObject);
            Destroy(_precioItem.gameObject);
            NivelManager.Instancia.StatsJugador.GastarDinero(_valor);

        }

    }
    private bool sePuedeComprar()
    {
        return NivelManager.Instancia.StatsJugador.GetDinero() >= _valor;
    }
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        Color colorPrecio = _colorPordefecto;
        if (sePuedeComprar())
        {
             colorPrecio= Color.green;
        }
        else
        {
            colorPrecio = Color.red;
        }
        if (_precioItem != null)
        {
            Destroy(_precioItem.gameObject);
            MostrarPrecio(colorPrecio);
        }

        base.OnTriggerEnter2D(collision);
    }
    public override void OnTriggerExit2D(Collider2D collision)
    {
        if (_precioItem != null)
        {
            Destroy(_precioItem.gameObject);
            MostrarPrecio(_colorPordefecto);
        }

        
        base.OnTriggerExit2D(collision);
    }
    private void MostrarPrecio(Color color)
    {

        Vector3 posicion=new Vector3(0,-1,0);
        _precioItem = ItemTextoManager.Instancia.MostrarMensaje($"{_valor}€", transform.position+posicion, color);
    }
}
