using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampoVisionJugador : MonoBehaviour
{
    [Header("Debug")]
    public bool MostrarDebug;
    [Header("RayCast")]
    [SerializeField] private LayerMask _obstaculoMask;

    [SerializeField] private float _radioCampoVision;
    [SerializeField]private List<StatsEnemigo> _listaEnemigos=new List<StatsEnemigo>();//todos los enemigos que han sido detectados
    [SerializeField] private List<StatsEnemigo> _listaEnemigosCampoVisionActual=new List<StatsEnemigo>();//todos los enemigos que estan en el campo de vision en cada frame

    public StatsEnemigo EnemigoTarget { get; private set; }
    private CircleCollider2D _circleColliderJugador;

    private void Awake()
    {
        _circleColliderJugador = GetComponent<CircleCollider2D>();
    }
    private void Start()
    {
        _radioCampoVision = _circleColliderJugador.radius;
    }
    private void Update()
    {
        ObtenerEnemigosEnCampoDeVisionActual();
        ObtenerEnemigoMasCercano();
        
    }
    private void ObtenerEnemigosEnCampoDeVisionActual()
    {
        //Recorre la lista de todos los enemigos que ya son detectados
        for(int i=0;i<_listaEnemigos.Count;i++)
        {
           if (_listaEnemigos==null|| _listaEnemigos.Count == 0)
           {
                Debug.Log("No veo na");
                return;
           }
            Vector3 posicionJugador=transform.position;
            Vector3 direccionAEnemigo = _listaEnemigos[i].transform.position-posicionJugador;
            //lanza un rayo entre el jugador y el enemigo para ver si hay algun obstaculo que lo bloquea
            RaycastHit2D hit2D = Physics2D.Raycast(posicionJugador, direccionAEnemigo,
                direccionAEnemigo.magnitude,_obstaculoMask);
            if(hit2D.collider==null)
            {
                //si no hay obstaculos se añade a la lista de enemigos en el campo de vision
                if (_listaEnemigosCampoVisionActual.Contains(_listaEnemigos[i])==false)
                {
                    Debug.Log("Veo un enemigo");
                    //Debug.Log(_listaEnemigosCampoVisionActual.Count);
                    _listaEnemigosCampoVisionActual.Add(_listaEnemigos[i]);
                }

            }
            else
            {
                //Si deja de detectar al enemigo se elimina de la lista de enemigos a la vista
                if (_listaEnemigosCampoVisionActual.Contains(_listaEnemigos[i]))
                {
                    Debug.Log("Ya no veo un enemigo");
                    _listaEnemigosCampoVisionActual.Remove(_listaEnemigos[i]);
                }
                if (EnemigoTarget = _listaEnemigos[i])
                {
                    EnemigoTarget = null;
                }
            }

        }
        
    }
    private void ObtenerEnemigoMasCercano()
    {
        //esta funcion es horrible
        //empezamos sin una distancia minima (esta es la distancia entre eñ enemigo mas cercano y el jugador)
        float distanciaMinima = Mathf.Infinity;
        StatsEnemigo enemigo = null;
        for (int i = 0; i < _listaEnemigosCampoVisionActual.Count; i++)
        { 
            //Calculamos la direccion de cada enemigo a la vista y el jugador
            Vector3 posicionEnemigo = _listaEnemigosCampoVisionActual[i].transform.position;
            float distanciaJugadorEnemigo=Vector3.Distance(transform.position, posicionEnemigo);
            //Si la distancia es menor que la del enemigo mas cercano anterior, este se convierte
            //en el enemigo Target, y su distancia con el jugador pasa a ser la distancia minima
            //Haciendo que cada vez que detecte de nuevo la distancia con un enemigo, la compare con la de este
            //enemigo target (que es el mas cercano)
            if(distanciaJugadorEnemigo<distanciaMinima)
            {
                enemigo=_listaEnemigosCampoVisionActual[i];
                distanciaMinima = distanciaJugadorEnemigo;
            }
        }
        if (enemigo != null)
        {
            EnemigoTarget = enemigo;
            _listaEnemigosCampoVisionActual.Clear();

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemigo"))
        {
            //Debug.Log("Se ha detectado un enemigo");
            StatsEnemigo statsEnemigo=collision.GetComponent<StatsEnemigo>();
            _listaEnemigos.Add(statsEnemigo);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemigo"))
        {
            StatsEnemigo statsEnemigo = collision.GetComponent<StatsEnemigo>();
            if (_listaEnemigos.Contains(statsEnemigo))
            {
                //Debug.Log("He perdido de vista un enemigo");
                _listaEnemigos.Remove(statsEnemigo);
            }if(statsEnemigo==EnemigoTarget)
            {
                EnemigoTarget = null;
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (MostrarDebug == false)
        {
            return;
        }
        
            Gizmos.color = Color.red;
            for (int i = 0; i < _listaEnemigosCampoVisionActual.Count; i++)
            {
                Gizmos.DrawLine(transform.position, _listaEnemigosCampoVisionActual[i].transform.position);
            }
            if(EnemigoTarget != null)
            {
            Gizmos.color = Color.magenta;
            Gizmos.DrawLine(transform.position, EnemigoTarget.transform.position);  
            }   
        
    }
}
