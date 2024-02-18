using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class ModificadorStatsJugador : MonoBehaviour, IRecbirDanho
{
    [SerializeField] private StatsJugador _statsJugador;
   

    public void Awake()
    {
        _statsJugador.Salud = _statsJugador.SaludBase;
        _statsJugador.Escudo = _statsJugador.EscudoBase;
        _statsJugador.LVL = _statsJugador.LVLBase;
        _statsJugador.Ataque = _statsJugador.AtaqueBase;
        _statsJugador.Ammo = 1;
        _statsJugador.AmmoBase = 1;
        _statsJugador.PorcentajeCrit = _statsJugador.PorcentajeCritBase;
        _statsJugador.Suerte = _statsJugador.SuerteBase;
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
        _statsJugador.Ammo = ammo;
    }
    public void SetAmmoMax(float ammo)
    {
        _statsJugador.AmmoBase = ammo;
    }
    public void SubirAtaque(float atk)
    {
        _statsJugador.Ataque += atk;
    }
    public void SubirAtaqueCrit(float atk)
    {
        _statsJugador.AtaqueCritico += atk;
    }
    public void SubirLVL(float lvl)
    {
        _statsJugador.LVL += lvl;
    }
    public void SubirSuerte(float lvl)
    {
        _statsJugador.Suerte += lvl;
    }
    public void GanarDinero(float euro)
    {
        _statsJugador.Dinero+= euro;
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
            if (_statsJugador.Salud < 0)
            {
                _statsJugador.Salud = 0;
                Destroy(gameObject);
            }
        }

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



    //proximamente subidas de nivel multiplicadores de danho y movidas similares
}
