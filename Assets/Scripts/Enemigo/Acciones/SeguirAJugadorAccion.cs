using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirAJugadorAccion : AccionFSM
{

    private EnemigoFSM _enemigoFSM;
    [SerializeField] private float _velocidad;
    private Vector3 _nuevaPosicion;

    public override void EjecutarAccionFSM()
    {
        if (_nuevaPosicion != Vector3.zero)
        {
            // Mueve al enemigo hacia la nueva posici�n
            transform.position = Vector3.MoveTowards(transform.position, _nuevaPosicion, _velocidad * Time.deltaTime);
            // Limpia la variable de nueva posici�n para evitar seguir movi�ndose hacia ella en las siguientes actualizaciones
            _nuevaPosicion = Vector3.zero;
        }

    }
    private void Awake()
    {
        _enemigoFSM = GetComponent<EnemigoFSM>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_enemigoFSM.Jugador != null)
        {
            // Calcula la nueva posici�n hacia la que se mover� el enemigo
            _nuevaPosicion = _enemigoFSM.Jugador.position;
        }
    }
}
