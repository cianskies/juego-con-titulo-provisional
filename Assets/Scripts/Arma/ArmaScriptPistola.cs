using System.Collections;

using System.Collections.Generic;
using UnityEngine;

public class ArmaScriptPistola : ArmaScript
{
    [SerializeField] private Ammo _ammo;

    
    public override void UsarArma()
    {
        
        AnimarHit();

        //Instanciamos ammo
        //en el punto de disparo
        //y este se comportara como tiene programado
       

        Ammo ammo = Instantiate(_ammo);
        ammo.transform.position = _posicionDisparo.position;
        ammo.DireccionDisparo = _posicionDisparo.right;
        if (PersonajeArmaParent is ArmaJugador _jugador)
        {
            ammo.Atk = _jugador.GenerarATKConPorcentajeCritico();
        }
        else
        {

            //Se trata del daño por defecto del arma ( usado por los enemnigos)
            ammo.Atk = _arma.Ataque;
            //Debug.Log(_ammo.Atk);
        }
        //dispersion al azar entre el max y el min

        float dispersionAmmo = Random.Range(_arma.DispersionMin, _arma.DispersionMax);
        ammo.transform.rotation = Quaternion.Euler(dispersionAmmo*Vector3.forward);

    }
}
