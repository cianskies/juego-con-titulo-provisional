using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piso : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("Debug")]
 


    [SerializeField] private PisoEstructura _estructura;
    [SerializeField] private Puerta _puerta1;
    


    private void Awake()
    {
        _estructura.RondaActual = 0;
        _estructura.TemporizadorActivo = false;
        _estructura.BotonEstaPulsado = false;
       
    }
    private void Start()
    {
        BloquearPuertas();
    }

    private void OnEnable()
    {
        PisoBoton.EventoPulsarBoton += RespuestaEventoPulsarBoton;
    }
    private void OnDisable()
    {
        PisoBoton.EventoPulsarBoton -= RespuestaEventoPulsarBoton;
    }

    private void RespuestaEventoPulsarBoton()
    {
        if (!_estructura.TemporizadorActivo&&getNumeroRondasRestantes()>0&&!_estructura.BotonEstaPulsado)
        {
            _estructura.BotonEstaPulsado = true;
            SiguienteRonda();

        }else if(_estructura.TemporizadorActivo && getNumeroRondasRestantes() > 0&&_estructura.BotonEstaPulsado)
        {
            _estructura.TemporizadorActivo = false;
            _estructura.BotonEstaPulsado = false;
        }
    }

    private void SiguienteRonda()
    {
        _estructura.TemporizadorActivo = true;
        if (getNumeroRondasRestantes() > 0)
        {
            ++_estructura.RondaActual;
            Debug.Log("Comienza la ronda " + _estructura.RondaActual);
            StartCoroutine(IETemporizador());
        }
        else
        {
            DesbloquearPuertas();
        }
    }

    private IEnumerator IETemporizador()
    {
        
        yield return new WaitForSeconds(_estructura.SegundosPorRonda);
        Debug.Log("Termina la ronda " + _estructura.RondaActual);
        if(_estructura.BotonEstaPulsado)
        {
            SiguienteRonda();
        }
    }
    private int getNumeroRondasRestantes()
    {
        return _estructura.NumeroRondas - _estructura.RondaActual;
    }
    private void DesbloquearPuertas()
    {
        Debug.Log("Las Puertas se han desbloqueado");
        _puerta1.Abrir();
    }
    private void BloquearPuertas()
    {
        Debug.Log("Las Puertas se han bloqueado");
        _puerta1.Cerrar();
    }
}
