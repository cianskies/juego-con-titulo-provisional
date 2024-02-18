using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TipoBonificacion
{
    Moneda,
    Salud,
    Armadura,
    Ammo
}
[CreateAssetMenu(menuName = "Items/Bonificadores")]
public class ItemBonificador : ItemData
{
    public float Valor;
    public TipoBonificacion Tipo;

    public override void Recoger()
    {
        ModificadorStatsJugador statsJugador=NivelManager.Instancia.StatsJugador;
        switch (Tipo)
        {
            case TipoBonificacion.Moneda:
                statsJugador.GanarDinero(Valor);
                break;
            case TipoBonificacion.Salud:
                statsJugador.Curar(Valor);
                break;
            case TipoBonificacion.Armadura:
                statsJugador.CurarEscudo(Valor);
                break;
            case TipoBonificacion.Ammo:
                statsJugador.GetAmmo(Valor);
                break;
        }
    }
}
