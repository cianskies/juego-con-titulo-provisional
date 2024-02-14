using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Piso/Estructura")]
public class PisoContenido : ScriptableObject
{
    public int NumeroRondas;
    public int RondaActual;

    public int SegundosPorRonda;

    public bool NivelSuperado;
    public bool TemporizadorActivo;
    public bool BotonEstaPulsado;

    public EnemigoFSM[] EnemigosDePiso;
    public int MinEnemigosRonda;
    public int MaxEnemigosRonda;


}
