using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Image _imgTitulo;
    [SerializeField] private Image _imgBottomText;
    [SerializeField] private bool _debug;




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
    public void Update()
    {
        if(_debug)
        {
            Vector3 posicionActual=_imgTitulo.transform.position;
            Vector3 newPosition = posicionActual + Vector3.up * 1500 * Time.deltaTime;

            // Asigna la nueva posición a la imagen
            _imgTitulo.transform.position = newPosition;
        }
    } 
    
}
[Serializable]
public class PersonajeJugable
{
    public JugadorMovimiento Jugador;
    public Transform PosicionEnMenu;
}
