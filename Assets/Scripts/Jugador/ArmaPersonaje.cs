using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaPersonaje : MonoBehaviour
{
    [Header("RotacionArma")]
    [SerializeField] protected Transform _armaPosicionRotacion;
    protected ArmaScript _arma;

    protected virtual void Awake()
    {
        
    }
    protected void RotarPosicionArma(Vector3 direccion)
    {
        //no me funcionaba esta puta funcion y he estado 3 horas probando mierda, me considero a partir
        //de hoy maestro de los jodidos vectores, si lees esto, que sepas que probablemente no este vivo
        if (_arma != null)
        {




            float angulo = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg;

            // Determinar la escala en función de la dirección
            Vector3 escala = new Vector3(direccion.x > 0f ? 1f : -1f, 1f, 1f); // Mantenemos la escala en Y en 1

            // Reiniciar la rotación y escala del arma
            Transform posicion = _arma.transform;
            posicion.rotation = Quaternion.Euler(0f, 0f, angulo);
            posicion.localScale = escala;

            // Reiniciar la rotación y escala del punto de rotación del arma
            _armaPosicionRotacion.rotation = Quaternion.Euler(0f, 0f, angulo);
            _armaPosicionRotacion.localScale = escala;


            _arma.transform.eulerAngles = new Vector3(0f, 0f, angulo);

        }



    }
}
