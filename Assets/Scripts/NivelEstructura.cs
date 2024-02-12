using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NivelEstructura", menuName ="Nivel/Estructura")]
public class NivelEstructura : ScriptableObject
{

   

    [Header("Niveles")]
    [SerializeField]public Nivel[] Niveles;
}
[Serializable]
public class Nivel
{
    public string Nombre;
    public GameObject[] Pisos;
}
