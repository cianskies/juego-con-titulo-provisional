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
//añadir elementos fuego, hielo etc
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
    public float AmmoMax;
    public float CosteAmmo;

    public float CosteCompra;
    public float CosteVenta;

    public ArmaScript ArmaPrefab;


    public override void Recoger()
    {
        //Debug.Log("recoger");
        NivelManager.Instancia.JugadorPosicion.GetComponent<ArmaJugador>().EquiparArma(ArmaPrefab);
    }
}
