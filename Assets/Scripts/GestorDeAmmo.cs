using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestorDeAmmo : MonoBehaviour
{
    private List<Ammo> _listaAmmoEnPantalla=new List<Ammo>();
    [SerializeField]private int _maxAmmoEnPantalla;

    private void Update()
    {
        for(int i = 0; i < _listaAmmoEnPantalla.Count; ++i)
        {
            _listaAmmoEnPantalla[i].TiempoEnPantalla -= Time.deltaTime;
            if (_listaAmmoEnPantalla[i].TiempoEnPantalla <= 0)
            {
                _listaAmmoEnPantalla.RemoveAt(i);
            }
            
        }
        Debug.Log(_listaAmmoEnPantalla.Count);
    }

    private void OnEnable()
    {
        Ammo.InstanciarBala += AnhadirAListaBala;
        Ammo.DestruirBala += EliminarBalaDeLista;
    }
    private void OnDisable()
    {
        Ammo.InstanciarBala -= AnhadirAListaBala;
    }
    private void AnhadirAListaBala(Ammo bala)
    {
        if (_listaAmmoEnPantalla.Count > _maxAmmoEnPantalla)
        {
            bala.OnDestroy();
        }
        else
        {
            _listaAmmoEnPantalla.Add(bala);
        }
    }
    private void EliminarBalaDeLista(Ammo bala)
    {
        _listaAmmoEnPantalla.Remove(bala);
    }


}
