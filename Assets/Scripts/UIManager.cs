using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Debug")]
    [SerializeField] private StatsJugador _statsJugador;

    [Header("Stats")]
    [SerializeField] private Image _barraSalud;
    [SerializeField] private TextMeshProUGUI _saludText;

    [SerializeField] private Image _barraEscudo;
    [SerializeField] private TextMeshProUGUI _escudoText;

    [SerializeField] private Image _barraMagia;
    [SerializeField] private TextMeshProUGUI _ammoText;

    //falta hacer el delay del sprint


    void Update()
    {
        _saludText.text = $"{_statsJugador.Salud}/{_statsJugador.SaludBase}";
        _escudoText.text = $"{_statsJugador.Escudo}/{_statsJugador.EscudoBase}";
        _ammoText.text = $"{_statsJugador.Ammo}/{_statsJugador.AmmoBase}";

        _barraSalud.fillAmount=Mathf.Lerp(_barraSalud.fillAmount,_statsJugador.Salud/_statsJugador.SaludBase,10f*Time.deltaTime);
        _barraEscudo.fillAmount=Mathf.Lerp(_barraEscudo.fillAmount,_statsJugador.Escudo/_statsJugador.EscudoBase,10f*Time.deltaTime);
        _barraMagia.fillAmount=Mathf.Lerp(_barraMagia.fillAmount,_statsJugador.Ammo /_statsJugador.AmmoBase,10f*Time.deltaTime);
    }
}
