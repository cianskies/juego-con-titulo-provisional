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
    public float SuerteBase;
    public float GilesBase;
    //Extra

    [Header("Stats")]
    public float LVL;

    public float Salud;
    public float Escudo;
    public float Ataque;
    public float Ammo;
    public float Dinero;
    public float PorcentajeCrit;
    public float AtaqueCritico;
    public float Suerte;

    [Header("Arma")]
    public float CosteAmmo;

    [Header("Visuals")]
    public Sprite IconoJugador;


}
