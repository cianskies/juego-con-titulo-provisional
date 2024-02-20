using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaScriptFusilSemiAutomatico : ArmaScriptPistola
{
    public override void UsarArma()
    {
        for (int i = 0; i < 10; i++)
        {
            base.UsarArma();
        }
        

    }

}
