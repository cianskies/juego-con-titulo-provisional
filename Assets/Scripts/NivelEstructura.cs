using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NivelEstructura", menuName ="Nivel/Estructura")]
public class NivelEstructura : ScriptableObject
{

    [Header("Estructura")]
    [SerializeField] public GameObject Arena;
    [SerializeField] public GameObject SalaTesoro;
    [SerializeField] public GameObject Tienda;
    [SerializeField] public GameObject Salida;

    [Header("Niveles")]
    [SerializeField]public Nivel[] Niveles;
}
[Serializable]
public class Nivel
{
    public string Nombre;
    public GameObject[] Habitaciones;
}
