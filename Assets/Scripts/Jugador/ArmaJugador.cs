using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaJugador : ArmaPersonaje
{
    public static event Action EventoCambiarArmaSinCosteAmmo;
    public static event Action EventoCambiarArmaConCosteAmmo;

    [SerializeField] private StatsJugador _statsJugador;
    private JugadorMovimiento _movimientoJugador;
    private ControlesJugador _controlesJugador;
    private ModificadorStatsJugador _mStatsJugador;
    private CampoVisionJugador _visionJugador;
    private Animator _animator;

    
    private int _armaIndex;
    private ArmaScript[] _armasEquipadas=new ArmaScript[2];
    private bool _armaUsandose=false;

    public bool ArmaUsandose { get { return _armaUsandose; } }
    protected override void Awake()
    {
        _controlesJugador=new ControlesJugador();
        _movimientoJugador=GetComponent<JugadorMovimiento>();
        _mStatsJugador = GetComponent<ModificadorStatsJugador>();
        _animator = GetComponent<Animator>();
        _visionJugador =GetComponentInChildren<CampoVisionJugador>();

    }
    private void Start()
    {
        
        _controlesJugador.Hit.Hit.performed+= ctx => HitArma();
        _controlesJugador.Acciones.CambiarArma.performed += ctx => CambiarArma();
    }
    private void Update()
    {
        RotarArmaHacia();
    }
    public float GenerarATKConPorcentajeCritico()
    {
        float atk = _arma.Arma.Ataque;
        float porcentaje= UnityEngine.Random.Range(0, 100);
        if(porcentaje < _statsJugador.PorcentajeCrit)
        {
            atk = atk * ((_statsJugador.AtaqueCritico / 100f))+atk;
        }
        return atk;
    }
    private bool SuficienteAmmo()
    {
        if (_arma!=null&&_mStatsJugador.CosteAmmoSuficiente(_arma.Arma.CosteAmmo))
        {

            return true;
        }
        else
        {
            return false;
        }
    }
    private void CrearArma(ArmaScript arma)
    {
        //instancia el arma seleccionada y ajusta su rotacion
        _arma = Instantiate(arma,
            _armaPosicionRotacion.position, Quaternion.identity, _armaPosicionRotacion);
        _mStatsJugador.GetAmmo(_arma.Arma.AmmoMax);

        ActualizarUIDeArma();
        _armasEquipadas[_armaIndex] = _arma;
        _armasEquipadas[_armaIndex].PersonajeArmaParent = this;
    }

    private void ActualizarUIDeArma()
    {
        if (_arma.Arma.CosteAmmo > 0)
        {
            Debug.Log("Se activa la barra de ammo");
            EventoCambiarArmaConCosteAmmo?.Invoke();
            _mStatsJugador.SetAmmoMax(_arma.Arma.AmmoMax);


        }
        else
        {
            Debug.Log("Se desactiva la barra de ammo");
            EventoCambiarArmaSinCosteAmmo?.Invoke();
        }
    }

    public void EquiparArma(ArmaScript arma)
    {
        if (_armasEquipadas[0] == null)
        {
            CrearArma(arma);
            return;
        }
        if (_armasEquipadas[1] == null)
        {
            ++_armaIndex;
            _armasEquipadas[0].gameObject.SetActive(false);
            CrearArma(arma);
            return;
        }
        //Destruimos el arma en el indice e arma actual 
        Destroy(_arma.gameObject);
        _armasEquipadas[_armaIndex] = null;
        //La reemplazamos por el arma a equipar en la posicion del indice del arma que acabamos de 
        //destruir
        CrearArma(arma) ;
    }
    private void RotarArmaHacia()
    {
        //rotar el arma en la direccion a la que mira el jugador
        if (_arma != null && _movimientoJugador.Direccion != Vector2.zero)
        {
            RotarPosicionArma(_movimientoJugador.Direccion);
        }
        /*funcion de autoAim, en futuras armas y/o funcionalidades
        if(_visionJugador.EnemigoTarget != null)
        {
            Vector3 direccionAEnemigo=_visionJugador.EnemigoTarget.transform.position-transform.position;
            RotarPosicionArma(direccionAEnemigo);
        }*/
    }
    private void CambiarArma()
    {
        if (_armasEquipadas[1]!=null&&_movimientoJugador.Direccion==Vector2.zero&&!_armaUsandose)
        {
            for(int i = 0;i<_armasEquipadas.Length;++i)
            {
                _armasEquipadas[i].gameObject.SetActive(false);

            }
            //cambiar Indice Arma (0-1)
            _armaIndex = 1 - _armaIndex;
            _arma = _armasEquipadas[_armaIndex];
            _arma.gameObject.SetActive(true);
            ActualizarUIDeArma();

            RotarPosicionArma(_movimientoJugador.UltimaDireccion);
            
        }
    }

        private void HitArma()
        {
            if (SuficienteAmmo())
            {
            AudioManager.Instancia.Play("AtaqueJugador1");
            _animator.SetTrigger("Ataque");

                //Debug.Log("Pium");
                _arma.UsarArma();
                _mStatsJugador.GastarAmmo(_arma.Arma.CosteAmmo);
                _armaUsandose = false;
            StartCoroutine(IEEstadoAtacar());

            }
        }
    private IEnumerator IEEstadoAtacar()
    {
        _armaUsandose=true;
        yield return new WaitForSeconds(0.3f);
        _armaUsandose = false;
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

