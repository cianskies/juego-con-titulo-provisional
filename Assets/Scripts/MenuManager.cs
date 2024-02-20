using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    //Al hacerlo de esta manera, se podrán crear nuevos personajes jugables y arrastrarlos al lobby en futuras actualiizaciones
    [SerializeField] private PersonajeJugable[] _personajes;
    private void Start()
    {
        InstanciarPersonajesEnMenu();
    }
    private void InstanciarPersonajesEnMenu()
    {
        for (int i = 0; i < _personajes.Length; i++)
        {
            JugadorMovimiento movimientoJugador=Instantiate(_personajes[i].Jugador, _personajes[i].PosicionEnMenu.position, Quaternion.identity, _personajes[i].PosicionEnMenu);
            movimientoJugador.enabled = false;
        }
    }
}
[Serializable]
public class PersonajeJugable
{
    public JugadorMovimiento Jugador;
    public Transform PosicionEnMenu;
}
