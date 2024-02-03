using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaJugador : MonoBehaviour
{
    [Header("Debug")]
    [SerializeField] private ArmaScript _arma1;
    [SerializeField] private Transform _armaPosicionRotacion;

    private JugadorMovimiento _movimientoJugador;
    private ControlesJugador _controlesJugador;
   
    private ArmaScript _arma;
    private void Awake()
    {
        _controlesJugador=new ControlesJugador();
        _movimientoJugador=GetComponent<JugadorMovimiento>();

    }
    private void Start()
    {
        CrearArma(_arma1);
        _controlesJugador.Hit.Hit.performed+= ctx => HitArma();
    }
    private void Update()
    {
        
        if(_movimientoJugador.Direccion!=Vector2.zero)
        {
            Debug.Log("x: "+_movimientoJugador.Direccion.x+"y: "+_movimientoJugador.Direccion.y);
            RotarPosicionArma(_movimientoJugador.Direccion);
        }
    }
    private void CrearArma(ArmaScript arma)
    {
        _arma = Instantiate(arma,
            _armaPosicionRotacion.position, Quaternion.identity, _armaPosicionRotacion);
    }
<<<<<<< HEAD
    private void RotarPosicionArma(Vector3 direccion)
    {
        //no me funcionaba esta puta funcion y he estado 3 horas probando mierda, me considero a partir
        //de hoy maestro de los jodidos vectores, si lees esto, que sepas que probablemente no este vivo
        float angulo = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg;
=======
    private void HitArma()
    {
        if (_arma != null)
        {
            Debug.Log("Pium");
            _arma.UsarArma();
        }
    }
    private void CambiarDireccionArma(Vector3 direccion)
    {
        float anguloRotacion = Mathf.Atan2(direccion.y, direccion.x)*Mathf.Rad2Deg;
>>>>>>> 26277c44a7029ba21be80a2dcfcb4f22f32d007b
        if (direccion.x > 0f)
        {
            _armaPosicionRotacion.localScale = Vector3.one;
            _arma.transform.localScale = Vector3.one;
        }
        else if (direccion.x < 0f)
        {
            _armaPosicionRotacion.localScale = new Vector3(-1, 1, 1);
            _arma.transform.localScale = new Vector3(-1, -1, 1);
        }

<<<<<<< HEAD

        _arma.transform.eulerAngles = new Vector3(0f, 0f,angulo);
=======
        _arma.transform.eulerAngles = new Vector3(0f, 0f, anguloRotacion);
>>>>>>> 26277c44a7029ba21be80a2dcfcb4f22f32d007b
    }
    private void OnEnable()
    {
        _controlesJugador.Enable();
    }
    private void OnDisable()
    {
        _controlesJugador.Disable();
    }
}

