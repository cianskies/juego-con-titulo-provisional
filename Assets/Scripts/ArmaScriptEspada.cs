using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaScriptEspada : ArmaScript
{

    
    public override void UsarArma()
    {
        AnimarHit();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<IRecbirDanho>() != null)
        {
            collision.GetComponent<IRecbirDanho>().RecibirDanho(_arma.Ataque);
            Debug.Log("Recibe daño de esapada");
        }

    }
}
