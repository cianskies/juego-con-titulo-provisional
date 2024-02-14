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
    private bool _armaUsandose=false;
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

            RotarPosicionArma(_movimientoJugador.UltimaDireccion);
            
        }
    }
    private void RotarPosicionArma(Vector3 direccion)
    {
        //no me funcionaba esta puta funcion y he estado 3 horas probando mierda, me considero a partir
        //de hoy maestro de los jodidos vectores, si lees esto, que sepas que probablemente no este vivo
        if (_arma != null)
        {




            float angulo = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg;

            // Determinar la escala en función de la dirección
            Vector3 escala = new Vector3(direccion.x > 0f ? 1f : -1f, 1f, 1f); // Mantenemos la escala en Y en 1

            // Reiniciar la rotación y escala del arma
            Transform posicion = _arma.transform;
            posicion.rotation = Quaternion.Euler(0f, 0f, angulo);
            posicion.localScale = escala;

            // Reiniciar la rotación y escala del punto de rotación del arma
            _armaPosicionRotacion.rotation = Quaternion.Euler(0f, 0f, angulo);
            _armaPosicionRotacion.localScale = escala;


            _arma.transform.eulerAngles = new Vector3(0f, 0f, angulo);

        }



    }
        private void HitArma()
        {
            if (SuficienteAmmo())
            {
                _armaUsandose = true;
                //Debug.Log("Pium");
                _arma.UsarArma();
                _mStatsJugador.GastarAmmo(_arma.Arma.CosteAmmo);
                _armaUsandose = false;

            }
        }
    private void ReinciarPosicionArma()
    {
        
        Vector2 direccion = _movimientoJugador.Direccion;
        float angulo = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg;
        Transform posicion = _arma.transform;
        posicion.rotation=Quaternion.Euler(0f,0f,angulo);
        posicion.localScale = Vector3.one;
        
        _armaPosicionRotacion.rotation = Quaternion.Euler(0f, 0f, angulo);
        _armaPosicionRotacion.localScale = Vector3.one;
        _movimientoJugador.ReiniciarPosicionPersonaje();



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

