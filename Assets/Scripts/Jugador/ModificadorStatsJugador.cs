using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModificadorStatsJugador : MonoBehaviour, IRecbirDanho
{
    [SerializeField] private StatsJugador _statsJugador;
    public static event Action EventoGameOverJugador;

    

    public void Awake()
    {
        _statsJugador.Salud = _statsJugador.SaludBase;
        _statsJugador.Escudo = _statsJugador.EscudoBase;
        _statsJugador.LVL = _statsJugador.LVLBase;
        _statsJugador.Ammo = 1;
        _statsJugador.PorcentajeCrit = _statsJugador.PorcentajeCritBase;
        _statsJugador.AtaqueCritico = _statsJugador.AtaqueCriticoBase;
        _statsJugador.Dinero = _statsJugador.DineroBase;
        
    }
    public void Curar(float hp)
    {
        _statsJugador.Salud += hp;
        if (_statsJugador.Salud > _statsJugador.SaludBase)
        {
            _statsJugador.Salud = _statsJugador.SaludBase;
        }
    }
    public void CurarEscudo(float hp)
    {
        _statsJugador.Escudo += hp;
        if (_statsJugador.Escudo > _statsJugador.EscudoBase)
        {
            _statsJugador.Escudo = _statsJugador.EscudoBase;
        }
    }
    public void GetAmmo(float ammo)
    {
        _statsJugador.Ammo += ammo;
    }
    public void SetAmmoMax(float ammo)
    {
        _statsJugador.AmmoMax = ammo;
        if(_statsJugador.Ammo>_statsJugador.AmmoMax)
        {
            _statsJugador.Ammo=_statsJugador.AmmoMax;
        }
    }
    public void SubirAtaqueCrit(float atk)
    {
        _statsJugador.AtaqueCritico += atk;
    }
    public void SubirLVL(float lvl)
    {
        _statsJugador.LVL += lvl;
    }
    public void GanarDinero(float euro)
    {
        _statsJugador.Dinero+= euro;
    }

    public void GastarAmmo(float ammo)
    {
        _statsJugador.Ammo -= ammo;
    }
    public bool CosteAmmoSuficiente(float costeAmmo)
    {
        if (_statsJugador.Ammo >= costeAmmo)
        {
            return true;
        }
        else { return false; }

    }
    public void GastarDinero(float euro)
    {
        if (_statsJugador.Dinero > 0 && (_statsJugador.Dinero - euro) > -1)
        {
            _statsJugador.Dinero -= euro;


        }

    }
    public float GetDinero()
    {
        return _statsJugador.Dinero;
    }
    public void RecibirDanho(float hp)
    {
        if(_statsJugador.Escudo>0)
        {
            _statsJugador.Escudo -= hp;
            if (_statsJugador.Escudo <0 )
            {
                _statsJugador.Escudo = 0;
            }

        }
        else
        {
            _statsJugador.Salud -= hp;
            if (_statsJugador.Salud <= 0)
            {
                _statsJugador.Salud = 0;
                GameOverJugador();
            }
        }

    }
    private void GameOverJugador()
    {
        EventoGameOverJugador?.Invoke();
        NivelManager.Instancia.Jugador.SetActive(false);
        
    }


}
