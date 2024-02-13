using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaJugador : MonoBehaviour
{
    [Header("RotacionArma")]
    [SerializeField] private Transform _armaPosicionRotacion;

    private JugadorMovimiento _movimientoJugador;
    private ControlesJugador _controlesJugador;
    private ModificadorStatsJugador _mStatsJugador;


    private ArmaScript _arma;
    private int _armaIndex;
    private ArmaScript[] _armasEquipadas=new ArmaScript[2];
    private void Awake()
    {
        _controlesJugador=new ControlesJugador();
        _movimientoJugador=GetComponent<JugadorMovimiento>();
        _mStatsJugador = GetComponent<ModificadorStatsJugador>();
        
        

    }
    private void Start()
    {
        
        _controlesJugador.Hit.Hit.performed+= ctx => HitArma();
        _controlesJugador.Acciones.CambiarArma.performed += ctx => CambiarArma();
    }
    private void Update()
    {

        if(_arma!=null&&_movimientoJugador.Direccion!=Vector2.zero)
        {
            RotarPosicionArma(_movimientoJugador.Direccion);
        }
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
        _arma = Instantiate(arma,
            _armaPosicionRotacion.position, Quaternion.identity, _armaPosicionRotacion);

        if(_arma.Arma.CosteAmmo>0)
        {
            _mStatsJugador.GetAmmo(_arma.Arma.Ammo);
            _mStatsJugador.SetAmmoMax(_arma.Arma.Ammo);
        }
        
        _armasEquipadas[_armaIndex] = _arma;
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
    private void CambiarArma()
    {
        if (_armasEquipadas[1]!=null)
        {
            for(int i = 0;i<_armasEquipadas.Length;++i)
            {
                _armasEquipadas[i].gameObject.SetActive(false);

            }
            //cambiar Indice Arma (0-1)
            _armaIndex = 1 - _armaIndex;
            _arma = _armasEquipadas[_armaIndex];
            _arma.gameObject.SetActive(true);
            ReinciarPosicionArma();
        }
    }
    private void RotarPosicionArma(Vector3 direccion)
    {
        //no me funcionaba esta puta funcion y he estado 3 horas probando mierda, me considero a partir
        //de hoy maestro de los jodidos vectores, si lees esto, que sepas que probablemente no este vivo
        if (_arma != null)
        {
            float angulo = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg;



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



            _arma.transform.eulerAngles = new Vector3(0f, 0f, angulo);

        }



    }
        private void HitArma()
        {
            if (SuficienteAmmo())
            {
                Debug.Log("Pium");
                _arma.UsarArma();
                _mStatsJugador.GastarAmmo(_arma.Arma.CosteAmmo);

            }
        }
    private void ReinciarPosicionArma()
    {
        Transform posicion = _arma.transform;
        posicion.rotation=Quaternion.identity;
        posicion.localScale = Vector3.one;
        
        _armaPosicionRotacion.rotation = Quaternion.identity;
        _armaPosicionRotacion.localScale = Vector3.one;
        

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

