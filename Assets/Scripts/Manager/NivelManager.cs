using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NivelManager : MonoBehaviour
{
    private static NivelManager _instancia;   
    [Header("La sucesion de niveles y su orden")]
    [SerializeField] private NivelEstructura _estructura;
    [Header("Referencia del prefab del jugador")]
    [SerializeField]private GameObject _jugadorPrefab;
    private Transform _jugadorPosicion;
    private ModificadorStatsJugador _statsJugador;


    private GameObject _nivel;
    private Piso _scriptPiso;
    private int _indiceNivel;
    private int _indicePiso;


    public static NivelManager Instancia {get
        {
            if (_instancia == null)
            {
                _instancia = FindObjectOfType<NivelManager>();

                // Si no se encuentra, se crea un nuevo objeto para el singleton
                if (_instancia == null)
                {
                    GameObject singletonObject = new GameObject(typeof(NivelManager).Name);
                    _instancia= singletonObject.AddComponent<NivelManager>();
                }

            }
            return _instancia;
        }
        }
    public GameObject Jugador { get { return _jugadorPrefab; }set { _jugadorPrefab = value; } }
    public Transform JugadorPosicion {  get { return _jugadorPosicion; }set { _jugadorPosicion = value; } }
    public ModificadorStatsJugador StatsJugador {  get { return _statsJugador; } set { _statsJugador = value; } }

    //Esta clase se encarga de cambiar de nivel, de cambiar al jugador de posicion y tener una referencia global en su instancia por si otros
    //componentes necesitan acceder a el
    private void Awake()
    {
        _indiceNivel = 0;
        _indicePiso = 0;
        _instancia = this;
        Debug.Log(_indiceNivel +" "+ _indicePiso +_estructura.ToString());

    }
    private void Start()
    {
        CrearJugador();
        CrearNivel();

        
        
    }
    private void CrearJugador()
    {
        _jugadorPrefab = Instantiate(_jugadorPrefab);
        _jugadorPosicion = _jugadorPrefab.GetComponent<Transform>();
        _statsJugador = _jugadorPrefab.GetComponent<ModificadorStatsJugador>();
    }
    private void CrearNivel()
    {
        _nivel = Instantiate(_estructura.Niveles[_indiceNivel].Pisos[_indicePiso], transform);
        _scriptPiso=_nivel.GetComponent<Piso>();
        JugadorPosicion.transform.position = _scriptPiso.PosicionInicial;
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
