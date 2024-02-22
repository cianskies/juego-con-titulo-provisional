using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class StatsJugador : ScriptableObject
{
    [Header("StatsBase")]
    public float LVLBase;

    public float SaludBase;
    public float EscudoBase;
    public float AtaqueBase;
    public float DineroBase;
    public float AmmoBase;
    public float PorcentajeCritBase;
    public float AtaqueCriticoBase;
    //Extra
    public string Descripcion;
    public string Nombre;
    public bool Disponible;
    public float CosteDeMejora;
    public float CosteDesbloqueo;
    [Range(0f, 100)] public int MultiplicadorMejora;

    [Header("Stats")]
    public float LVL;

    public float Salud;
    public float Escudo;
    public float Ataque;
    public float Ammo;
    public float Dinero;
    public float PorcentajeCrit;
    public float AtaqueCritico;

    [Header("Arma")]
    public float CosteAmmo;

    [Header("Visuals")]
    public Sprite IconoJugador;


}
