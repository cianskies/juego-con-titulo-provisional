using System;
using System.Collections.Generic;

[Serializable]
public class EstadoFSM
{
    public string IDEstado;

    public List<AccionFSM> Acciones;
    public List<TransicionFSM> Transiciones;

    public void EjecutarEstadoFSM(EnemigoFSM enemigo)
    {
        EjecutarAccionesFSM();
        EjecutarTransicionesFSM(enemigo);
    }
    private void EjecutarAccionesFSM()
    {
        if (Acciones.Count > 0)
        {
            for (int i = 0; i < Acciones.Count; i++)
            {
                Acciones[i].EjecutarAccionFSM();
            }
        }
    }
    private void EjecutarTransicionesFSM(EnemigoFSM enemigo)
    {
        if (Transiciones.Count > 0)
        {
            for (int i = 0; i < Transiciones.Count; i++)
            {
                bool decisionFSM = Transiciones[i].Decision.Decidir(enemigo);
                if (decisionFSM)
                {
                    if (string.IsNullOrEmpty(Transiciones[i].EstadoTrue) == false)
                    {
                        enemigo.CambiarEstado(Transiciones[i].EstadoTrue);
                        break;
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(Transiciones[i].EstadoFalse) == false)
                    {
                        enemigo.CambiarEstado(Transiciones[i].EstadoFalse);
                        break;

                    }
                }
            }
        }
    }
}
