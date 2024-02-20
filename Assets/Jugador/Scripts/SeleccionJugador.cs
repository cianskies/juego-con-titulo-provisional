using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeleccionJugador : MonoBehaviour
{
    [SerializeField] private StatsJugador _configuracionJugador;

    public StatsJugador ConfiguracionJugador { get { return _configuracionJugador; } set { _configuracionJugador = value; } }

    private void OnMouseDown()
    {
        
    }
}
