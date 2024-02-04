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
    //añadir anim al hacer sprint



    private Rigidbody2D _rb;
    private ControlesJugador _controles;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    [SerializeField]private Vector2 _direccion;
    [SerializeField] private Vector2 _ultimaDireccion;
    private float _velocidad;

    private bool _inputActivado = true;

    public Vector2 Direccion=>_direccion;

    private void Awake()
    {
        _controles = new ControlesJugador();
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

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
        _direccion = _controles.Movimiento.Mover.ReadValue<Vector2>().normalized;
        if (_direccion != Vector2.zero)
        {
            _ultimaDireccion = _direccion;
        }

        _velocidadActual = Mathf.Clamp(_direccion.magnitude, 0.0f, 1.0f);
        


    }
    private void MoverJugador()
    {
        
        _rb.MovePosition(_rb.position+_direccion * _velocidad*Time.fixedDeltaTime);
        
    }
    private void AnimarMovimiento()
    {
        if (_direccion != Vector2.zero){
            _animator.SetFloat("DireccionX", _direccion.x);
            _animator.SetFloat("DireccionY", _direccion.y);

            if (_direccion.x >= 0.1f)
            {
                _spriteRenderer.flipX = false;
            }
            else if (_direccion.x < 0f)
            {
                _spriteRenderer.flipX = true;
            }

        }
        _animator.SetFloat("Velocidad", _velocidadActual);

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

}
