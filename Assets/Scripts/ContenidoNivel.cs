using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="Piso/Estructura")]
public class PisoEstructura : ScriptableObject
{
    public int NumeroRondas;
    public int RondaActual;

    public int SegundosPorRonda;

    public bool NivelSuperado;
    public bool TemporizadorActivo;
    public bool BotonEstaPulsado;

    

}
