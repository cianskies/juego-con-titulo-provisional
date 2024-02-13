using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavegarAccion : AccionFSM
{
    [Header("Debug")]
    [SerializeField] private bool _DebugActivado;

    [SerializeField] private bool _usarMovimientoAleatorio;

    [SerializeField] private float _velocidadMovimiento;
    [SerializeField] private float _distanciaMinima=0.5f;
    [SerializeField] private Vector2 _rangoMovimiento;

    [Header("Obstaculos")]
    [SerializeField] private LayerMask _obstaculoMask;
    [SerializeField] private float _radioDeteccionObstaculos;

    private Vector3 _posicionMovimiento;
    private Vector3 _direccionMovimiento;
    public override void EjecutarAccionFSM()
    {
        _direccionMovimiento=(_posicionMovimiento-transform.position).normalized;
        transform.Translate(_direccionMovimiento*(_velocidadMovimiento*Time.deltaTime));
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
    }
    private Vector3 getDireccionRandom()
    {
        float x = Random.Range(-_rangoMovimiento.x, _rangoMovimiento.x);
        float y = Random.Range(-_rangoMovimiento.y, _rangoMovimiento.y);
        return new Vector3(x, y);
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
