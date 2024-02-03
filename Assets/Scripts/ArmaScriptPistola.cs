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
        //dispersion al azar entre el max y el min
        float dispersionAmmo = Random.Range(_arma.DispersionMin, _arma.DispersionMax);
        ammo.transform.rotation = Quaternion.Euler(dispersionAmmo*Vector3.forward);

    }
}
