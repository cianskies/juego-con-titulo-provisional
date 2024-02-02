using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaJugador : MonoBehaviour
{
    [Header("Debug")]
    [SerializeField] private ArmaScript _arma1;
    [SerializeField] private Transform _armaPosicion;

    private JugadorMovimiento _movimientoJugador;
   
    private ArmaScript _arma;
    private void Awake()
    {
        _movimientoJugador=GetComponent<JugadorMovimiento>();

    }
    private void Start()
    {
        CrearArma(_arma1);
    }
    private void Update()
    {
        
        if(_movimientoJugador.Direccion!=Vector2.zero)
        {
            Debug.Log(_movimientoJugador.Direccion.ToString());
            CambiarDireccionArma(_movimientoJugador.Direccion);
        }
    }
    private void CrearArma(ArmaScript arma)
    {
        _arma=Instantiate(arma, _armaPosicion.position,Quaternion.identity,_armaPosicion);
    }
    private void CambiarDireccionArma(Vector3 direccion)
    {
        float anguloRotacion = Mathf.Atan2(direccion.x, direccion.y)*Mathf.Rad2Deg;
        if (direccion.x > 0f)
        {
            _armaPosicion.localScale = Vector3.one;
            _arma.transform.localScale = Vector3.one;

        }else if(direccion.x < 0f) {
            _armaPosicion.localScale = new Vector3(-1, 1, 1);
            _arma.transform.localScale = new Vector3(-1, -1, 1);
        }
        if (direccion.y > 0f)
        {
            _armaPosicion.localScale = new Vector3(-1, 1, 1);
            _arma.transform.localScale = new Vector3(-1, 1, 1);

        }
        else if (direccion.y < 0f)
        {
            _armaPosicion.localScale = new Vector3(1, -1, 1);
            _arma.transform.localScale = new Vector3(-1, -1, 1);
        }
        _arma.transform.eulerAngles = new Vector3(0f, 0f, anguloRotacion);
    }
}
