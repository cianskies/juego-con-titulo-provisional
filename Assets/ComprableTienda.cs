using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class ComprableTienda : RecogerItem
{
    // Start is called before the first frame update
  
    [SerializeField]private float _valor;

    public float Valor { get { return _valor; } set { _valor = value; } }
    public override void Recoger()
    {
        if (sePuedeComprar())
        {
            if (_sePuedeRecoger)
            {
                _item.Recoger();
                Destroy(gameObject);
            }
            NivelManager.Instancia.StatsJugador.GastarDinero(_valor);
        }

    }
    private bool sePuedeComprar()
    {
        return NivelManager.Instancia.StatsJugador.GetDinero() >= _valor;
    }

}
