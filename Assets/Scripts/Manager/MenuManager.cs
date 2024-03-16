using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager :MonoBehaviour
{
    /*[Header("Visual")]
    [SerializeField] private Image _imgTitulo;
    [SerializeField] private Image _imgBottomText;*/
    [SerializeField] private GameObject _botonMejora;
    [SerializeField] private GameObject _botonDesbloqueo;
    [SerializeField] private GameObject _botonJugar;



    [Header("Personaje")]
    [SerializeField] private GameObject _panelJugador;
    [SerializeField] private Image _imgJugador;
    [SerializeField] private TextMeshProUGUI _nivelJugador;
    [SerializeField] private TextMeshProUGUI _nombreJugador;
    [SerializeField] private TextMeshProUGUI _saludJugador;
    [SerializeField] private TextMeshProUGUI _armaduraJugador;
    [SerializeField] private TextMeshProUGUI _descripcionJugador;
    [SerializeField] private TextMeshProUGUI _costeMejoraJugador;
    [SerializeField] private TextMeshProUGUI _costeDesbloqueoJugador;

    [SerializeField] private TextMeshProUGUI _mineralesText;


    private static MenuManager _instancia;
    public static MenuManager Insatancia { get { return _instancia; }set { _instancia = value; } }

     private SeleccionJugador _jugadorSeleccionado;

    /*
    [SerializeField] private bool _debug;*/


    //Al hacerlo de esta manera, se podrán crear nuevos personajes jugables y arrastrarlos al lobby en futuras actualiizaciones
    [SerializeField] private PersonajeJugable[] _personajes;
    private void Awake()
    {
        _instancia = this;
    }
    private void Start()
    {
        InstanciarPersonajesEnMenu();
    }
    private void Update()
    {
        _mineralesText.text=MineralesManager.Instancia.Minerales.ToString();
    }
    private void InstanciarPersonajesEnMenu()
    {
        for (int i = 0; i < _personajes.Length; i++)
        {
            JugadorMovimiento movimientoJugador=Instantiate(_personajes[i].Jugador, _personajes[i].PosicionEnMenu.position, Quaternion.identity, _personajes[i].PosicionEnMenu);
            movimientoJugador.enabled = false;
        }
    }
    private void MostrarPanelDeJugador()
    {
        _panelJugador.SetActive(true);
        _imgJugador.sprite = _jugadorSeleccionado.ConfiguracionJugador.IconoJugador;
        _nombreJugador.text = $"{_jugadorSeleccionado.ConfiguracionJugador.Nombre}";
        _nivelJugador.text=$"Nivel {_jugadorSeleccionado.ConfiguracionJugador.LVL}";
        _saludJugador.text=$"Salud: {_jugadorSeleccionado.ConfiguracionJugador.Salud}";
        _armaduraJugador.text=$"Escudo: {_jugadorSeleccionado.ConfiguracionJugador.EscudoBase}";
        _descripcionJugador.text=$"{_jugadorSeleccionado.ConfiguracionJugador.Descripcion}";

        _costeMejoraJugador.text=$"{_jugadorSeleccionado.ConfiguracionJugador.CosteDeMejora} para mejorar";
        _costeDesbloqueoJugador.text=$"{_jugadorSeleccionado.ConfiguracionJugador.CosteDesbloqueo} para desbloquear";


    }

    public void ClickSobreSeleccionJugador(SeleccionJugador jugador)
    {

        _jugadorSeleccionado = jugador;
        
        ComprobarSiEstaDesbloqueadoJugador();
        MostrarPanelDeJugador();
    }
    public void MejorarJugador()
    {
        if (MineralesManager.Instancia.Minerales >= _jugadorSeleccionado.ConfiguracionJugador.CosteDeMejora)
        {
            MineralesManager.Instancia.RestarMinerales(_jugadorSeleccionado.ConfiguracionJugador.CosteDeMejora);
            ActualizarStatsDeJugador();
            MostrarPanelDeJugador();


        }
    }
    public void SeleccionarJugador()
    {
        if (_jugadorSeleccionado.ConfiguracionJugador.Disponible)
        {
            _jugadorSeleccionado.GetComponent<JugadorMovimiento>().enabled = true;
            NivelManager.Instancia.Jugador=_jugadorSeleccionado.ConfiguracionJugador.Prefab;
            CerrarPanelJugador();

        }
    }
    public void CerrarPanelJugador()
    {
        _panelJugador.SetActive(false);
    }
    private void ActualizarStatsDeJugador()
    {
        StatsJugador s = _jugadorSeleccionado.ConfiguracionJugador;
        s.LVL++;
        s.SaludBase +=10;
        s.EscudoBase ++;

        float costeMejora = s.CosteDeMejora;
        s.CosteDeMejora = costeMejora + (costeMejora * (s.MultiplicadorMejora / 100f));
    }
    private void ComprobarSiEstaDesbloqueadoJugador()
    {
        if(_jugadorSeleccionado.ConfiguracionJugador.Disponible == false)
        {
            _botonDesbloqueo.SetActive(true);
            _botonMejora.SetActive(false);
            _botonJugar.SetActive(false);
        }
        else
        {
            _botonDesbloqueo.SetActive(false);
            _botonMejora.SetActive(true);
            _botonJugar.SetActive(true);
        }
    }
}
[Serializable]
public class PersonajeJugable
{
    public JugadorMovimiento Jugador;
    public StatsJugador StatsJugador;
    public Transform PosicionEnMenu;
}
