using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoFSM : MonoBehaviour
{
    [Header("Configuracion")]
    [SerializeField] private string _IDEstadoInicial;

    [Header("Estados")]
    public EstadoFSM[] Estados;

    public EstadoFSM EstadoActual {  get; private set; }

    private void Start()
    {
        CambiarEstado(_IDEstadoInicial);
    }
    private void Update()
    {
        if (EstadoActual != null)
        {
            EstadoActual.EjecutarEstadoFSM(this);
        }
    }

    public void CambiarEstado(string IDEstado)
    {

    }
}
