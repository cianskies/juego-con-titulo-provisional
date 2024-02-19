using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectarJugadorAccion : AccionFSM
{
    [SerializeField] private bool _mostrarDebug;
    public override void EjecutarAccionFSM()
    {
        DetectarJugador();
    }

    [SerializeField] private float _radioDeteccionEnemigo;
    [SerializeField] private LayerMask _jugadorMask;

    private Collider2D[] _resultadosColisiones=new Collider2D[10];
    private EnemigoFSM _enemigoFSM;

    private void Awake()
    {
        _enemigoFSM=GetComponent<EnemigoFSM>();
    }
    private void DetectarJugador()
    {
        int numeroColisiones = Physics2D.OverlapCircleNonAlloc(transform.position,
            _radioDeteccionEnemigo, _resultadosColisiones, _jugadorMask);
        if (numeroColisiones > 0)
        {
            //Debug.Log("Conzco el transform de mi player");
            _enemigoFSM.Jugador = _resultadosColisiones[0].transform;

        }
        else
        {
            //Debug.Log("ya no conzco el transform de mi player");
            _enemigoFSM.Jugador = null;
        }
    }
    private void OnDrawGizmos()
    {
        if(_mostrarDebug)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position,_radioDeteccionEnemigo);
        }
    }
}
