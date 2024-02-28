using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SeguirAJugadorAccion : AccionFSM
{

    private EnemigoFSM _enemigoFSM;
    [SerializeField] private float _velocidad;
    [SerializeField] private float _distanciaMinima;

    public override void EjecutarAccionFSM()
    {
        //Debug.Log("Hola");
        if (_enemigoFSM.Jugador != null)
        {
            float distanciaEntreEnemigoYJugador = Vector3.Distance(transform.position, _enemigoFSM.Jugador.position);
            if (distanciaEntreEnemigoYJugador>_distanciaMinima)
            {
                //Debug.Log("La distancia entre el jugador y el enemigo es de " + distanciaEntreEnemigoYJugador);
                Vector3 direccion = (_enemigoFSM.Jugador.position - transform.position).normalized;
                transform.Translate(direccion * (_velocidad * Time.deltaTime));
            }
        }
    }
    


    private void Awake()
    {
        _enemigoFSM = GetComponent<EnemigoFSM>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
