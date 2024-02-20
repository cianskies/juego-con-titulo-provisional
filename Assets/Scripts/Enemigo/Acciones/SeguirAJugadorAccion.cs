using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirAJugadorAccion : AccionFSM
{

    private EnemigoFSM _enemigoFSM;
    [SerializeField] private float _velocidad;

    public override void EjecutarAccionFSM()
    {
        Debug.Log("Hola");
        if (_enemigoFSM.Jugador != null) { }


        Vector3 direccion = (_enemigoFSM.Jugador.position - transform.position).normalized;
        transform.Translate(direccion * (_velocidad * Time.deltaTime));
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
