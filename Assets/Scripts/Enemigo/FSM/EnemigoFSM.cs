using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoFSM : MonoBehaviour
{
    [Header("Configuracion")]
    [SerializeField] private string _IDEstadoInicial;


    [Header("Estados")]
    [SerializeField] public List<EstadoFSM> Estados;
    private bool _puedeHacerDanho=true;


    public EstadoFSM EstadoActual { get; private set; }
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
        if (EstadoActual == null)
        {
            EstadoActual = BuscarEstado(IDEstado);
        }
        if (EstadoActual.IDEstado != IDEstado)
        {
            EstadoActual = BuscarEstado(IDEstado);
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
    private void HacerDanhoAJugador(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<IRecbirDanho>() != null)
        {
            // Aplicar daño al objeto con el que ha colisionado
            collision.gameObject.GetComponent<IRecbirDanho>().RecibirDanho(1);

        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {

        if (_puedeHacerDanho)
        {
            HacerDanhoAJugador(collision);
            StartCoroutine(IEEsperarParaPoderHacerDanhoOtraVez());
            
        }
    }
    private IEnumerator IEEsperarParaPoderHacerDanhoOtraVez()
    {
        _puedeHacerDanho = false;
        yield return new WaitForSeconds(0.5f);
        _puedeHacerDanho = true;
    }
}
