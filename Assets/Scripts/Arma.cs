using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Tipo
{
    Espada,
    Hacha,
    Pistola
}
public enum Rango
{
    F,
    E,
    D,
    C,
    B,
    A,
    S,
    SS,
    SSSS

}
//a�adir elementos fuego, hielo etc
[CreateAssetMenu(menuName = "Items/Arma")]
public class Arma : ItemData
{

    public Tipo Tipo;
    public Rango Rango;

    public float Ataque;
    public float CosteMp;
    public float Delay;

    public float DispersionMin;
    public float DispersionMax;
    public float Ammo;
    public float CosteAmmo;


    //efectos
    
}
