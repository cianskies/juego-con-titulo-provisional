using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaEnemigo : ArmaPersonaje
{
    [SerializeField] private ArmaScript _armaPorDefecto;


    public ArmaScript Arma { get { return _arma; } }

    protected override void Awake()
    {
        CrearArma();
        
    }
    
    private void Update()
    {
        if (NivelManager.Instancia.JugadorPosicion != null)
        {
            //Debug.Log("Rotar a player");
            Vector3 direccionAJugador = NivelManager.Instancia.JugadorPosicion.transform.position-transform.position;
            RotarPosicionArma(direccionAJugador);
        }
    }

    private void CrearArma()
    {
        //Debug.Log("Hola");
        _arma=Instantiate(_armaPorDefecto,_armaPosicionRotacion.position,Quaternion.identity,_armaPosicionRotacion);
    }
    public void UsarArma()
    {
        _arma.UsarArma();
    }
}
