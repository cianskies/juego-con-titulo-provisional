using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampoVisionJugador : MonoBehaviour
{
    [Header("Debug")]
    public bool MostrarDebug;

    [SerializeField] private float _radioCampoVision;
    private List<StatsEnemigo> _listaEnemigosCampoVision=new List<StatsEnemigo>();
    
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemigo"))
        {
            //Debug.Log("Se ha detectado un enemigo");
            StatsEnemigo statsEnemigo=collision.GetComponent<StatsEnemigo>();
            _listaEnemigosCampoVision.Add(statsEnemigo);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemigo"))
        {
            StatsEnemigo statsEnemigo = collision.GetComponent<StatsEnemigo>();
            if (_listaEnemigosCampoVision.Contains(statsEnemigo))
            {
                //Debug.Log("He perdido de vista un enemigo");
                _listaEnemigosCampoVision.Remove(statsEnemigo);
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
        
            Gizmos.color = Color.yellow;
            for (int i = 0; i < _listaEnemigosCampoVision.Count; i++)
            {
                Gizmos.DrawLine(transform.position, _listaEnemigosCampoVision[i].transform.position);
            }
        
    }
}
