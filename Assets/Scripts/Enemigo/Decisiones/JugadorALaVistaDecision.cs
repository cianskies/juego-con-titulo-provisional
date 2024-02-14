using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorALaVistaDecision : DecisionFSM
{
    [SerializeField] private bool _mostrarDebug;
    [SerializeField] private LayerMask _obstaculoMask;

    
    private EnemigoFSM _enemigoFSM;

    private void Awake()
    {
        _enemigoFSM = GetComponent<EnemigoFSM>();
    }
    public override bool Decidir(EnemigoFSM enemigo)
    {
        return conozcoPosicionDeJugador(_enemigoFSM);
    }

    private bool conozcoPosicionDeJugador(EnemigoFSM enemigo)
    {
        
        if(_enemigoFSM.Jugador!=null) {
            
            Vector3 direccionAlJugador=enemigo.Jugador.position-transform.position;
            RaycastHit2D hit2D = Physics2D.Raycast(transform.position, direccionAlJugador.normalized,
                direccionAlJugador.magnitude,_obstaculoMask);
            if(hit2D.collider == null)
            {

                return true;
            }
        }
        return false;
        
    }

    private void OnDrawGizmos()
    {
        if(_mostrarDebug&&_enemigoFSM!=null&&_enemigoFSM.Jugador!=null)
        {
            Gizmos.color=conozcoPosicionDeJugador(_enemigoFSM)?Color.green:Color.red;
            Gizmos.DrawLine(transform.position, _enemigoFSM.Jugador.position);
        }
    }
}
