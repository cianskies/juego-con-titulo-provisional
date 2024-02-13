using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NivelManager : MonoBehaviour
{

    [SerializeField] private NivelEstructura _estructura;


    private GameObject _nivel;
    private int _indiceNivel = 0;
    private int _indicePiso = 0;

    private NivelManager _instancia;
    private void Awake()
    {
        _instancia = this;

    }
    private void Start()
    {
        CrearNivel();
    }
    private void CrearNivel()
    {
        _nivel = Instantiate(_estructura.Niveles[_indiceNivel].Pisos[_indicePiso], transform);
    }


    private void OnEnable()
    {
        SalidaPiso.EventoSuperarNivel += RespuestaEventoSuperarNivel;
    }
    private void OnDisable()
    {
        SalidaPiso.EventoSuperarNivel -= RespuestaEventoSuperarNivel;
    }

    private void RespuestaEventoSuperarNivel()
    {
        SiguienteNivel();
    }
    private void SiguienteNivel()
    {
        ++_indicePiso;
        if (_indicePiso > _estructura.Niveles[_indiceNivel].Pisos.Length - 1)
        {
            _indicePiso = 0;
            ++_indiceNivel;
        }
        Destroy(_nivel);
        CrearNivel();
    }

}
