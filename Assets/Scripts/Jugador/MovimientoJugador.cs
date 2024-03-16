using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorMovimiento : MonoBehaviour
{

    // Start is called before the first frame update
    [Header("Speec")]
    private float _velocidadMax=7;
    [SerializeField]private float _velocidadActual;


    [Header("Sprint")]
     private float _velocidadSprint=20;
     private float _duracionSprint=0.1f;
    private float _delaySprint = 2f;

    [SerializeField] private bool _sprintActivado=false;
  



    private Rigidbody2D _rb;
    private ControlesJugador _controles;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private ArmaJugador _armaJugador;


    private const string _layerIdle = "Idle";
    private const string _layerMovimiento = "Movimiento";
    private const string _layerAtacar= "Ataque";

    [SerializeField]private Vector2 _direccion;
    [SerializeField]private Vector2 _ultimaDireccion;
    private float _velocidad;


    private bool _inputActivado = true;

    public Vector2 Direccion=>_direccion;
    public Vector2 UltimaDireccion=>_direccion;



    private void Awake()
    {
        _controles = new ControlesJugador();
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _armaJugador= GetComponent<ArmaJugador>();

    }
    void Start()
    {
        _velocidad = _velocidadMax;
        _controles.Sprint.Sprint.performed += ctx => Esprintar();
    }
    private void Update()
    {
        if (_inputActivado)
        {
            GetInput();
            ActualizarLayerAnimacion();
            AnimarMovimiento();
        }
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        MoverJugador();   
    }
    private void OnEnable()
    {
        _controles.Enable();
    }
    private void OnDisable() { 

    }
    private void GetInput()
    {
        _direccion = _controles.Movimiento.Mover.ReadValue<Vector2>();
        if (_direccion != Vector2.zero) { 
        
            _ultimaDireccion = _direccion;
        
        }

        _velocidadActual = Mathf.Clamp(_direccion.magnitude, 0.0f, 1.0f);
        


    }
    private void MoverJugador()
    {
        
        _rb.MovePosition(_rb.position+_direccion.normalized * _velocidad*Time.fixedDeltaTime);
        
    }
    private void AnimarMovimiento()
    {
        if (_jugadorEnMovimiento())
        {
            _animator.SetFloat("X", _direccion.x);
            _animator.SetFloat("Y", _direccion.y);
        }

    }

    private bool _jugadorEnMovimiento()
    {
        return _velocidadActual > 0.0f;
    }

    public void ReiniciarPosicionPersonaje()
    {
        transform.position = Vector2.down;
        _direccion = Vector2.down;
        AnimarMovimiento();
    }
    private void Esprintar()
    {
        if (!_sprintActivado)
        {
            _sprintActivado = true;
            StartCoroutine(IESprint());
            StartCoroutine(IEEsperarSprint());
        }
    }
    private IEnumerator IESprint()
    {
        _velocidad = _velocidadSprint;
        _inputActivado = false;
        
        yield return new WaitForSeconds(_duracionSprint);
        _velocidad = _velocidadMax;
        _inputActivado = true;
        
    }
    private IEnumerator IEEsperarSprint()
    {
        yield return new WaitForSeconds(_delaySprint);
        _sprintActivado = false;
    }

    private void ActivarLayerAnimacion(string nombre)
    {
        for (int i = 0; i < _animator.layerCount; i++)
        {
            _animator.SetLayerWeight(i, 0);
        }
        _animator.SetLayerWeight(_animator.GetLayerIndex(nombre), 1);
    }
    private void ActualizarLayerAnimacion()
    {
        if (_armaJugador!=null&&_armaJugador.ArmaUsandose)
        {
            ActivarLayerAnimacion(_layerAtacar);
        }
        else if (_jugadorEnMovimiento())
        {
            ActivarLayerAnimacion(_layerMovimiento);
        }
        else
        {
            ActivarLayerAnimacion(_layerIdle);
        }
    }

}
