using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaScriptEscopeta : ArmaScriptPistola
{
    [SerializeField] protected float _cadenciaEntreDisparos = 0.6f;
    protected bool _sePuedeUsar=true;
    public override void UsarArma()
    {
        if(_sePuedeUsar)
        {
            _sePuedeUsar = false;
            StartCoroutine(DispararConCadencia());
            
        }
        
    }

    protected IEnumerator DispararConCadencia()
    {
        for (int i = 0; i < 3; i++)
        {
            base.UsarArma();
        }
        yield return new WaitForSeconds(_cadenciaEntreDisparos);
        _sePuedeUsar =true;
    }

}
