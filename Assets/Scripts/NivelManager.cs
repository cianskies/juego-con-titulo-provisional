using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NivelManager : MonoBehaviour
{
    public NivelManager Instancia;
    private void Awake()
    {
        {
            if (Instancia = null)
            {
                Instancia = this;
            }
            
        }
    }
}
