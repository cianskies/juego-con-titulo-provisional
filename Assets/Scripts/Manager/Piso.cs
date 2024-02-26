using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

public class Piso : MonoBehaviour
{
    public delegate void NotificarTemporizador(float tiempo);

    public static event NotificarTemporizador EstablecerNuevoTiempoTemporizador;

    [Header("Debug")]
    [SerializeField] private bool _mostrarDebug;

    [Header("Grid")]
    [SerializeField] private Tilemap _tileMapExtra;

    [Header("Elementos del nivel")]
    [SerializeField] private PisoContenido _estructura;
    [SerializeField] private Puerta[] _puertas;

    [Header("Posicion de jugador")]
    [SerializeField] private Vector3 _posicionInicial;
    
    
    private List<StatsEnemigo> _listaEnemigosEnPisoActual;
    
    //Por el momento todos los tiles del tilemap extra son True (mostrar debug para ver), se tiene pensado instanciar trampas
    //en tiles libres y marcarlos como false.
    private Dictionary<Vector3, bool> _listaTiles= new Dictionary<Vector3, bool>();

    public static Piso Instancia;
    public Vector3 PosicionInicial { get { return _posicionInicial; } }
    public PisoContenido Estructura {  get { return _estructura; } }
    public int EnemigosPisoActual { get { return _listaEnemigosEnPisoActual.Count; } }

    private void Awake()
    { 
        Instancia = this;
        _estructura.RondaActual = 0;
        _listaEnemigosEnPisoActual = new List<StatsEnemigo>();
        _estructura.TemporizadorActivo = false;
        _estructura.BotonEstaPulsado = false;
       
    }
    private void Start()
    {
        BloquearPuertasYAbrirTodas();
        GetTiles();
        InstanciarMonedas();

    }
    private void GetTiles()
    {
        //Recorre todos los tiles de TileMap extra del nivel y los marca como Verdadero en lista de tiles
        foreach(Vector3Int tile in _tileMapExtra.cellBounds.allPositionsWithin)
        {
            Vector3Int posicionTile = new Vector3Int(tile.x, tile.y, tile.z);
            Vector3 posicion=_tileMapExtra.CellToWorld(posicionTile);
            Vector3 posicionReal=new Vector3(posicion.x+0.5f,posicion.y+0.5f,posicion.z);
            if (_tileMapExtra.HasTile(posicionTile))
            {
                //Debug.Log("Se añade un tile");
                _listaTiles.Add(posicionReal, true);
            }
            
        }
    }

    private void RespuestaEventoPulsarBoton() 
    {
        //Si el temporizador esta desactivado, quedan rondas de enemigos todavia y el boton no esta pulsado
        //se pulsa el boton y comienza la siguiente ronda
        if (!_estructura.TemporizadorActivo&&getNumeroRondasRestantes()>0&&!_estructura.BotonEstaPulsado)
        {
            _estructura.BotonEstaPulsado = true;
            SiguienteRonda();

        }else if(_estructura.TemporizadorActivo && getNumeroRondasRestantes() > 0&&_estructura.BotonEstaPulsado)
        {
            //Si el temporizador esta activado, el boton pulsado y se pulsa el boton, recibes una
            //penalizacion de daño pero no iniciara la siguiente ronda
            Debug.Log("Has parado el temporizador");
            _estructura.TemporizadorActivo = false;
            _estructura.BotonEstaPulsado = false;
            NivelManager.Instancia.Jugador.GetComponent<ModificadorStatsJugador>().RecibirDanho(3f);
        }
    }

    private void SiguienteRonda()
    {
        //Las rondas funcionan asi
        if (getNumeroRondasRestantes() > 0)
        {
            //Se activa el temporizador, todas las puertas se cierran,
            //apareden enemigos y monedas. Se activa el temporizador antes de que vuelva a ser
            //la siguiente ronda
            _estructura.TemporizadorActivo = true;
            BloquearPuertas();
            InstanciarMonedas();
            ++_estructura.RondaActual;
            //Debug.Log("Comienza la ronda " + _estructura.RondaActual);
            InstanciarEnemigosDeRonda();
            StartCoroutine(IETemporizador());
        }
        
    }

    private IEnumerator IETemporizador()
    {
        EstablecerNuevoTiempoTemporizador?.Invoke(_estructura.SegundosPorRonda);

        yield return new WaitForSeconds(_estructura.SegundosPorRonda);

        //Debug.Log("Termina la ronda " + _estructura.RondaActual);
        if(_estructura.BotonEstaPulsado)
        {
            SiguienteRonda();
        }else if (_listaEnemigosEnPisoActual.Count == 0 && getNumeroRondasRestantes() > 0)
        {
            BloquearPuertasYAbrirTodas();
        }

    }

