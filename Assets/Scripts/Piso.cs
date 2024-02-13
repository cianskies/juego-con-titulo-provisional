using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Piso : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("Debug")]
    [SerializeField] private bool _mostrarDebug;

    [Header("Grid")]
    [SerializeField] private Tilemap _tileMapExtra;

    [SerializeField] private PisoContenido _estructura;
    [SerializeField] private Puerta _puerta1;
    
    private Dictionary<Vector3, bool> _listaTiles= new Dictionary<Vector3, bool>(); 


    private void Awake()
    {
        _estructura.RondaActual = 0;
        _estructura.TemporizadorActivo = false;
        _estructura.BotonEstaPulsado = false;
       
    }
    private void Start()
    {
        BloquearPuertas();
        GetTiles();
    }
    private void GetTiles()
    {
        foreach(Vector3Int tile in _tileMapExtra.cellBounds.allPositionsWithin)
        {
            Vector3Int posicionTile = new Vector3Int(tile.x, tile.y, tile.z);
            Vector3 posicion=_tileMapExtra.CellToWorld(posicionTile);
            if (_tileMapExtra.HasTile(posicionTile))
            {
                //Debug.Log("Se añade un tile");
                _listaTiles.Add(posicion, true);
            }
            
        }
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
            //Debug.Log("Comienza la ronda " + _estructura.RondaActual);
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
        //Debug.Log("Termina la ronda " + _estructura.RondaActual);
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
        //Debug.Log("Las Puertas se han desbloqueado");
        _puerta1.Abrir();
    }
    private void BloquearPuertas()
    {
        //Debug.Log("Las Puertas se han bloqueado");
        _puerta1.Cerrar();
    }
    private void OnEnable()
    {
        PisoBoton.EventoPulsarBoton += RespuestaEventoPulsarBoton;
    }
    private void OnDisable()
    {
        PisoBoton.EventoPulsarBoton -= RespuestaEventoPulsarBoton;
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
