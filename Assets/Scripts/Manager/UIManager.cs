using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour

{
    private UIManager __instancia;
    [Header("Debug")]
    [SerializeField] private StatsJugador _statsJugador;

    [Header("Stats")]
    [SerializeField] private Image _barraSalud;
    [SerializeField] private TextMeshProUGUI _saludText;

    [SerializeField] private Image _barraEscudo;
    [SerializeField] private TextMeshProUGUI _escudoText;

    [SerializeField] private Image _barraMagia;
    [SerializeField] private TextMeshProUGUI _ammoText;

    [SerializeField] private TextMeshProUGUI _temporizadorText;
    [SerializeField] private TextMeshProUGUI _rondaText;
    [SerializeField] private TextMeshProUGUI _enemigosEnPisoText;

    [SerializeField] private Temporizador _temporizador;

    [SerializeField] private TextMeshProUGUI _monedasText;

    [Header("Paneles")]
    [SerializeField] private GameObject _gameOverCanvas;
    [SerializeField] private GameObject _rondasCanvas;
    [SerializeField] private GameObject _statsJugadorCanvas;
    [SerializeField] private GameObject _ammoCanvas;
    [SerializeField] private TextMeshProUGUI _infoRondaText;


    public UIManager Instancia { get { return __instancia; }}

    private void Awake()
    {
        __instancia = this;
    }
    void Update()
    {
        _saludText.text = $"{_statsJugador.Salud}/{_statsJugador.SaludBase}";
        _escudoText.text = $"{_statsJugador.Escudo}/{_statsJugador.EscudoBase}";
        _ammoText.text = $"{_statsJugador.Ammo}/{_statsJugador.AmmoMax}";

        _barraSalud.fillAmount=Mathf.Lerp(_barraSalud.fillAmount,_statsJugador.Salud/_statsJugador.SaludBase,10f*Time.deltaTime);
        _barraEscudo.fillAmount=Mathf.Lerp(_barraEscudo.fillAmount,_statsJugador.Escudo/_statsJugador.EscudoBase,10f*Time.deltaTime);
        _barraMagia.fillAmount=Mathf.Lerp(_barraMagia.fillAmount,_statsJugador.Ammo /_statsJugador.AmmoMax,10f*Time.deltaTime);

        _rondaText.text = $"{Piso.Instancia.Estructura.RondaActual}";
        //
        _enemigosEnPisoText.text= $"{Piso.Instancia.EnemigosPisoActual}";

        _temporizadorText.text = $"{_temporizador.Minutos}:{_temporizador.Segundos}";

        _monedasText.text = $"{_statsJugador.Dinero}";
    }

    public void LobbyBoton()
    {
        Debug.Log("Heyy");
        SceneManager.LoadScene("Inicio");
    }
    private IEnumerator IETiempoRondaText()
    {
        yield return new WaitForSeconds(2f);
        _infoRondaText.gameObject.SetActive(false);
    }

    private void RespuestaEventoGameOverJugador()
    {
        _gameOverCanvas.SetActive(true);
        _rondasCanvas.SetActive(false);
        _statsJugadorCanvas.SetActive(false);
    }
    private void RespuestaEventoCambiarArmaConCosteAmmo()
    {
        _ammoCanvas.SetActive(true);
    }
    private void RespuestaEventoCambiarArmaSinCosteAmmo()
    {
        _ammoCanvas.SetActive(false);
    }
    private void RespuestaComenzarNuevaRonda(int numeroRonda)
    {
        _infoRondaText.gameObject.SetActive(true);
        _infoRondaText.text=$"¡Comienza la ronda {numeroRonda}!";
        StartCoroutine(IETiempoRondaText());

    }
    private void RespuestaPararTemporizador(int numero)
    {
        _infoRondaText.gameObject.SetActive(true);
        _infoRondaText.text = $"¡Has parado el temporizador en la ronda {numero}!";
        StartCoroutine(IETiempoRondaText());
    }


    private void OnEnable()
    {
        ArmaJugador.EventoCambiarArmaConCosteAmmo += RespuestaEventoCambiarArmaConCosteAmmo;
        ArmaJugador.EventoCambiarArmaSinCosteAmmo += RespuestaEventoCambiarArmaSinCosteAmmo;

        ModificadorStatsJugador.EventoGameOverJugador += RespuestaEventoGameOverJugador;
        Piso.ComienzaNuevaRonda += RespuestaComenzarNuevaRonda;
        Piso.PararElTemporizador += RespuestaPararTemporizador;
    }
    private void OnDisable()
    {
        ModificadorStatsJugador.EventoGameOverJugador -= RespuestaEventoGameOverJugador;
    }

}
