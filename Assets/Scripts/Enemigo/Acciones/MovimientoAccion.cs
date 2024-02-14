using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavegarAccion : AccionFSM
{
    [Header("Debug")]
    [SerializeField] private bool _DebugActivado;

    [SerializeField] private bool _usarMovimientoAleatorio;
    [SerializeField] private bool _usarMovimientoATile;

    [SerializeField] private float _velocidadMovimiento;
    [SerializeField] private float _distanciaMinima=0.5f;
    [SerializeField] private Vector2 _rangoMovimiento;

    [Header("Obstaculos")]
    [SerializeField] private LayerMask _obstaculoMask;
    [SerializeField] private float _radioDeteccionObstaculos;

    private EnemigoFSM _enemigoFSM;
    private Vector3 _posicionMovimiento;
    private Vector3 _direccionMovimiento;
    public override void EjecutarAccionFSM()
    {
        _direccionMovimiento=(_posicionMovimiento-transform.position).normalized;
        transform.Translate(_direccionMovimiento*(_velocidadMovimiento*Time.deltaTime));
        if (PuedeGenerarNuevaDireccion())
        {
            GenerarNuevaDireccion();
        }
    }
    private void Awake()
    {
        _enemigoFSM=GetComponent<EnemigoFSM>();
    }
    void Start()
    {
        GenerarNuevaDireccion();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GenerarNuevaDireccion()
    {
        if(_usarMovimientoAleatorio)
        {
            _posicionMovimiento=transform.position+getDireccionRandom();
        }
        if (_usarMovimientoATile)
        {
            _posicionMovimiento = _enemigoFSM.PisoActual.ObtenerTileDisponible();
        }
    }
    private Vector3 getDireccionRandom()
    {
        float x = Random.Range(-_rangoMovimiento.x, _rangoMovimiento.x);
        float y = Random.Range(-_rangoMovimiento.y, _rangoMovimiento.y);
        return new Vector3(x, y);
    }
    private bool PuedeGenerarNuevaDireccion()
    {
        bool puedeGenerarNuevaDireccion = false;
        if (Vector3.Distance(transform.position, _posicionMovimiento) < _distanciaMinima)
        {
            puedeGenerarNuevaDireccion= true;
        }
        Collider2D[] resultados=new Collider2D[10];
        int colisiones = Physics2D.OverlapCircleNonAlloc(transform.position, _radioDeteccionObstaculos, resultados, _obstaculoMask);
        if (colisiones > 0)
        {
            for (int i = 0; i < colisiones; i++)
            {
                if (resultados[i] != null)
                {
                    Vector3 direccionOpuesta = -_direccionMovimiento;
                    transform.position += direccionOpuesta * 0.1f;
                    puedeGenerarNuevaDireccion = true;
                }
            }
        }
        return puedeGenerarNuevaDireccion;
    }   
    private void OnDrawGizmos()
    {
        if (_DebugActivado)
        {
            if (_usarMovimientoAleatorio)
            {
                Gizmos.color = Color.blue;
                Gizmos.DrawWireCube(transform.position, _rangoMovimiento*2);
            }
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, _posicionMovimiento);

            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _radioDeteccionObstaculos);

        }
    }
}
