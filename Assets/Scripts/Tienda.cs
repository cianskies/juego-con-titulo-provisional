using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Tienda")]
public class Tienda : ScriptableObject
{
    
    public bool Rebajado;
    public GameObject[] itemsTienda;

    /*
    public void AplicaRebaja()
    {
        if(Rebajado)
        {
            for (int i = 0; i < itemsTienda.Length; i++)
            {
                itemsTienda[i].Valor = itemsTienda[i].Valor/2;
            }
        }

    }*/
}
