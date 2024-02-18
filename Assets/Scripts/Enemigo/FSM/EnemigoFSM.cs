using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoFSM : MonoBehaviour
{
    [Header("Configuracion")]
    [SerializeField] private string _IDEstadoInicial;
    

    [Header("Estados")]
    [SerializeField]public List<EstadoFSM> Estados;


    public EstadoFSM EstadoActual {  get; private set; }
    public Piso PisoActual { get; set; }

    public Transform Jugador { get; set; }
    

    private void Start()
    {
        if (_IDEstadoInicial != null)
        {
            CambiarEstado(_IDEstadoInicial);
        }
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
        if(EstadoActual == null)
        {
            EstadoActual = BuscarEstado(IDEstado);
        }
        if(EstadoActual.IDEstado!= IDEstado)
        {
            EstadoActual=BuscarEstado(IDEstado);
        }
    }
    public EstadoFSM BuscarEstado(string IDEstado)
    {
        for (int i = 0; i < Estados.Count; ++i)
        {
            if (Estados[i].IDEstado == IDEstado)
            {
                return Estados[i];
            }
            
        }
        return null;
    }
}