    private void InstanciarEnemigosDeRonda()
    {
        int numeroEnemigos=GenerarNumeroEnemigosRonda();
        for (int i = 0; i < numeroEnemigos; ++i)
        {

            EnemigoFSM enemigo=Instantiate(ObtenerFSMEnemigoRandom(), ObtenerTileDisponible(), Quaternion.identity,transform);
            _listaEnemigosEnPisoActual.Add(enemigo.GetComponent<StatsEnemigo>());
            enemigo.PisoActual = Instancia;
        }
    }

    private void InstanciarMonedas()
    {
        int random = Random.Range(_estructura.MinMonedasRonda,_estructura.MaxMonedasRonda);
        for (int i = 0; i < random; i++)
        {
            
            GameObject moneda = Instantiate(ObtenerMonedaRandom(), ObtenerTileDisponible(), Quaternion.identity, transform);
            //Debug.Log("Se instancia una moenda en " + moneda.transform.position);
        }
    }

    public Vector3 ObtenerTileDisponible() {
        List<Vector3> tilesLibres=(from tile in _listaTiles where tile.Value select tile.Key).ToList();
        int random = Random.Range(0,tilesLibres.Count);
        return tilesLibres[random];

    }
    private int GenerarNumeroEnemigosRonda()
    {
        int cantidad= Random.Range(_estructura.MinEnemigosRonda,_estructura.MaxEnemigosRonda+1);
        return cantidad;
    }
    private EnemigoFSM ObtenerFSMEnemigoRandom()
    {
        EnemigoFSM[] enemigosDePiso = _estructura.EnemigosDePiso;
        int random = Random.Range(0, enemigosDePiso.Length);
        return enemigosDePiso[random];
    }private GameObject ObtenerMonedaRandom()
    {
        GameObject[] monedasDePiso = _estructura.MonedasDePiso;
        int random = Random.Range(0, monedasDePiso.Length);
        return monedasDePiso[random];
    }
    private int getNumeroRondasRestantes()
    {
        return _estructura.NumeroRondas - _estructura.RondaActual;
    }
    private void DesbloquearPuertas()
    {
        for (int i = 0; i < _puertas.Length; i++)
        {
            _puertas[i].Abrir();
        }
        //Debug.Log("Las Puertas se han desbloqueado");

    }
    private void BloquearPuertas()
    {
        for (int i = 0; i < _puertas.Length; i++)
        {
            _puertas[i].Cerrar();
        }
        //Debug.Log("Las Puertas se han bloqueado");
        
    }    private void BloquearPuertasYAbrirTodas()
    {
        //Debug.Log("Las Puertas se han bloqueado");
        for (int i = 0; i < _puertas.Length; i++)
        {
            switch (_puertas[i].Tipo)
            {
                case TipoPuerta.SalidaNivel:
                    _puertas[i].Cerrar();
                    break;
                default:
                    _puertas[i].Abrir();
                    break;
            }
        }
    }
    private void RespuestaEventoNotificarMuerteEnemigo(StatsEnemigo enemigo)
    {
        _listaEnemigosEnPisoActual.Remove(enemigo);
        if(getNumeroRondasRestantes()==0 && _listaEnemigosEnPisoActual.Count == 0) {
            DesbloquearPuertas();
            //Debug.Log("Nivel superado");
        }
        else if (_listaEnemigosEnPisoActual.Count == 0&&_estructura.TemporizadorActivo==false)
        {
            BloquearPuertasYAbrirTodas();
        }
    }
    private void OnEnable()
    {
        PisoBoton.EventoPulsarBoton += RespuestaEventoPulsarBoton;
        StatsEnemigo.EventoNotificarMuerteEnemigo += RespuestaEventoNotificarMuerteEnemigo;
    }
    private void OnDisable()
    {
        PisoBoton.EventoPulsarBoton -= RespuestaEventoPulsarBoton;
        StatsEnemigo.EventoNotificarMuerteEnemigo -= RespuestaEventoNotificarMuerteEnemigo;
    }

    private void OnDrawGizmos()
    {
        if (_mostrarDebug)
        {
            foreach (KeyValuePair<Vector3, bool> valor in _listaTiles)
            {
                if (valor.Value)
                {
                    Gizmos.color = Color.magenta;
                    Gizmos.DrawWireCube(valor.Key, Vector3.one * 0.8f);
                }
                else
                {
                    Gizmos.color = Color.red;
                    Gizmos.DrawWireCube(valor.Key, Vector3.one * 0.8f);
                }

            }
        }
        
            
        
    }
}
