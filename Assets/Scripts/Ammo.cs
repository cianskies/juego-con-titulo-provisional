using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public delegate void DelegadoBala(Ammo bala);
    // Start is called before the first frame update
    public static event DelegadoBala InstanciarBala;
    public static event DelegadoBala DestruirBala;
    [Header("Valores")]
    [SerializeField] private float _velocidadAmmo;
    private Vector3 _direccionDisparo;
    private float _atk;

    private float _tiempoEnPantalla=5f;

    public float TiempoEnPantalla { get { return _tiempoEnPantalla; } set { _tiempoEnPantalla = value; } }


    public Vector3 DireccionDisparo { get { return _direccionDisparo;} set { _direccionDisparo = value; } } 
    public float Atk { get { return _atk;} set { _atk = value; } }
    private void Start()
    {
        InstanciarBala?.Invoke(this);
    }
    public void Update()
    {
        transform.Translate(_direccionDisparo * (_velocidadAmmo * Time.deltaTime));
        
        if (_tiempoEnPantalla <= 0)
        {
            
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<IRecbirDanho>()!=null)
        {
            //Debug.Log(_atk);
            collision.GetComponent<IRecbirDanho>().RecibirDanho(_atk);
            Destroy(gameObject);
        }
            
    }

    public void OnDestroy()
    {
        Destroy(gameObject);
    }

}
